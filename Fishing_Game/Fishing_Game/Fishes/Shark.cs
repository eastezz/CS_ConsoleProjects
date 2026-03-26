using System;

public class Shark : IFishable
{
	private const int FishValue = 174;
    public int Value { get; set; }
    public int Weight { get; set; }
    public String GetName() => "Shark";

    public void SetValue()
    {
        SetWeight();
        Value = Weight * FishValue;
    }

    public void SetWeight() => Weight = Random.Shared.Next(680, 1100);

}
