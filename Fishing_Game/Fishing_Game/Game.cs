using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

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
				player.AddScore(loot.GetValue());
				inventory.AddWeight(loot.GetWeight());
				ConsoleUI.LogFish(loot, player, inventory);
			}
			else
			{
				Console.WriteLine("This slot was already fished");
				continue;
			}
		}

		ConsoleUI.LogEnd(player);
	}

	public bool IsWeightOrSpotLimit()
	{
        SpotCounter++;
        Console.WriteLine(SpotCounter);
        return inventory.GetMaxWeight() < inventory.TotalWeight || SpotCounter >= pond.GetPondSpotAmount();
	}
}
