using System;

// Inventory state responsibility
public class Inventory
{
	// The limit of the weight
	private const int MaxWeight = 1000;
	public int TotalWeight { get; set; }

	// Adds weight to your inventory during fishing
	public void AddWeight(int amount) => TotalWeight += amount;

	// Returns the limit
	public int GetMaxWeight() => MaxWeight;
}
