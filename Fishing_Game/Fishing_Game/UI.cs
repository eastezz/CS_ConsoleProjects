using System;

// Input/Output responsibility
public class UI
{
	// Logs the geme start
	public void LogIntro()
	{
		Console.WriteLine("--------- Fishing Game ---------");
		Console.WriteLine("Welcome to the pond. Good luck!\n");
	}

	// Logs the pond state
	public void LogPond(Pond pond)
	{
		foreach(List<char> i in pond.GetPond())
		{
			Console.WriteLine(string.Join(" ", i) + "\n");
		}
	}

	// Logs the input and apropriate messege for coordinates and returns the tuple of (row, column)
	public (int, int) LogCoordinates(Pond pond)
	{
		int row = -1; 
		int col = -1;
		bool IsCorrect = false;
		while (!IsCorrect)
		{
			Console.Write("Select an X-Coordinate: ");
			if (!int.TryParse(Console.ReadLine(), out row) || row > pond.GetPondScale() || row < 1)
			{
				Console.WriteLine("\nInvalid coordinates\n");
				continue;
			}

			Console.Write("Select an Y-Coordinate: ");
			if (!int.TryParse(Console.ReadLine(), out col) || col > pond.GetPondScale() || col < 1)
			{
				Console.WriteLine("\nInvalid coordinates\n");
				continue;
			}

			IsCorrect = true;
		}
		return (row, col);
    }

	// Logs that the spot was already fished
	public void LogFishedSlot()
	{
        Console.WriteLine("\nThis slot was already fished\n");
    }

	// Logs the loot was fished
	public void LogFish(IFishable fish, Player player, Inventory inventory)
	{
		Console.WriteLine($"\nYou fished a {fish.GetName()}");
		Console.WriteLine($"Weight: {fish.Weight}");
		Console.WriteLine($"Value: {fish.Value}");
		Console.WriteLine($"Your current score is: {player.score}");
		Console.WriteLine($"The total weight is: {inventory.TotalWeight}\n");
	}

	// Logs the end of the game
	public void LogEnd(Player player)
	{
		Console.WriteLine($"Game over! Your score is {player.score}");
	}
}
