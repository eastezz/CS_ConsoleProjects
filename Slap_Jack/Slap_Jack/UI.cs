using System;
using System.Collections.Generic;
using System.Reflection;

// Input/Output responsibility
public class UI
{
	private Board board;
	private Player playerOne;
	private Player playerTwo;
	public UI(Board board, Player playerOne, Player playerTwo)
	{
		this.board = board;
		this.playerOne = playerOne;
		this.playerTwo = playerTwo;
	}

	// Outputs info of the current game state
	public void LogCardCount()
	{
		Console.WriteLine($"Board: {board.GetBoardCardStack().Count} cards");
		Console.WriteLine($"Player One: {playerOne.GetPersonalStack().Count} cards");
        Console.WriteLine($"Player Two: {playerTwo.GetPersonalStack().Count} cards\n");
    }

	// Outputs the next played card
	public void LogNextCard(Cards card)
	{
		Console.WriteLine($"Card played: {card.ToString()}");
	}

	// Outputs the result of the game 
	public void LogWinner(Player winner)
	{
        if (winner == playerOne)
        {
            Console.WriteLine("Player One is winner!");
        }
        else if (winner == playerTwo)
        {
            Console.WriteLine("Player Two is winner!");
        }
        else
        {
            Console.WriteLine("draw");
        }
    }
}
