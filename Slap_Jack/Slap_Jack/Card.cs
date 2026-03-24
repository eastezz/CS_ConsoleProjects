// Enumerator that contains all kinds of available cards 
public enum Rank { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
public enum Suit { Hearts, Diamonds, Clubs, Spades }

public class Card
{
    public Rank rank { get; }
    public Suit suit { get; }
    public Card(Rank rank, Suit suit)
    {
        this.rank = rank;
        this.suit = suit;
    }
}