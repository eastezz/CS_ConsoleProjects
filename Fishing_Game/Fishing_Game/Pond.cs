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

	public void CreatePond()
	{
		Fishables.Clear();
		pond.Clear();

		List<IFishable> Fish = new List<IFishable> { new Boot(), new Can(), new Mackerel(), new Salmon(), new Sardine(), new Trout(), new Tuna() };
		for(int i = 0; i < PondScale; i++)
		{
            IFishable RandomFish = Fish[Random.Shared.Next(0, 8)];
            Fishables.Add(new List<IFishable> { RandomFish, RandomFish, RandomFish, RandomFish });

            pond.Add(new List<char> {'▓', '▓', '▓', '▓'});
		}
	}

	public IReadOnlyList<List<char>> GetPond() => this.pond;

	public IFishable fish(int row, int col)
	{
		pond[row - 1][col - 1] = '░';

		return Fishables[row - 1][col - 1];
	}
    public bool IsFished(int row, int col) => pond[row - 1][col - 1].Equals('░');

	public int GetPondSpotAmount() => PondSpots;

	public int GetPondScale() => PondScale;

	
}
