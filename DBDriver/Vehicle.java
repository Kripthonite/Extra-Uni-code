import java.time.LocalDate;

public class Vehicle {
    private int id;
    private String matricula;
    private int tipo;
    private String modelo;
    private String marca;

    private int ano;
    private int proprietario;

    private String nifproprietario;
    public Vehicle(int id, String matricula, int tipo, String modelo, String marca, int ano, int proprietario) {
        this.id = id;
        this.matricula = matricula;
        this.tipo = tipo;
        this.modelo = modelo;
        this.marca = marca;
        this.ano = ano;
        this.proprietario = proprietario;
    }

    public Vehicle(String values) {

        String[] attr = values.split(",");
        matricula = attr[0];
        tipo = Integer.parseInt(attr[1]);
        modelo = attr[2];
        marca = attr[3];
        ano = Integer.parseInt(attr[4]);
        nifproprietario = attr[5];

    }

    public int getId() {
        return id;
    }

    public String getMatricula() {
        return matricula;
    }

    public int getTipo() {
        return tipo;
    }

    public String getModelo() {
        return modelo;
    }

    public String getMarca() {
        return marca;
    }

    public int getAno() {
        return ano;
    }

    public int getProprietario() {return proprietario;}

    public String getNIF() {
        return nifproprietario;
    }




}
