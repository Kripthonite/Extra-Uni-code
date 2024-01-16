import org.jetbrains.annotations.NotNull;

import java.time.LocalDate;

class Driver {


    public String getNoident() {
        return noident;
    }

    public String getNif() {
        return nif;
    }

    public String getNproprio() {
        return nproprio;
    }

    public String getApelido() {
        return apelido;
    }

    public String getMorada() {
        return morada;
    }

    public int getCodpostal() {
        return codpostal;
    }

    public String getLocalidade() {
        return localidade;
    }

    public String getNccondutor() {
        return nccondutor;
    }

    public LocalDate getDtnascimento() {
        return dtnascimento;
    }

    private String noident;
    private String nif;
    private String nproprio;
    private String apelido;
    private String morada;
    private int codpostal;
    private String localidade;
    private String atrdisc = "C";
    private String nccondutor;
    private LocalDate dtnascimento;




    Driver(String values){
        String[] attr = values.split(",");
        noident = attr[0];
        nif = attr[1];
        nproprio = attr[2];
        apelido = attr[3];
        morada = attr[4];
        codpostal = Integer.parseInt(attr[5]);
        localidade = attr[6];
        nccondutor = attr[7];
        dtnascimento = LocalDate.parse(attr[8]);

    }


}

