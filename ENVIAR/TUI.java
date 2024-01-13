import java.io.FileNotFoundException;

public class TUI {
    public static boolean arrowSearch=false;
    public static final char CONFIRM='5';
    public static final char LD='1';
    public static final char RM='2';
    public static final char OFF='3';
    public static final char ARROW_MODE='*';
    public static final char SELECTION='#';
    private static final char ARROW_UP='8';
    private static final char ARROW_DOWN='2';

    public static void main(String[] args) throws FileNotFoundException {
        init();
    }
    public static void init(){
        KBD.init();
        LCD.init();
    }

    public static boolean keyCheckTimeout(char k,long timeout){
        return getKeyTimed(timeout)==k;
    }

    public static boolean keyCheck(char k){
        return getKey()==k;
    }

    public static boolean compareKeys(char k, char c){
        return k==c;
    }

    public static char getKeyTimed(long timeout){
        return KBD.waitKey(timeout);
    }

    public static char getKey(){
        return KBD.getKey();
    }

    public static boolean confirm(String txt, long timeout){
        writeScreen(txt,CONFIRM+"-Yes  other-No");
        return keyCheckTimeout(CONFIRM,timeout);
    }

    public static int option(){
        int option=-1;
        char c=getKey();
        if(compareKeys(c,LD))
            option=1;
        else if(compareKeys(c,RM))
            option=2;
        else if(compareKeys(c,OFF))
            option=3;
        return option;
    }

     public static int searchItems(Product [] p,long timeout,boolean manut){
         char pressedKey;
         int idx=0;
         writeProducts(p[Products.availIdx()]);
         while((pressedKey=getKeyTimed(timeout))!=KBD.NONE){
             switch(pressedKey){
                 case SELECTION:
                     if(p[idx].prodQuantity>0||manut)
                         return idx;
                     break;

                 case ARROW_MODE:
                     arrowSearch=!arrowSearch;
                     writeProducts(p[idx]);
                     break;

                 case ARROW_DOWN:
                     if(arrowSearch){
                         idx=(idx==0)? p.length-1:--idx;
                         while(p[idx]==null||p[idx].prodQuantity==0&&!manut){
                             idx--;
                             if(idx<0)
                                 idx=p.length-1;
                         }
                         writeProducts(p[idx]);
                         break;
                     }

                 case ARROW_UP:
                     if(arrowSearch){
                         idx=(idx==p.length-1)?0:++idx;
                         while(p[idx]==null||p[idx].prodQuantity==0&&!manut){
                             idx++;
                             if(idx>=p.length)
                                 idx-=p.length;
                         }
                         writeProducts(p[idx]);
                         break;
                     }

                 default:
                     if(!arrowSearch) {
                         if(p[idx]==null) {
                             idx = 0;
                             break;
                         }
                         idx *= 10;
                         idx += Integer.parseInt(pressedKey + "");
                         if (idx >= p.length)
                             idx %= 10;
                         writeProducts(p[idx]);
                     }
             }
         }
         return -1;
     }

     public static void writeProducts(Product p){
        if(p==null)
            return;
         LCD.clear();
         int num=p.prodNumb,quant=p.prodQuantity,price=p.prodPrice;
         String name=p.prodName;
         writeRnCNoClear(name,0,0);
         writeMenu(num,quant,price);
     }

    public static void writePos(String txt,int l, int c){
        LCD.cursor(l,c);
        LCD.write(txt);
    }

    public static void writeRnC(String txt, int l, int pos){
        LCD.clear();
        int col=LCD.DISPLAY_WIDTH-txt.length();
        writePos(txt,l,pos==0?col/2:col);
    }

    public static void writeRnCNoClear(String txt, int l, int pos){
        int col=LCD.DISPLAY_WIDTH-txt.length();
        writePos(txt,l,pos==0?col/2:col);
        TUI.hideCursor();
    }

    public static void writeScreen(String txtL1,String txtL2){
        writeRnC(txtL1,0,0);
        writeRnCNoClear(txtL2,1,0);
        hideCursor();
    }

    public static void writeMenu(int num,int quant, int price){
        writePos(num/10+""+num%10+(arrowSearch?"↑↓":":"),1,0);
        writeRnCNoClear((quant==0?"#--":"#"+quant/10+""+quant%10),1,0);
        writeRnCNoClear(price/10+"."+price%10+"€",1,1);
        LCD.cursor(1,1);
    }

    public static void hideCursor(){
        LCD.cursor(0,LCD.DISPLAY_WIDTH);
    }

    public static int loadMenu(int timeout){
        String txt="#??";
        int cursor;
        int quant;
        char c;
        while(true){
            quant=0;
            writeRnCNoClear(txt,1,0);
            LCD.cursor(1,cursor=((LCD.DISPLAY_WIDTH-txt.length())/2+1));
            while(compareKeys((c=(getKey())),KBD.NONE)||compareKeys(c,'#')||compareKeys(c,'*'));
                quant+=Integer.parseInt(c+"")*10;
                writePos(c+"",1,cursor);

            if((c=(getKeyTimed(timeout)))!=KBD.NONE){
                quant+=Integer.parseInt(c+"");
                if(quant<=20){
                    writePos(c+"",1,cursor+1);
                    break;
                }
            }
        }
        return quant;
    }
}
