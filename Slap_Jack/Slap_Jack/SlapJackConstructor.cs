using System;
using System.Collections.Generic;

public class SlapJackConstructor
{
    private List<string> deck;

    public SlapJackConstructor()
    {
        this.deck = new List<string>();
    }

    public List<string> CreateDeck()
    {
        List<string> deck = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            foreach (var name in Enum.GetNames(typeof(Cards)))
            {
                deck.Add(name);
            }
        }
        this.deck.AddRange(deck.Shuffle());
        return this.deck;

    }
}