import java.util.*;

public class Vazas {
    private static final HashMap<String, Integer> map = new HashMap<>() {{
        put("ace", 14);
        put("deuce", 2);
        put("three", 3);
        put("four", 4);
        put("five", 5);
        put("six", 6);
        put("seven", 7);
        put("eight", 8);
        put("nine", 9);
        put("ten", 10);
        put("jack", 11);
        put("queen", 12);
        put("king", 13);
        put("diamond",0);
        put("club",1);
        put("spade",2);
        put("heart",3);

    }};
    boolean ascending = true;
    Scanner keyboard = new Scanner(System.in);
    ArrayList<Player> players;
    ArrayList<Player> rondaordem;
    public Vazas(ArrayList<Player> p){
        this.players = p;

        for(Player player : players){
            player.resetStrikes();
        }
    }

    public boolean isGameOver(){
        for(Player player : players){
            if(player.getStrikes()==3){
                System.out.println(player.getName() + " perdeu !");
                return true;
            }
        }
        return false;
    }

    public void play(){

        int cardlimit = 5;
        int nofcards= 1;
        int noplayed = 0;
        while(!isGameOver()){
            for(Player p : players){
                DeckOfCard deck = new DeckOfCard();
                ArrayList<Card> cards = deck.getCards();
                p.clearCards();
                p.resetPoints();
                System.out.println(p.getName() + ": ");
                for(int i = 0;i < nofcards;i++){
                    p.addCard(cards.get(0));
                    cards.get(0).toString();
                    cards.remove(0);
                }
                int ans = -1;
                while(ans < 0 || ans >nofcards){
                    System.out.println("Qual a aposta " + p.getName() + "? Entre 0 e " + nofcards);
                    ans = keyboard.nextInt();
                }
                System.out.println(p.getName() + " apostou que ganhava" + ans + "maos");
                p.setNoaposta(ans);
                //recolher apostas de todos os jogadores

            }
            //ronda
            rondaordem.addAll(players);
            while(noplayed < nofcards){
                ArrayList<Card> cardsbyorder = new ArrayList<Card>();
                for(Player p : rondaordem){
                    Random rand = new Random();
                    int randInt = rand.nextInt( p.getCards().size()); //tirar random so para testes
                    cardsbyorder.add(p.getCards().get(randInt));
                    p.removeCard(randInt);



                }
                Player winner = compareCards(cardsbyorder,rondaordem);
                if(winner!=null){
                    winner.addPoints();
                    NextToStart(winner);
                    //mudar quem joga em primeiro a seguir

                }


                noplayed++;
            }
            for(Player p : players){
                if(p.getPoints() != p.getNoaposta()){p.addStrike();}
            }

            noplayed = 0;
            rondaordem.clear();

            //jogo mesmo
            shiftPlayers(); //shiftar ordem dos jogadores

            nofcards = nextNoOfCards(nofcards,cardlimit);// numero de cartas para  aproxima ronda




        }

    }

    public void NextToStart(Player p){
        while(rondaordem.get(0)!=p){
            Collections.rotate(rondaordem,-1);
        }
    }

    public int nextNoOfCards(int currentno , int limit){
        int no = currentno;
        if(no == limit){ascending = false;}
        if(no == 1){ascending=true;}
        if(ascending){
            no+=1;
        }else{
            no-=1;
        }

        return no;
    }

    public void shiftPlayers(){
        Collections.rotate(players,-1);

    }

    public Player compareCards(ArrayList<Card> cards , ArrayList<Player> p){ // cartas jogadas por ordem do jogador
        int idxWinner = -1 ;
        for(int i = 1 ; i < cards.size();i++){
            if(map.get(cards.get(i).rank())>map.get(cards.get(i-1).rank())){
                idxWinner = i;
            }else if(map.get(cards.get(i).rank())==map.get(cards.get(i-1).rank())){
                if(cards.get(i).rank()=="ace"){
                    if(map.get(cards.get(i).suit())>map.get(cards.get(i-1).suit())){
                        idxWinner = i;
                    }else{
                        idxWinner = i-1;
                    }
                }else{
                    idxWinner = -1;
                }

            }

        }
       if(idxWinner == -1) return null;
       return p.get(idxWinner);
    }



}
