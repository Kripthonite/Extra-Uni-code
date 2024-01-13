import java.io.FileNotFoundException;
import java.util.Scanner;

public class Products {
    private static final int MAX_NUMB_PRODUCTS=16;
    public static Product[] p=new Product[MAX_NUMB_PRODUCTS];

    public static void init() throws FileNotFoundException {
        Scanner input= FileAccess.inputProducts();
        while(input.hasNextLine()){
            String line=input.nextLine();
            String[] info=line.split(";");
            int num=Integer.parseInt(info[0]);
            p[num]=new Product(Integer.parseInt(info[0]),info[1],Integer.parseInt(info[3]),Integer.parseInt(info[2]));
        }
    }

    public static void addQuantity(int idx,int quant){
        p[idx].prodQuantity=quant;
    }

    public static void removeProduct(int idx){
        p[idx]=null;
    }

    public static int availIdx(){
        for(int i=0;i<MAX_NUMB_PRODUCTS;i++){
            if(!availCheck(p[i]))
                return i;
        }
        return -1;
    }

    public static boolean availCheck(Product p){
        return p==null||p.prodQuantity>0;
    }
}
