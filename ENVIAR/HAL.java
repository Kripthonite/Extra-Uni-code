import isel.leic.UsbPort;

public class HAL {

    private static int bits;

    public static void main(String[] args) {
        init();
    }

    public static void usbPortOut(){
        UsbPort.out(~bits);
    }

    public static int usbPortIn(){
        return ~UsbPort.in();
    }

    public static void init(){
        bits=0;
        usbPortOut();
    }

    public static boolean isBit(int mask){ return (mask&usbPortIn())!=0;}

    public static int readBits(int mask){
        return mask&usbPortIn();
    }

    public static void writeBits(int mask, int value){
        bits&=(~mask);
        bits|=(value&mask);
        usbPortOut();
    }

    public static void setBits(int mask){
        bits|=mask;
        usbPortOut();
    }

    public static void clrBits(int mask){
        bits&=(~mask);
        usbPortOut();
    }
}
