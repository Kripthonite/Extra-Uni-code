import java.util.ArrayList;

public class Player {
    private final String name;
    private  double saldo;
    //VAZAS
    private int points = 0;

    private int strikes = 0;
    private int noaposta;
    private  ArrayList<Card> cards;

    public Player(String name, double saldo) {
        this.name = name;
        this.saldo = saldo;
        this.cards = new ArrayList<Card>();
    }

    public String getName(){return name;}

    public double getSaldo(){
        return saldo;
    }

    public void setSaldo(double a){
        saldo = saldo + a;
    }

    public int getPoints(){
        return points;
    }

    public void addPoints(){
        points++;
    }

    public void resetPoints(){
        points=0;
    }


    public void addStrike(){ strikes++; }
    public void resetStrikes(){ strikes = 0;}

    public int getStrikes(){ return strikes;}

    public int getNoaposta(){return noaposta;}
    public void setNoaposta(int a){noaposta= a;}

    public  void setCards(ArrayList<Card> cards) {
        this.cards = cards;
    }

    public  void addCard(Card card) {
        this.cards.add(card);
    }

    public  void clearCards(){
        this.cards.clear();
    }

    public ArrayList<Card> getCards(){
        return cards;
    }

    public void removeCard(int a){
        cards.remove(a);
    }
}
