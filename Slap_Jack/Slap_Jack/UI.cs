using System;
using System.Collections.Generic;
using System.Reflection;

// Input/Output responsibility
public class UI
{

	// Outputs info of the current game state
	public void LogCardCount(Board board, Player playerOne, Player playerTwo)
	{
		Console.WriteLine($"Board: {board.GetBoardCardStack().Count} cards");
		Console.WriteLine($"Player One: {playerOne.GetPersonalStack().Count} cards");
        Console.WriteLine($"Player Two: {playerTwo.GetPersonalStack().Count} cards\n");
    }

	// Outputs the next played card
	public void LogNextCard(Card card)
	{
		Console.WriteLine($"Card played: {card.rank.ToString()} of {card.suit.ToString()}");
	}

	// Outputs the result of the game 
	public void LogWinner(bool? whoWin)
	{
        if (whoWin == true)
        {
            Console.WriteLine("Player One is winner!");
        }
        else if (whoWin == false)
        {
            Console.WriteLine("Player Two is winner!");
        }
        else
        {
            Console.WriteLine("draw");
        }
    }

	// Returns player`s input
	public char GetInput()
	{
		string? input = Console.ReadLine();

        // Avoids null input exceptions 
        if (!string.IsNullOrEmpty(input))
		{
            char playerIput = input[0];
			return playerIput;
		}
		return ' ';
	}
}
