import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    public static void main(String[] args ){
        Player dealer = new Player("dealer",0);
        Player pl1 = new Player("Miguel",400);
        Player pl2 = new Player("Ze",400);
        ArrayList<Player> p = new ArrayList<Player>();
        p.add(dealer);
        p.add(pl1);
        p.add(pl2);
       PlayBlackJack pbj = new PlayBlackJack(p);
       pbj.play();
       //Vazas vz = new Vazas(p);
       //vz.play();









       /* pl1points = new BlackJackPoints( pl1.getCards());
        dealerpoints = new BlackJackPoints( dealer.getCards());

        pts =pl1points.CountPoints();
        pts2 = dealerpoints.CountPoints();
        for(Card card:pl1.getCards()){
            System.out.println(card);

        }
        System.out.println(pts);
        for(Card card:dealer.getCards()){
            System.out.println(card);

        }
        System.out.println(pts2);
        if(pts2 > pts){ System.out.println("Dealer wins");}
        else if(pts2 < pts){System.out.println("player wins");}
        else{System.out.println("tie");}*/













    }
}

