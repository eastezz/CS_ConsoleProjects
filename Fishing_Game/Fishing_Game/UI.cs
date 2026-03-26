using System;

public class UI
{
	public void LogIntro()
	{
		Console.WriteLine("--------- Fishing Game ---------");
		Console.WriteLine("Welcome to the pond. Good luck!\n");
	}

	public void LogPond(Pond pond)
	{
		foreach(List<char> i in pond.GetPond())
		{
			Console.WriteLine(string.Join(" ", i) + "\n");
		}
	}

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
				Console.WriteLine("Invalid coordinates");
				continue;
			}

			Console.Write("Select an Y-Coordinate: ");
			if (!int.TryParse(Console.ReadLine(), out col) || col > pond.GetPondScale() || col < 1)
			{
				Console.WriteLine("Invalid coordinates");
				continue;
			}

			IsCorrect = true;
		}
		return (row, col);
    }

	public void LogFish(IFishable fish, Player player, Inventory inventory)
	{
		Console.WriteLine($"\nYou fished a {fish.GetName()}");
		Console.WriteLine($"Weight: {fish.GetWeight()}");
		Console.WriteLine($"Value: {fish.GetValue()}");
		Console.WriteLine($"Your current score is: {player.score}");
		Console.WriteLine($"The total weight is: {inventory.TotalWeight}\n");
	}

	public void LogEnd(Player player)
	{
		Console.WriteLine($"Game over! Your score is {player.score}");
	}
}
