using System;
using System.Collections;
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
        bool isYourTurn = true;
		bool isRightPosition;
		char player = ' ';
		int position = 0;

		// Set of occupied positions
		HashSet<int> isOccupied = new HashSet<int>();
	
		while (board.GetBoard().Contains('_'))
		{
            // Using for deciding whose turn is next
            isRightPosition = false;
			player = isYourTurn ? 'X' : 'Y';

			PrintBoard();

			while (!isRightPosition)
			{
				Console.WriteLine($"Current turn: {player}");
				Console.Write("Where do you want to place next? ");

                // Checks weather the user entered an integer type as a position
                if (!int.TryParse(Console.ReadLine(), out position))
				{
					Console.WriteLine("invalid");
					continue;
				}

				// Checks weather the position was already used or is out of bounds
				if (position < 1 || position > 9 || isOccupied.Contains(position))
				{
					Console.WriteLine("invalid");
					continue;
				}

				isRightPosition = true;
			}

			// Making the position occupied
			isOccupied.Add(position);

			// Fill the board with player moves
			board.GetBoard()[position - 1] = player;

			// Toggle to change the players turn
			isYourTurn = !isYourTurn;

			// Win condition
			if (CheckWin())
			{
				PrintBoard();
				Console.WriteLine($"The winner is: {player}");
				return;
			}
		}

		// Draw
		Console.WriteLine("draw");

	}

    // Prints the board
    public void PrintBoard()
	{
        int lineCounter = 2;
        foreach (char i in board.GetBoard())
        {
            Console.Write(string.Join("", i) + " ");
            if (lineCounter < 1)
            {
                Console.WriteLine();
                lineCounter = 3;
            }
            lineCounter--;
        }
    }

	public bool CheckWin()
	{
		List<char> b = board.GetBoard();

		// Check gorizontal 
		for (int i = 0; i < 9; i+=3)
		{
			if (b[i].Equals(b[i + 1]) && b[i].Equals(b[i + 2]) && !b[i].Equals('_'))
			{
				return true;
			}
		}

		// Check vertical
		for (int i = 0; i < 3; i++)
		{
			if (b[i].Equals(b[i + 3]) && b[i].Equals(b[i + 6]) && !b[i].Equals('_'))
			{
				return true;
			}
		}

		// Check first diagonal \
		if (b[0].Equals(b[4]) && b[0].Equals(b[8]) && !b[0].Equals('_'))
		{
			return true;
		}

		// Check second diagonal /
		if (b[2].Equals(b[4]) && b[2].Equals(b[6]) && !b[2].Equals('_'))
		{
			return true;
		}

		return false;

	}
}
