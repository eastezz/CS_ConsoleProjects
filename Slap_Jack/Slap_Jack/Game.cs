using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// Game logic responsibility
public class Game
{
	private const int maxCards = 52;
	private Deck deck;
	private Player playerOne;
	private Player playerTwo;
	private Board board;
	private UI consoleUI;
	private bool playerTurn;

	public Game()
	{
		this.deck = new Deck();
		this.playerOne = new Player('a');
		this.playerTwo = new Player('l');
		this.board = new Board();
		this.consoleUI = new UI(board, playerOne, playerTwo);
	}

	// Creates a new deck using class DeckManager and divides equally between two players
    private void InitGame()
	{
		deck.CreateDeck();

		// Each time switches to simulate the dealing of cards 
		bool orderSwitcher = true;
		foreach(Cards card in deck.GetDeck())
		{
			if (orderSwitcher)
			{
				playerOne.AddCard(card);
			}
			else
			{
				playerTwo.AddCard(card);
			}
			orderSwitcher = !orderSwitcher;
		}
		// Defines which player place the card on the board
		playerTurn = true;
	}

	// Difines who place the next card on the board
	private void PlayNextCard()
	{
		Player currentPlayer;

		// Check the rules
		if((playerTurn && IsNotEmpty(playerOne)) || !IsNotEmpty(playerTwo))
		{
			currentPlayer = playerOne;
		}
		else
		{
			currentPlayer = playerTwo;
		}
		playerTurn = !playerTurn;

		//Saves the card played and removes it from player stack
		Cards cardPlayed = currentPlayer.PlayTopCard();

        // Adds the card to the board
        board.AddCard(cardPlayed);

		//Outputs the card played
		consoleUI.LogNextCard(cardPlayed);
    }

	// Checks whether the player stack is empty
	private bool IsNotEmpty(Player player)
	{
		return player.GetPersonalStack().Any();
	}

    // Checks whether the endgame statements compiled
    private bool IsGameOver()
	{
		return (!playerOne.GetPersonalStack().Any() && !playerTwo.GetPersonalStack().Any()) || playerOne.GetPersonalStack().Count == maxCards || playerTwo.GetPersonalStack().Count == maxCards;

    }

	public void GameStart()
	{
		InitGame();

		while(!IsGameOver())
		{
			consoleUI.LogCardCount();
			PlayNextCard();
			var lastCard = board.GetBoardCardStack().Last();

			bool isJack = lastCard is Cards.Jack;

			char playerInput = consoleUI.GetInput();
			
			Player playerWhoSlaps;
			Player playerWhoNotSlaps;

			// Defines who slaps
			if(playerInput.Equals(playerOne.GetPlayerKey()))
			{
				playerWhoSlaps = playerOne;
				playerWhoNotSlaps = playerTwo;
			}
			else if(playerInput.Equals(playerTwo.GetPlayerKey()))
			{
				playerWhoSlaps = playerTwo;
				playerWhoNotSlaps = playerOne;
			}

			// No one slaped
			else
			{
				continue;
			}

			if(isJack)
			{
				playerWhoSlaps.AddRangeOffCards(board.CopyBoard());
				board.ClearBoard();
			}
			// Gives the card to the another player if wrong slaps
			else if(!isJack && IsNotEmpty(playerWhoSlaps))
			{
				playerWhoNotSlaps.AddCard(playerWhoSlaps.GetPersonalStack().Last());
				playerWhoSlaps.RemoveCard(playerWhoSlaps.GetPersonalStack().Last());
			}
			// Loose if wrong slaps and the player stack was empty
			else
			{
				break;
			}

		}

		// Defines the winner 
		if(playerOne.GetPersonalStack().Any())
		{
			consoleUI.LogWinner(playerOne);
		}
		else if(playerTwo.GetPersonalStack().Any())
		{
			consoleUI.LogWinner(playerTwo);
		}
		else
		{
			consoleUI.LogWinner(null!);
		}
	}


}
