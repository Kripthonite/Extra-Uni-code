public class SerialEmitter {
    private static final int SDX = 0x02;
    private static final int BUSY = 0x80;
    private static final int SCLK = 0x01;
    private static int DATA_LENGTH;

    public static int count=0;

    public static enum Destination {Dispenser,LCD};  // Lnd ; 0 = Dispenser ; 1 = LCD

    // Inicia a classe
    public static void init() {
        HAL.init();
        HAL.clrBits(SCLK);
        HAL.setBits(SDX);
    }
    public static void main(String[] args) {
        init();
        send(Destination.Dispenser,0x05);
    }

    // Envia uma trama para o SerialReceiver identificado o destino em addr e os bits de dados em‘data’.
    public static void send(Destination addr, int data){
        while(isBusy()){}

        HAL.clrBits(SCLK);
        HAL.setBits(SDX);
        HAL.clrBits(SDX);

        if (!(addr==Destination.LCD))
            HAL.clrBits(SDX);
        else{
            count++;
            HAL.setBits(SDX);
        }
        DATA_LENGTH=addr==Destination.LCD?10:5;
        for(int i=0,auxData=data;i<DATA_LENGTH-1; i++ ,auxData>>=1){
            sendBit((auxData&1)==1);}
        parityBit();
        HAL.setBits(SCLK);
        HAL.clrBits(SCLK);
        count=0;
    }

    public static void parityBit(){
        sendBit(count%2==0);
    }

    public static void sendBit(boolean bit){
        HAL.setBits(SCLK);
        if (!bit)
            HAL.clrBits(SDX);
        else{
            count++;
            HAL.setBits(SDX);
        }
        HAL.clrBits(SCLK);
    }

    // Retorna true se o canal série estiver ocupado
    public static boolean isBusy(){ return HAL.isBit(BUSY);}
}
