using System;

public class Trout : IFishable
{
    private const int FishValue = 52;
    public int Value { get; set; }
    public int Weight { get; set; }
    public Trout()
    {
        Weight = Random.Shared.Next(6, 15);
        Value = Weight * FishValue;
    }
    public String GetName() => "Trout";
}
