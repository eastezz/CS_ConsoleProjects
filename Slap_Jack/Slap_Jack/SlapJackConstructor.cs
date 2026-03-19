using System;
using System.Collections.Generic;

public class SlapJackConstructor
{
    private List<string> deck;

    public SlapJackConstructor()
    {
        this.deck = new List<string>();
    }

    public List CreateDeck()
    {
        for (int i = 0; i < 5; i++)
        {
            foreach (var name in Enum.GetNames(typeof(Cards)))
            {
                deck.Add(name);
            }
        }
        return deck.Shuffle();

    }
}