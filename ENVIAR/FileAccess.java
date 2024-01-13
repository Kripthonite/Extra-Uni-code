import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;

public class FileAccess {

    public static Scanner inputProducts() throws FileNotFoundException {
        return new Scanner(new File("C:\\Users\\Jessica\\Downloads\\VendingMachine (1)\\VendingMachine\\PRODUCTS.txt"));
    }

    public static PrintWriter saveCoins() throws FileNotFoundException {
        return new PrintWriter("C:\\Users\\Jessica\\Downloads\\VendingMachine (1)\\VendingMachine\\CoinDeposit.txt" );
    }

    public static Scanner loadCoins() throws FileNotFoundException {
        return new Scanner(new File("C:\\Users\\Jessica\\Downloads\\VendingMachine (1)\\VendingMachine\\CoinDeposit.txt"));
    }
}
