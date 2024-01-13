import isel.leic.utils.Time;

public class CoinAcceptor {

    public static final int COIN=0x04;
    public static final int ACCEPT=0x10;
    public static final int COLLECT=0x20;
    public static final int EJECT=0x40;
    public static final int TIMEOUT=1000;

    public static void main(String[] args) {
        init();
    }
    public static void init(){
        HAL.init();
    }

    public static boolean hasCoin(){
        return HAL.isBit(COIN);
    }

    public static void acceptCoin(){
        HAL.setBits(ACCEPT);
        while(hasCoin()){}
        HAL.clrBits(ACCEPT);
    }

    public static void ejectCoins(){
        HAL.setBits(EJECT);
        Time.sleep(TIMEOUT);
        HAL.clrBits(EJECT);
    }

    public static void collectCoins(){
        HAL.setBits(COLLECT);
        Time.sleep(TIMEOUT);
        HAL.clrBits(COLLECT);
    }
}
