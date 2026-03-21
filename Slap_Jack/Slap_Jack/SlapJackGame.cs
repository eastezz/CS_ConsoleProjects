using System;
using System.Collections.Generic;

public class SlapJackGame
{
	private SlapJackConstructor constructor;
	public SlapJackGame()
	{
		constructor = new SlapJackConstructor();
	}

	public void GameStart()
	{
		List<string> playerOne = new List<string>();
		List<string> playerTwo = new List<string>();
		List<string> board = new List<string>();
		bool cardChanger = true;
		bool isYourTurn = true;
		char pressedLetter;
		bool firstIsWinner = false;
		bool secondIsWinner = false;
		foreach(string card in constructor.CreateDeck())
		{
			if(cardChanger)
			{
				playerOne.Add(card);
				cardChanger = !cardChanger;
			}
			else
			{
				playerTwo.Add(card);
				cardChanger = !cardChanger;
			}
		}

		while (!(playerOne.Count == 56) || !(playerTwo.Count == 56) || !firstIsWinner || !secondIsWinner)
		{

			Console.WriteLine($"Board: {board.Count} cards\n" +
							  $"Player One: {playerOne.Count} cards" +
							  $"\nPlayer Two: {playerTwo.Count} cards");

			if ((isYourTurn && playerOne.Count != 0) || (!isYourTurn && playerTwo.Count == 0))
			{
				board.Add(playerOne.First());
				playerOne.Remove(playerOne.First());
				isYourTurn = !isYourTurn;
			}
			else if ((!isYourTurn && playerTwo.Count != 0) || (isYourTurn && playerOne.Count == 0))
			{
				board.Add(playerTwo.First());
				playerTwo.Remove(playerTwo.First());
				isYourTurn = !isYourTurn;
			}

			Console.WriteLine($"Card played: {board.Last()}");
			pressedLetter = Console.ReadLine()[0];

			try
			{
				if (pressedLetter.Equals('n'))
				{
					continue;
				}
				else if (pressedLetter.Equals('a'))
				{
					if (board.Last().Equals("Jack"))
					{
						playerOne.AddRange(board);
						board.RemoveRange(0, board.Count);
						continue;
					}
					else if (!board.Last().Equals("Jack") && playerOne.Count != 0)
					{
						playerTwo.Add(playerOne.First());
						playerOne.Remove(playerOne.First());
						isYourTurn = false;
						continue;
					}
					else
					{
						secondIsWinner = true;
					}
				}
				else if (pressedLetter.Equals('l'))
				{
					if (board.Last().Equals("Jack"))
					{
						playerTwo.AddRange(board);
						board.RemoveRange(0, board.Count);
						continue;
					}
					else if (!board.Last().Equals("Jack") && playerTwo.Count != 0)
					{
						playerOne.Add(playerTwo.First());
						playerTwo.Remove(playerTwo.First());
						isYourTurn = true;
						continue;
					}
					else
					{
						firstIsWinner = true;
					}
				}
				else
				{
					throw new InvalidDataException();
				}
			}
			catch(InvalidDataException)
			{
                Console.WriteLine("invalid");
				continue;
            }
		}
		if(firstIsWinner || playerOne.Count == 56)
		{
			Console.WriteLine("Player One WON the game!");
		}
		else if(secondIsWinner || playerTwo.Count == 56)
		{
            Console.WriteLine("Player Two WON the game!");
        }
		else
		{
			Console.WriteLine("draw");
		}

		

	}
}
