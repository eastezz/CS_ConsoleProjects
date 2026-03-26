using System;

public class Inventory
{
	private const int MaxWeight = 1000;
	public int TotalWeight { get; set; }

	public void AddWeight(int amount) => TotalWeight += amount;

	public int GetMaxWeight() => MaxWeight;
}
