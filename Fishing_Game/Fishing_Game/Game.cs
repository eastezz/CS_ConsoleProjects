using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

// Class with the main game logic
public class Game
{
	private Player player;
	private Inventory inventory;
	private Pond pond;
	private UI ConsoleUI;
    private int SpotCounter = -1;
    public Game()
	{
		this.player = new Player();
		this.inventory = new Inventory();
		this.pond = new Pond();
		this.ConsoleUI = new UI();
	}

	// Starting the game
	public void GameStart()
	{ 	
		ConsoleUI.LogIntro();

		pond.CreatePond();

		while (!IsWeightOrSpotLimit())
		{
			ConsoleUI.LogPond(pond);

			(int row, int col) = ConsoleUI.LogCoordinates(pond);

			if (!pond.IsFished(row, col))
			{
				IFishable loot = pond.fish(row, col);

				// Set weight and value of the fish
				loot.SetWeight();
				loot.SetValue();

				// Consume total score and weight
				player.AddScore(loot.Value);
				inventory.AddWeight(loot.Weight);
				ConsoleUI.LogFish(loot, player, inventory);
			}
			else
			{
				ConsoleUI.LogFishedSlot();
				continue;
			}
		}

		ConsoleUI.LogEnd(player);
	}

	// End game condition
	public bool IsWeightOrSpotLimit()
	{
        SpotCounter++;
        return inventory.GetMaxWeight() < inventory.TotalWeight || SpotCounter >= pond.GetPondSpotAmount();
	}
}
