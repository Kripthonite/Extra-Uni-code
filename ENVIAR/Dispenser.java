public class Dispenser {


    public static void init(){
    }

    public static void dispense(int productId){
        SerialEmitter.send(SerialEmitter.Destination.Dispenser,productId);
    }
}
