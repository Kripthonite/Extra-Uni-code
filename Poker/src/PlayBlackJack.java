import java.util.ArrayList;
import java.util.Scanner;

public class PlayBlackJack {
    Scanner keyboard = new Scanner(System.in);
    boolean bjpl = false;
    boolean bjdl = false;
    boolean payed = false;
    boolean roundover=false;
    boolean playerBust = false;
    boolean dealerBust = false;

    double saldo = 1;
    double aposta;

    ArrayList<Player> players;

    public PlayBlackJack(ArrayList<Player> p) {
        this.players = p;

    }






    public void play(){
        while(saldo > 0  ){
            DeckOfCard deck = new DeckOfCard();
            ArrayList<Card> cards = deck.getCards();
            for(Player p : players){
                p.clearCards();
            }
            saldo =  players.get(1).getSaldo();
            payed = false;
            bjpl = false;
            bjdl = false;
            roundover = false;
            aposta= 0;
            System.out.println("O teu saldo e de = " + saldo);
            double ans1 = saldo + 1;
            while(ans1 > saldo ){
                System.out.println("Queres continuar a jogar? Se sim , mete a quantia da aposta senao mete 0");
                ans1 = keyboard.nextInt();
                if(ans1== 0 ){

                    saldo = 0;
                    break;}
                if(ans1 > saldo){
                    System.out.println("Nao tens fundos suficientes");


                    break;

                }
                else{
                    aposta = ans1;
                }
            }


            while(!roundover){
                for(Player p : players){
                    p.addCard(cards.get(0));
                    cards.remove(0);
                    p.addCard(cards.get(0));
                    cards.remove(0);

                }
                BlackJackPoints pl1points = new BlackJackPoints( players.get(1).getCards());
                BlackJackPoints dealerpoints = new BlackJackPoints( players.get(0).getCards());

                int pts =pl1points.CountPoints();
                int pts2 = dealerpoints.CountPoints();
                for(Card card:players.get(1).getCards()){
                    System.out.println(card);

                }
                System.out.println(pts);
                for(Card card:players.get(0).getCards()){
                    System.out.println(card);

                }
                System.out.println(pts2);
                if(pts == 21){

                    bjpl = true;
                    roundover =true;

                }

                if(pts2 == 21){


                    bjdl = true;
                    roundover =true;

                }

                while(pts < 21 ) {

                    if(pts2 == 21){break;}
                    System.out.println("Pedir Carta ? 1/0");
                    int ans =  keyboard.nextInt();
                    if(ans == 1){
                        players.get(1).addCard(cards.get(0));
                        cards.remove(0);
                        pl1points = new BlackJackPoints( players.get(1).getCards());
                        pts =pl1points.CountPoints();
                        for(Card card:players.get(1).getCards()){
                            System.out.println(card);

                        }
                        System.out.println(pts);
                        if(pts>21) {
                            playerBust = true;

                            roundover = true;
                            System.out.println("PlayerBust");
                            break;
                        }
                    }
                    else{
                        roundover = true;
                        break;
                    }


                }
                if(!(playerBust || bjpl)){
                    while(pts2 < 17){
                        players.get(0).addCard(cards.get(0));
                        cards.remove(0);
                        dealerpoints = new BlackJackPoints( players.get(0).getCards());
                        pts2 = dealerpoints.CountPoints();
                        for(Card card:players.get(0).getCards()){
                            System.out.println(card);

                        }
                        System.out.println(pts2);
                        if(pts2 > 21){
                            dealerBust = true;

                            System.out.println("DealerBust");
                            break;
                        }

                    }
                }


                if(playerBust){
                    System.out.println("Dealer Wins");
                    players.get(1).setSaldo(-aposta);

                }
                else if(dealerBust){
                    System.out.println("Player Wins");
                    players.get(1).setSaldo(aposta);

                }
                else{
                    if(bjpl && !bjdl){
                        players.get(1).setSaldo(1.5*aposta);
                        System.out.println("PLAYER BLACK JACK");
                    }
                    else if(!bjpl&&bjdl){
                        players.get(1).setSaldo(-aposta);
                        System.out.println("DEALER BLACK JACK");

                    }
                    else {
                        if(pts2 > pts){
                            players.get(1).setSaldo(-aposta);
                            System.out.println("Dealer wins");
                        }
                        if(pts2 < pts){
                            System.out.println("player wins");
                            players.get(1).setSaldo(aposta);
                        }
                        if(pts == pts2){System.out.println("tie");}
                    }
                }




            }
        }
    }

}
