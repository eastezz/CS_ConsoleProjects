using System;
using System.Collections.Generic;
public class TicTacToeGame
{
	private TicTacToeBoard board;
	public TicTacToeGame()
	{
		this.board = new TicTacToeBoard();
	}

	public void GameStart()
	{
		board.FillTheBoard();
		int lineCounter = 2;
		bool isYourTurn = true;
		// Prints the board
		foreach(char i in board.GetBoard())
		{
			Console.Write(string.Join(" ", i));
			if(lineCounter < 1)
			{
				Console.WriteLine();
				lineCounter = 3;
			}
			lineCounter--;
		}

		Console.WriteLine("Current turn: " + Convert.ToString(isYourTurn ? "X" : "Y"));
	}
}
