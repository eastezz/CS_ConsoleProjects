using System;
using System.Collections.Generic;
public class TicTacToeBoard
{
	private List<char> board;
	public TicTacToeBoard()
	{
		this.board = new List<char>();
	}

	// Fills our future board with an '_' symbols
	public void FillTheBoard()
	{
		for(int i = 0; i < 9; i++)
		{
			this.board.Add('_');
		}
	}

	// Returns the board as an List value
	public List<char> GetBoard()
	{
		return this.board;
	}
}
