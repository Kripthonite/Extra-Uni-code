public record Card(String suit, String rank) {

    @Override
    public String toString() {
        return "Card [suit=" + suit + ", rank=" + rank + "]";
    }
}
