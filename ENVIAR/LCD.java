import isel.leic.utils.Time;

public class LCD {
    private static final int ENTRY_MODE = 0x06;
    private static final int CLEAR = 0x01;
    private static final int FUNCTION_SET8B = 0x30;
    private static final int DISPLAY_OFF = 0x08;
    private static final int DISPLAY_ON = 0x0F;
    public static final int DISPLAY_WIDTH=16;

    public static void main(String[] args) {
        LCD.init();
    }

    public static void init(){
        SerialEmitter.init();
        Time.sleep(120);
        writeByte(false,FUNCTION_SET8B); //0x30
        Time.sleep(5);
        writeByte(false,FUNCTION_SET8B);
        Time.sleep(1);
        writeByte(false,FUNCTION_SET8B);

        writeCMD(0x38); //0x28
        writeCMD(DISPLAY_OFF);  //0x08
        writeCMD(CLEAR);    //0x01
        writeCMD(ENTRY_MODE);  //0x06
        writeCMD(DISPLAY_ON);   //0x0F
    }

    private static void writeByte(boolean rs, int data) {
        int flag;
        if (rs) {// output de rs
            flag = 0x001;
        }
        else {
            flag = 0x000;
        }
        data<<= 1;
        data |= flag;
        SerialEmitter.send(SerialEmitter.Destination.LCD,data);
    }

    private static void writeCMD(int data){
        writeByte(false,data);
    }
    private static void writeDATA(int data){
        writeByte(true,data);
    }
    public static void write(char c){
        writeDATA(c);
    }

    public static void write(String txt){
        for (int k=0;k<txt.length();k++){
            write(txt.charAt(k));
        }
    }

    public static void cursor(int lin, int col){
        writeCMD((lin == 1 ? 0xC0 : 0x80) +col);
    }

    public static void clear(){
        writeByte(false,CLEAR);   //0x01
        writeByte(false,0x02);  // ou cursor (0,0)
    }
}