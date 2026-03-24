using System;
using System.Collections.Generic;
using System.Text.Json;

// Saves board state during the game
public class Board
{
	private List<Cards> cardStack;
	public Board()
	{
		this.cardStack = new List<Cards>();
	}

	// Returns the List of cards on the board
	public IReadOnlyList<Cards> GetBoardCardStack() => cardStack;

	// Adds a new card to the board stack
	public void AddCard(Cards card) => cardStack.Add(card);

	// deep copy of the board stack, don`t affect the original stack 
	    // .. slow method
	public List<Cards> CopyBoard()
	{
		var json = JsonSerializer.Serialize(cardStack);
		var deepcopy = JsonSerializer.Deserialize<List<Cards>>(json);
		return deepcopy;
	}

	// clears the board
	public void ClearBoard() => cardStack.Clear();

}
