using System;

public class Shark : IFishable
{
	private const int FishValue = 174;
	public String GetName()
	{
		return "Shark";
	}

	public int GetValue()
	{
		return GetWeight() * FishValue;
	}

	public int GetWeight()
	{
		return Random.Shared.Next(680, 1100);
	}

}
