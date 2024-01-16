import java.util.ArrayList;
import java.util.Collections;

public class DeckOfCard {
    private static final String suits[] = {"club", "diamond", "heart", "spade"};

    private static final String ranks[] = {"ace", "deuce", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king"};
    private final ArrayList<Card> cards;

    public DeckOfCard(){
        cards = new ArrayList<Card>();
        for (int i = 0; i<suits.length; i++) {
            for(int j=0; j<ranks.length; j++){
                this.cards.add(new Card(suits[i],ranks[j]));
            }
        }
        //Shuffle after the creation
        Collections.shuffle(this.cards);

    }

    public ArrayList<Card> getCards() {
        return cards;
    }
}
