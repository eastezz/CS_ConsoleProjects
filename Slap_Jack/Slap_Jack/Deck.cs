using System;
using System.Collections.Generic;

// Manages operations on the start deck
public class Deck
{
    private List<Card> deck;

    public Deck()
    {
        this.deck = new List<Card>();
    }

    // Creates a new deck of 52 cards and shuffles it
    public void CreateDeck()
    {
        foreach(Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                deck.Add(new Card(rank, suit));
            }
        }
        deck = deck.Shuffle().ToList();
    }

    // Returns the final deck
    public IReadOnlyList<Card> GetDeck()
    {
        return deck;
    }
}