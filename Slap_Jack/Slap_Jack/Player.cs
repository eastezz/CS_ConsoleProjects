using System;
using System.Collections.Generic;

// Saves player cards state during the game
public class Player
{
	private List<Card> personalStack;
	public char keyboardKey { get; }
	public Player(char keyboardKey)
	{
		this.personalStack = new List<Card>();
		this.keyboardKey = keyboardKey;
	}

	// Returns the List of the player cards 
	public IReadOnlyList<Card> GetPersonalStack() => personalStack;


	// Returns the key, binded to the player 
	public char GetPlayerKey() => keyboardKey;

	// Adds a new card to the player`s stack
	public void AddCard(Card card) => personalStack.Add(card);

	// Removes the card from the player`s stack
	public void RemoveCard(int index) => personalStack.RemoveAt(index);

	// Adds a range of cards to the playes`s stack
	public void AddRangeOffCards(List<Card> cards) => personalStack.AddRange(cards);

	// Saves the card played, removes and returns it
	public Card PlayTopCard()
	{
		var card = personalStack[0];
		personalStack.RemoveAt(0);
		return card;
	}
}
