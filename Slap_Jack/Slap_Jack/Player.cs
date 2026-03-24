using System;
using System.Collections.Generic;

// Saves player cards state during the game
public class Player
{
	private List<Cards> personalStack;
	private char keyboardKey;  
	public Player(char keyboardKey)
	{
		this.personalStack = new List<Cards>();
		this.keyboardKey = keyboardKey;
	}

	// Returns the List of the player cards 
	public IReadOnlyList<Cards> GetPersonalStack() => personalStack;


	// Returns the key, binded to the player 
	public char GetPlayerKey() => keyboardKey;

	// Adds a new card to the player`s stack
	public void AddCard(Cards card) => personalStack.Add(card);

	// Removes the card from the player`s stack
	public void RemoveCard(Cards card) => personalStack.Remove(card);

	// Adds a range of cards to the playes`s stack
	public void AddRangeOffCards(List<Cards> cards) => personalStack.AddRange(cards);

	// Saves the card played, removes and returns it
	public Cards PlayTopCard()
	{
		var card = personalStack[0];
		personalStack.RemoveAt(0);
		return card;
	}


}
