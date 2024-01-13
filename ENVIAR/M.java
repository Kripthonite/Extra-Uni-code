public class M {

    private static int address=0x40;

    public static boolean manutMode(){
        return HAL.isBit(address);
    }
}
