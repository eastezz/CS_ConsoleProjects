using System;
using System.Collections.Generic;
using System.Text.Json;

// Saves board state during the game
public class Board
{
	private List<Card> cardStack;
	public Board()
	{
		this.cardStack = new List<Card>();
	}

	// Returns the List of cards on the board
	public IReadOnlyList<Card> GetBoardCardStack() => cardStack;

	// Adds a new card to the board stack
	public void AddCard(Card card) => cardStack.Add(card);

	// deep copy of the board stack, don`t affect the original stack 
	    // .. slow method
	public List<Card> CopyBoard()
	{
		var json = JsonSerializer.Serialize(cardStack);
		var deepcopy = JsonSerializer.Deserialize<List<Card>>(json);
		return deepcopy;
	}

	// clears the board
	public void ClearBoard() => cardStack.Clear();

}
