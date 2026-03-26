using System;
using System.Collections;
using System.Collections.Generic;
public class Pond
{
	private const int PondScale = 4;
	private const int PondSpots = 16;
	private List<List<IFishable>> Fishables;
	private List<List<char>> pond;
	public Pond()
	{
		this.Fishables = new List<List<IFishable>>();
		this.pond = new List<List<char>>();
	}

	// Creates two lists 4x4, one for the visual interface of the spot, another for fish content at the same spot
	public void CreatePond()
	{
		Fishables.Clear();
		pond.Clear();

		List<IFishable> Fish = new List<IFishable> { new Boot(), new Can(), new Mackerel(), new Shark(), new Salmon(), new Sardine(), new Trout(), new Tuna() };
		for(int i = 0; i < PondScale; i++)
		{
            IFishable RandomFish = Fish[Random.Shared.Next(0, 8)];
            Fishables.Add(new List<IFishable> { RandomFish, RandomFish, RandomFish, RandomFish });

            pond.Add(new List<char> {'▓', '▓', '▓', '▓'});
		}
	}

	// Returns visual interface
	public IReadOnlyList<List<char>> GetPond() => this.pond;

	// Marks the spot as already fished and returns the fished fish
	public IFishable fish(int row, int col)
	{
		pond[row - 1][col - 1] = '░';

		return Fishables[row - 1][col - 1];
	}

	// Checks if the spot is already marked
    public bool IsFished(int row, int col) => pond[row - 1][col - 1].Equals('░');

	// Returns total amount of spots

	public int GetPondSpotAmount() => PondSpots;

	// Retuns the scale of the pond
	public int GetPondScale() => PondScale;

	
}
