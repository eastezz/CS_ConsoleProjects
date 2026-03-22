using System;
using System.Collections.Generic;

// Saves board state during the game
public class Board
{
	private List<Cards> cardStack;
	public Board()
	{
		this.cardStack = new List<Cards>();
	}

	// Returns the List of cards on the board
 	public List<Cards> GetBoardCardStack()
	{
		return this.cardStack;
	}
}
