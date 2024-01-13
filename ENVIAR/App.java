import java.io.FileNotFoundException;

public class App {
    private static final int TIMEOUT=5000;
    private static boolean Off;
    private static Product[] p=Products.p;
    private static int insertedCoins;

    public static void init() throws FileNotFoundException {
        TUI.init();
        Products.init();
        CoinDeposit.init();
        CoinAcceptor.init();
        Dispenser.init();
        insertedCoins=0;
        Off =false;
    }

    public static void main(String[] args) throws FileNotFoundException {
        init();
        while(!Off){
            TUI.writeScreen("Vending Machine","11/12/2018 14:32");
            char c;
            while(!TUI.compareKeys(c=TUI.getKey(),'#')&&!M.manutMode());

            if(M.manutMode())
                manutMode();

            if(TUI.compareKeys(c,'#')) {
                int idx= TUI.searchItems(p,TIMEOUT,false);
                if(idx!=-1) {
                    purchaseOrAbort(p[idx]);
                }
            }
        }
    }

    private static void vendingAbort(Product p) {
        TUI.writeScreen("Vending Aborted",(insertedCoins>0)?"Return "+insertedCoins+" coins":"");
        insertedCoins=0;
        CoinAcceptor.ejectCoins();
    }

    private static boolean waitCoin(Product p){
        int price=p.prodPrice;
        TUI.writeScreen(p.prodName,price/10+"."+price%10+"€");
        while(price>0){

            if(CoinAcceptor.hasCoin()){
                CoinAcceptor.acceptCoin();
                insertedCoins++;
                price--;
                TUI.writeScreen(p.prodName,price/10+"."+price%10+"€");
            }

            if(TUI.keyCheck('#'))
                return false;
        }
        insertedCoins=0;
        return true;
    }

    private static void purchaseOrAbort(Product p){
        if(waitCoin(p))
            dispenseProduct(p);
        else
            vendingAbort(p);
    }

    private static void dispenseProduct(Product p){
        TUI.writeRnCNoClear("Collect product",1,0);
        Dispenser.dispense(p.prodNumb);
        while(SerialEmitter.isBusy());
        TUI.writeScreen("Thank you", "for buying");
        p.prodQuantity--;
        CoinAcceptor.collectCoins();
    }

    private static void manutMode() {
        boolean end=false;
        while(M.manutMode()&&!Off) {
            TUI.writeScreen("Maintenance Mode",TUI.LD+"-Ld "+TUI.RM+"-Rm "+TUI.OFF+"-Off");
            while(M.manutMode()&& !end && !Off) {
                int option = TUI.option();
                switch (option) {
                    case 1:
                        load();
                        end=true;
                        break;
                    case 2:
                        remove();
                        end=true;
                        break;
                    case 3:
                        Off = off();
                        end=true;
                        break;
                }
            }
            end=false;
        }
    }

    private static boolean off() {
        if(TUI.confirm("Shutdown",TIMEOUT)){
            TUI.writeScreen("Shutdown","shutdowning...");
            return true;
        }
        return false;
    }

    private static boolean remove() {
        int idx=TUI.searchItems(p,TIMEOUT,true);
        if(idx==-1)
            return false;
        if(TUI.confirm("Remove "+p[idx].prodName,TIMEOUT))
            Products.removeProduct(idx);
        return true;
    }

    private static boolean load() {
        int idx=TUI.searchItems(p,TIMEOUT,true);
        if(idx==-1)
            return false;
        String name=p[idx].prodName;
        int quant=TUI.loadMenu(TIMEOUT);
        if(TUI.confirm(quant+" "+name,TIMEOUT))
            Products.addQuantity(idx,quant);
        return true;
    }
}
