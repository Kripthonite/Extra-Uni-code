import java.util.ArrayList;
import java.util.HashMap;


public class BlackJackPoints {
    private final ArrayList<Card> cards;
    private static final HashMap<String, Integer> map = new HashMap<>() {{
        put("ace", 11);
        put("deuce", 2);
        put("three", 3);
        put("four", 4);
        put("five", 5);
        put("six", 6);
        put("seven", 7);
        put("eight", 8);
        put("nine", 9);
        put("ten", 10);
        put("jack", 10);
        put("queen", 10);
        put("king", 10);
    }};




    public BlackJackPoints(ArrayList<Card> cards) {
        this.cards = cards;
    }

    public int CountPoints(){
        int points=0;
        for(Card card:cards){
            points += map.get(card.rank());
            if(card.rank()=="ace" && points>21){
                points -= 10;
            }

        }
        return points;
    }
}
