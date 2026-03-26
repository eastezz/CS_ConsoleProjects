using System;

public class Shark : IFishable
{
	private const int FishValue = 174;
    public int Value { get; set; }
    public int Weight { get; set; }

    public Shark()
    {
        Weight = Random.Shared.Next(680, 1100);
        Value = Weight * FishValue;
    }
    public String GetName() => "Shark";
}
