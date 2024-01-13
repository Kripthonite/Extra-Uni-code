import java.io.FileNotFoundException;

public class CoinDeposit {
    public static int storedCoins;

    public static void init() throws FileNotFoundException {
        String [] coins=FileAccess.loadCoins().nextLine().split(";");
        storedCoins=Integer.parseInt(coins[0]);
    }
    public static void depositCoins(int numb) throws FileNotFoundException {
        storedCoins+= numb;
        FileAccess.saveCoins().println(storedCoins);
    }
}
