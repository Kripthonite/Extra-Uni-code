import java.sql.*;
import java.text.ParseException;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Scanner;

import utils.Utils;
import utils.Utils.*;



interface DbWorker
{
    void doWork();
}

public class App{

    private final String url = "jdbc:postgresql://localhost:5432/postgres";
    private final String user = "postgres";
    private final String password = "1234";


    private enum Option
    {
        Unknown,
        Exit,
        VehicleOutOfOrder,
        VehicleStats,
        TopTravellerByYear,
        registerDriver,
        LazyDrivers,
        NoTripsOwner,

        MostEarningsDriver,

        RegisterVehicle,

        OutdatedVehicles,

        RedoDesignacaoChk

    }
    private static App __instance = null;
    private String __connectionString;

    private final HashMap<Option,DbWorker> __dbMethods;

    private App()
    {
        __dbMethods = new HashMap<>();
        __dbMethods.put(Option.Exit, App.this::exit);
        __dbMethods.put(Option.VehicleOutOfOrder, App.this::VehicleOutOfOrder);    //lambda expression
        __dbMethods.put(Option.VehicleStats, App.this::VehicleStats);
        __dbMethods.put(Option.TopTravellerByYear, App.this::TopTravellerByYear);  //lambda expression
        __dbMethods.put(Option.registerDriver, App.this::registerDriver);    //lambda expression
        __dbMethods.put(Option.LazyDrivers, App.this::LazyDrivers);    //lambda expression
        __dbMethods.put(Option.NoTripsOwner, App.this::NoTripsOwner);
        __dbMethods.put(Option.MostEarningsDriver, App.this::MostEarningsDriver);
        __dbMethods.put(Option.RegisterVehicle, App.this::RegisterVehicle);
        __dbMethods.put(Option.OutdatedVehicles, App.this::VehiUpdate);
        __dbMethods.put(Option.RedoDesignacaoChk, App.this::redoDesignacaoChk);
        // __dbMethods.put(Option.registerDepartment, new DbWorker() {public void doWork() {App.this.registerDepartment();}});

    }

    public static App getInstance()
    {
        if(__instance == null)
        {
            __instance = new App();
        }
        return __instance;
    }

    private Option DisplayMenu()
    {
        Option option = Option.Unknown;
        try
        {
            // you may add more option. After that return to line 19 and 37 to change "Option" enum and "App" class
            System.out.println("Company management");
            System.out.println();
            System.out.println("1. Exit");
            System.out.println("2. Disable Vehicle");
            System.out.println("3. Vehicle Stats");
            System.out.println("4. Top Travellers By Year");
            System.out.println("5. Register Driver");
            System.out.println("6. Non Travelling Drivers");
            System.out.println("7. Number Trips by Owner");
            System.out.println("8. Most earnings : Driver");
            System.out.println("9. Register Vehicle");
            System.out.println("10. OLD_VEHICLES ");
            System.out.println("11. Add Constraint Value to Vehicle Designation ");

            System.out.print(">");
            Scanner s = new Scanner(System.in);
            int result = s.nextInt();
            option = Option.values()[result];
        }
        catch(RuntimeException ex)
        {
            //nothing to do.
        }
        return option;

    }
    private static void clearConsole()
    {
        for (int y = 0; y < 25; y++) //console is 80 columns and 25 lines
            System.out.println("\n");

    }
    private void Login() throws java.sql.SQLException
    {
        Connection con = DriverManager.getConnection(getConnectionString());
        if(con != null)
            con.close();
    }

    public void Run() throws Exception
    {
        Login();
        Option userInput;
        do
        {
            clearConsole();
            userInput = DisplayMenu();
            clearConsole();
            try
            {
                __dbMethods.get(userInput).doWork();
                System.in.read();

            }
            catch(NullPointerException ex)
            {
                //Nothing to do. The option was not a valid one. Read another.
            }

        }while(userInput!=Option.Exit);
    }

    public String getConnectionString()
    {
        return __connectionString;
    }
    public void setConnectionString(String s)
    {
        __connectionString = s;
    }

    /**
     To implement from this point forward. Do not need to change the code above.
     -------------------------------------------------------------------------------
     IMPORTANT:
     --- DO NOT MOVE IN THE CODE ABOVE. JUST HAVE TO IMPLEMENT THE METHODS BELOW ---
     -------------------------------------------------------------------------------

     */

    private static final int TAB_SIZE = 24;
    void printResults(ResultSet dr) throws SQLException {
        ResultSetMetaData rsmd = dr.getMetaData();
        int columnsNumber = rsmd.getColumnCount();
        for (int i = 1; i <= columnsNumber; i++) {
            System.out.print(rsmd.getColumnName(i) + " ");

        }
        System.out.println();
        for (int i = 1; i <= columnsNumber * 12; i++) {
            System.out.print("-");
        }


        while (dr.next()) {
            System.out.println();
            for (int i = 1; i <= columnsNumber; i++) {

                String columnValue = dr.getString(i);
                System.out.print(columnValue + " ");
            }

        }
        /*Result must be similar like:
        ListDepartment()
        dname           dnumber     mgrssn      mgrstartdate
        -----------------------------------------------------
        Research        5           333445555   1988-05-22
        Administration  4           987654321   1995-01-01
        */
    }
    private void exit(){
        System.out.println("Shutting down...");
        System.exit(1);
    }
    private void TopTravellerByYear() //2.c
    {
        System.out.print("Which year? ");
        Scanner s = new Scanner(System.in);
        int ans = s.nextInt();

        final String TOP_TRAVELLER = """
                SELECT cv.idpessoa , p.nproprio ,p.apelido ,p.nif\s
                FROM viagem v\s
                  JOIN clienteviagem cv ON v.idsistema = cv.viagem
                  JOIN pessoa p ON p.id = cv.idpessoa\s
                WHERE EXTRACT(YEAR FROM v.dtviagem) = ?
                GROUP BY cv.idpessoa , p.nproprio,p.apelido  ,p.nif\s
                ORDER BY count(cv.idpessoa) desc
                fetch first 1 row with ties""";
        try(
                Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());
                PreparedStatement query = con.prepareStatement(TOP_TRAVELLER);


        ) {
            query.setInt(1, ans);
            ResultSet rs = query.executeQuery();
            System.out.println("TopTravellerByYear()");
            printResults(rs);


        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }



    }

    private void VehicleStats()
    {
        final String LIST_VEHICLES = "SELECT * FROM veiculo";
        final String STATS_INFO = """
                SELECT latinicio ,longinicio  , latfim ,longfim ,valfinal , hinicio ,hfim\s
                FROM viagem v\s
                where v.veiculo = ?""";
        try(
                Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());
                PreparedStatement vehicles = con.prepareStatement(LIST_VEHICLES);
                PreparedStatement stats = con.prepareStatement(STATS_INFO);


        ) {
            ResultSet rs = vehicles.executeQuery();
            System.out.println("All Vehicles");
            printResults(rs);
            System.out.println();
            System.out.println("Write Vehicle Id to see stats...");
            Scanner s = new Scanner(System.in);
            int ans = s.nextInt();
            stats.setInt(1,ans);
            rs = stats.executeQuery();
            Quadra<Double, Double, Integer,Integer> trp = getVehicleStats(rs);
            System.out.println("O veículo de Id: " + ans + " percorreu " + trp.getFirst() + " KM, adquiriu " + trp.getSecond() + " Euros e andou durante " + Utils.seconds2Str(trp.getThird())+ " ao longo de " + trp.getFourth() + " viagens!");










        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } catch (ParseException e) {
            throw new RuntimeException(e);
        }


    }

    private void VehicleOutOfOrder(String... licensePlate) {
        String lp;
        if(licensePlate.length>0){
            lp = licensePlate[0];
        }else{
            System.out.print("License Plate? ");
            Scanner s = new Scanner(System.in);
            lp = s.nextLine();
        }


        final String CAR_INFO = "SELECT * FROM veiculo v \n" +
                "WHERE v.matricula = ?";
        final String CREATE_CARTABLE = """
                CREATE TABLE IF NOT EXISTS VEICULO_OLD(
                \tid SERIAL PRIMARY KEY,
                \tmatricula varchar(10) UNIQUE,
                \ttipo int NOT NULL DEFAULT 1 ,
                \tmodelo varchar(11) NOT NULL,
                \tmarca varchar(10) NOT NULL,
                \tano int NOT NULL,
                \tproprietario int NOT NULL,
                \tnoviagens int NOT NULL,
                \tkmpercorridos float8 NOT NULL
                );""";

        final String INS_OLDVEHI = "INSERT INTO VEICULO_OLD VALUES (?,?,?,?,?,?,?,?,?)";

        final String DEL_CAR = "DELETE FROM veiculo WHERE matricula = ?;";

        final String STATS_INFO = """
                SELECT latinicio ,longinicio  , latfim ,longfim ,valfinal , hinicio ,hfim\s
                FROM viagem vi, veiculo v\s
                where v.matricula = ? and vi.veiculo = v.id """;

        /*final String COUNT_TRAVELS = "SELECT v.id , count(v.id) as noviagens\n" +
                "FROM veiculo v , viagem vi\n" +
                "where v.id = vi.veiculo  and v.matricula = ?\n" +
                "GROUP BY v.id";*/


        try(
                Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());
                PreparedStatement query = con.prepareStatement(CAR_INFO);
                PreparedStatement createoldvehi = con.prepareStatement(CREATE_CARTABLE);
                PreparedStatement insoldvehi = con.prepareStatement(INS_OLDVEHI);
                PreparedStatement delcar = con.prepareStatement(DEL_CAR);
                PreparedStatement stats = con.prepareStatement(STATS_INFO);
                //PreparedStatement travels = con.prepareStatement(COUNT_TRAVELS);


        ) {
            con.setAutoCommit(false);
            query.setString(1, lp);
            ResultSet rs = query.executeQuery();
            if(rs.next()){
                createoldvehi.executeUpdate(); // CREATE TABLE OLD VEHI IF NOT EXISTS
                int id = rs.getInt("id");
                String matricula = rs.getString("matricula");
                int tipo = rs.getInt("tipo");
                String modelo = rs.getString("modelo");
                String marca = rs.getString("marca");
                int ano = rs.getInt("ano");
                int proprietario = rs.getInt("proprietario");
                Vehicle vehi = new Vehicle(id,matricula,tipo,modelo,marca,ano,proprietario);
                stats.setString(1,matricula);
                ResultSet st = stats.executeQuery();
                Quadra<Double,Double,Integer,Integer> trp = getVehicleStats(st);
                insoldvehi.setInt(1,vehi.getId());
                insoldvehi.setString(2,vehi.getMatricula());
                insoldvehi.setInt(3,vehi.getTipo());
                insoldvehi.setString(4,vehi.getModelo());
                insoldvehi.setString(5,vehi.getMarca());
                insoldvehi.setInt(6,vehi.getAno());
                insoldvehi.setInt(7,vehi.getProprietario());
                insoldvehi.setInt(8,trp.getFourth());
                insoldvehi.setDouble(9,trp.getFirst());
                insoldvehi.executeUpdate(); // por informacao em OLD_VEHICLE
                delcar.setString(1,matricula);
                delcar.executeUpdate();//DELETE Car da tabela VEICULOS





            }else{
                System.out.println("No Vehicle with that License Plate");
            }
            con.commit();
            con.setAutoCommit(true);




        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } catch (ParseException e) {
            throw new RuntimeException(e);
        }
        System.out.println("VehicleOutOfOrder()");
    }
//123456789147,125435463211,Manuel,Gomes,Rua dos Santos,1234567,Lisboa,AA-1234567,1980-01-12
    private void registerDriver() {
        String values = Model.inputData( "noident , nif , nproprio , apelido ,morada , codpostal , localidade ,nccondutor and data de nascimento.\n");
        // validate all entries!
        Driver driver = new Driver(values);
        Model.registerDriver(driver);
        System.out.println("registerDriver()");
    }

    private void redoDesignacaoChk()  {
        String values = Model.inputData("nlugares, multiplicador , designacao.\n");
        try{
            Model.redoDesignacaoChk(values);
            System.out.println("AddConstraintChk()");
        }catch (SQLException e){
            System.out.println(e.getMessage());
        }

    }

    private  void VehiUpdate(){
        final String OUTDATED_LP = "SELECT matricula  FROM veiculo v \n" +
                "WHERE DATE_PART('year', NOW()::date) - v.ano  >= 4";

        try(
                Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());
                PreparedStatement query = con.prepareStatement(OUTDATED_LP);
                ){
            ResultSet rs = query.executeQuery();
            String matricula;
            while(rs.next()){
                matricula = rs.getString("matricula");
                VehicleOutOfOrder(matricula);
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }

    private Quadra<Double,Double, Integer, Integer> getVehicleStats(ResultSet rs) throws SQLException, ParseException {
        double sumKM = 0;
        double sumVal = 0;
        int timeWK = 0;
        int noviagens = 0;



        while(rs.next()){
            double lati = rs.getDouble("latinicio");
            double longi = rs.getDouble("longinicio");
            double latf = rs.getDouble("latfim");
            double longf =rs.getDouble("latfim");
            double value = rs.getDouble("valfinal");
            String hi = rs.getString("hinicio");
            String hf = rs.getString("hfim");
            sumVal += value;
            sumKM += Utils.distance(lati,longi,latf,longf,"K");
            timeWK += Utils.timeDiff(hf,hi);
            noviagens++;
        }
        return new Quadra<>(sumKM,sumVal,timeWK,noviagens);
    }
    private void LazyDrivers() // 2.d
    {

        final String SELECT_LAZY_DRIVERS = """
                select pessoa.id, nproprio, apelido, nif
                \tfrom pessoa join (
                \t\tselect id
                \t\tfrom pessoa
                \t\twhere atrdisc = 'C'
                \t\texcept
                \t\tselect condutor
                \t\tfrom viagem
                \t) as aux on (pessoa.id = aux.id);""";

        try(
                Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());
                PreparedStatement query = con.prepareStatement(SELECT_LAZY_DRIVERS);


        ) {

            ResultSet rs = query.executeQuery();
            System.out.println("LazyDrivers()");
            printResults(rs);

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }

    }




    private void NoTripsOwner() // 3.b
    {
        String values = Model.inputData( "Year and NIF/FULL NAME of Vehicle Owner\n");


        String[] answers = values.split(",");



        try(
                Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());



        ) {
            PreparedStatement query;
            if(Utils.isNumeric(answers[1])){
                final String SELECT_COUNT = """
                SELECT idVehi.id as IdVeiculo, COUNT(idVehi.id) as noviagens
                FROM viagem vi join(
                \tSELECT v.id
                \tFROM pessoa p , veiculo v\s
                \tWHERE p.id  = v.proprietario and p.nif = ?
                ) as idVehi on vi.veiculo = idVehi.id
                WHERE date_part('year', vi.dtviagem)::int = ?
                GROUP BY idVehi.id;""";

                query = con.prepareStatement(SELECT_COUNT);
                query.setString(1, answers[1]);
                query.setInt(2, Integer.parseInt(answers[0]));
            }else{
                final String SELECT_COUNT = """
                SELECT idVehi.id as IdVeiculo, COUNT(idVehi.id) as noviagens
                FROM viagem vi join(
                \tSELECT v.id
                \tFROM pessoa p , veiculo v\s
                \tWHERE p.id  = v.proprietario and p.nproprio = ? and p.apelido = ?
                ) as idVehi on vi.veiculo = idVehi.id
                WHERE date_part('year', vi.dtviagem)::int = ?
                GROUP BY idVehi.id;""";

                query = con.prepareStatement(SELECT_COUNT);
                String[] name = answers[1].split(" ");
                query.setString(1, name[0]);
                query.setString(2, name[1]);
                query.setInt(3, Integer.parseInt(answers[0]));

            }

            ResultSet rs = query.executeQuery();
            System.out.println("NoTripsOwner()");
            printResults(rs);

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }

    }

    private void RegisterVehicle(){
        String values = Model.inputData( "matricula, tipo, modelo, marca, ano, owner NIF \n");
        // validate all entries!
        Vehicle vehicle = new Vehicle(values);
        Model.registerVehicle(vehicle);
        System.out.println("registerVehicle()");
    }

    private void MostEarningsDriver() // 3.c
    {
        System.out.print("Which year? ");
        Scanner s = new Scanner(System.in);
        int ans = s.nextInt();



        final String SELECT_COUNT = """
                select pessoa.nproprio, pessoa.apelido, pessoa.noident, pessoa.morada
                from pessoa join (
                        select condutor, sum(valfinal) as total
                        from viagem
                        where (date_part('year', dtviagem)::int = ?)
                        group by condutor
                        order by total
                        desc limit 1
                ) as aux on pessoa.id = aux.condutor;""";

        try(
                Connection con = DriverManager.getConnection(App.getInstance().getConnectionString());
                PreparedStatement query = con.prepareStatement(SELECT_COUNT);


        ) {
            query.setInt(1, ans);

            ResultSet rs = query.executeQuery();
            System.out.println("MostEarningsDriver()");
            printResults(rs);

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }

    }







    public static void main(String[] args) throws Exception {

        String url = "jdbc:postgresql://localhost:5432/?user=postgres&password=1234&ssl=false";
        App.getInstance().setConnectionString(url);
        App.getInstance().Run();
    }
}