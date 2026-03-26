using System;

public class Salmon : IFishable
{
    private const int FishValue = 74;
    public int Value { get; set; }
    public int Weight { get; set; }

    public Salmon()
    {
        Weight = Random.Shared.Next(10, 30);
        Value = Weight * FishValue;
    }
    public String GetName() => "Salmon";
}
