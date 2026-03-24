using System;
using System.Collections.Generic;

// Manages operations on the start deck
public class Deck
{
    private List<Cards> deck;

    public Deck()
    {
        this.deck = new List<Cards>();
    }

    // Creates a new deck of 52 cards and shuffles it
    public void CreateDeck()
    {
        List<Cards> deck = new List<Cards>();
        for (int i = 0; i < 4; i++)
        {
            deck.AddRange(Enum.GetValues(typeof(Cards)).Cast<Cards>());
        }
        this.deck = deck.Shuffle().ToList();
    }

    // Returns the final deck
    public IReadOnlyList<Cards> GetDeck()
    {
        return deck;
    }
}