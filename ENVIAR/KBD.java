import isel.leic.utils.Time;

public class KBD {
    public static final char NONE = 0;
    public static final int ACK = 0x80;
    public static final int REGISTER = 0x0F;
    public static final int DVAL = 0x10;
    public static final int WAIT_TIME = 60000;
    public static final char [] CARA={'1','2','3','4','5','6','7','8','9','*','0','#'};
    public static void main (String[]args){
        HAL.init();
        init();
        while(true){
        System.out.println(waitKey(WAIT_TIME));}
    }

    public static void init() {
        HAL.clrBits(ACK);
    }

    public static char getKey() {
        char c=NONE;
        if (HAL.isBit(DVAL)) {//DVAL
            int b=HAL.readBits(REGISTER);
             c=CARA[b];
            HAL.setBits(ACK);// out a ACK
            while(HAL.isBit(DVAL));
            HAL.clrBits(ACK);
        }
        return c;
    }
    public static char waitKey (long timeout){
        char key;
        for (timeout += Time.getTimeInMillis(); Time.getTimeInMillis() < timeout; ) {
            if((key=getKey()) != NONE) return key;
        }
        return NONE;
    }
}
