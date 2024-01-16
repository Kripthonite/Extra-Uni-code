import java.sql.*;
import java.util.ArrayList;
import java.util.Objects;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

class Model {

    public static void redoDesignacaoChk(String values) throws SQLException {
        String[] arr= values.split(",");
        int nlugares = Integer.parseInt(arr[0]);
        double multiplicador = Double.parseDouble(arr[1]);
        String designacao = arr[2];

        Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());
        con.setAutoCommit(false);

        String getDesignations = "SELECT pg_get_constraintdef(oid)\n" +
                "FROM pg_constraint\n" +
                "where conname = 'designacao_chk'";



        ArrayList<String> DESIGNACOES = new ArrayList<String>();




        PreparedStatement get = con.prepareStatement(getDesignations);

        ResultSet rs = get.executeQuery();
        String str= "";
        if(rs.next()){
            str = rs.getString(1);

        }
        Pattern pattern = Pattern.compile("'([^']+)'");
        Matcher matcher = pattern.matcher(str);

        while (matcher.find()) {
            DESIGNACOES.add(matcher.group(1));

        }

        PreparedStatement dropC=null;
        PreparedStatement addC=null;
        if(!DESIGNACOES.contains(designacao)){// se designacao nao estiver no CheckConstraint meter no CheckConstraint
            DESIGNACOES.add(designacao);
            // Create a string containing the new CHECK constraint
            String constraint = "CHECK (designacao IN ('" + String.join("','", DESIGNACOES) + "'))";
            // Alter the TipoVeiculo table to drop the existing CHECK constraint
            String drop = "ALTER TABLE TipoVeiculo DROP CONSTRAINT designacao_chk";
            String add = "ALTER TABLE TipoVeiculo ADD CONSTRAINT designacao_chk " + constraint;

            dropC = con.prepareStatement(drop);
            addC = con.prepareStatement(add);
            dropC.executeUpdate();
            addC.executeUpdate();
        }

        //ver se já existe essa designacao na Tabela tipoveiculo , se existir dar update , se nao existir , dar insert aos valores



        String up_tipoveiculo = "UPDATE tipoveiculo\n" +
                "SET nlugares = ?,\n" +
                "\tmultiplicador = ?\n" +
                "WHERE designacao = ?";
        PreparedStatement up = con.prepareStatement(up_tipoveiculo);
        up.setInt(1,nlugares);
        up.setDouble(2,multiplicador);
        up.setString(3,designacao);
        up.executeUpdate();
        int rowsaffected = up.executeUpdate();
        PreparedStatement ins = null;
        if(rowsaffected<=0){
            String ins_tipoveiculo = "INSERT INTO tipoveiculo(nlugares,multiplicador,designacao) VALUES(?,?,?)";
            ins = con.prepareStatement(ins_tipoveiculo);
            ins.setInt(1,nlugares);
            ins.setDouble(2,multiplicador);
            ins.setString(3,designacao);
            ins.executeUpdate();

        }











        // commit updates
        con.commit();
        con.setAutoCommit(true);
        //close statements
        rs.close();
        get.close();
        if(ins!=null){ins.close();}
        if(dropC!=null){dropC.close();}
        if(addC!=null){addC.close();}
        //close con
        con.close();




    }

    static void registerDriver(Driver driver){
        final String SELECT_CMD = "select id,atrdisc from Pessoa where nif = ?;";
        final String INSERT_DRIVER = "INSERT INTO Condutor VALUES (?,?,?) ";
        final String INSERT_PERSON = "INSERT INTO Pessoa(noident,nif,nproprio,apelido,morada,codpostal,localidade,atrdisc) VALUES (?,?,?,?,?,?,?,?) ";
        final String SELECT_LAST_ID = """
                SELECT * FROM pessoa p
                ORDER BY id desc
                LIMIT 1""";

        try(
                Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());
                PreparedStatement pstmt1 = con.prepareStatement(SELECT_CMD);
                PreparedStatement pstmt2 = con.prepareStatement(INSERT_DRIVER);
                PreparedStatement pstmt3 = con.prepareStatement(INSERT_PERSON);
                PreparedStatement pstmt4 = con.prepareStatement(SELECT_LAST_ID);


        ) {
            con.setAutoCommit(false);
            pstmt1.setString(1, driver.getNif());
            ResultSet rs = pstmt1.executeQuery();
            int id;
            String atrdisc;
            //when several calls
            if (rs.next()){// se ja houver uma pessoa com estes dados
                id = rs.getInt("id");
                atrdisc = rs.getString("atrdisc");
                if(Objects.equals(atrdisc, "P")){
                    System.out.println("This person is already a Owner!");
                    return;
                }
                pstmt2.setInt(1, id );
                pstmt2.setString(2, driver.getNccondutor());
                pstmt2.setObject(3, driver.getDtnascimento());


                int updateCount = pstmt2.executeUpdate();
                if(updateCount!=1){
                    System.out.println("Error creating Driver");
                } else if (updateCount==1) {
                    System.out.println("created Driver");
                }

            }else{// se nao existir pessoa com esses dados
                pstmt3.setString(1,driver.getNoident());
                pstmt3.setString(2,driver.getNif());
                pstmt3.setString(3,driver.getNproprio());
                pstmt3.setString(4,driver.getApelido());
                pstmt3.setString(5,driver.getMorada());
                pstmt3.setInt(6,driver.getCodpostal());
                pstmt3.setString(7,driver.getLocalidade());
                pstmt3.setString(8,"C");

                int updateCount = pstmt3.executeUpdate();
                if(updateCount!=1){
                    System.out.println("Error creating Person");
                    return;
                } else if (updateCount==1) {
                    System.out.println("created Person");
                    ResultSet ids = pstmt4.executeQuery();
                    int last_id;
                    if(ids.next()){
                        last_id = ids.getInt("id");
                        pstmt2.setInt(1, last_id );
                        pstmt2.setString(2, driver.getNccondutor());
                        pstmt2.setObject(3, driver.getDtnascimento());
                        pstmt2.executeUpdate();
                    }

                }

            }
            con.commit(); //when several calls
            con.setAutoCommit(true);
            System.out.println("Driver registered!!!!");



        } catch (SQLException e) {
            System.out.println(e.getMessage());
            System.out.println("Error on insert values!!");
        }
    }

    static void registerVehicle(Vehicle vehicle)  {
        final String NUMBER_CARS = "SELECT p.id ,count(p.id) as NoCars\n" +
                "\t\t\tFROM pessoa p , veiculo v \n" +
                "\t\t\tWHERE p.id = v.proprietario and p.nif  = ?\n" +
                "\t\t\tGROUP BY p.id";

        final String INS_VEHICLE = "INSERT INTO Veiculo(matricula,tipo,modelo,marca,ano,proprietario) VALUES (?,?,?,?,?,?);";


        try(
                Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());
                PreparedStatement numberCars = con.prepareStatement(NUMBER_CARS);
                PreparedStatement insVehicle = con.prepareStatement(INS_VEHICLE);



        ) {
            con.setAutoCommit(false);
            numberCars.setString(1,vehicle.getNIF());
            ResultSet rs = numberCars.executeQuery();
            int numCars=0;
            int proprietarioid=-1;
            if(rs.next()){
                proprietarioid = rs.getInt("id");
                numCars = rs.getInt("NoCars");
            }
            if(numCars >= 5){
                System.out.println("Owner with NIF " + vehicle.getNIF() + " already has 5 cars");
                return;
            }
            insVehicle.setString(1, vehicle.getMatricula());
            insVehicle.setInt(2,vehicle.getTipo());
            insVehicle.setString(3,vehicle.getModelo());
            insVehicle.setString(4,vehicle.getMarca());
            insVehicle.setInt(5,vehicle.getAno());
            insVehicle.setInt(6,proprietarioid);
            insVehicle.executeUpdate();



            con.commit(); //when several calls
            con.setAutoCommit(true);
            System.out.println("Vehicle registered!!!!");

        }
        catch (SQLException e) {
            System.out.println(e.getMessage());
            System.out.println("Error on insert values!!");
        }
    }


    static String inputData(String str){
        java.util.Scanner key = new Scanner(System.in);
        System.out.print("Enter corresponding values, separated by commas, \n" + str);
        String values = key.nextLine();
        return values;
    }
}
