using System;

public class Mackerel : IFishable
{
    private const int FishValue = 60;
    public int Value { get; set; }
    public int Weight { get; set; }

    public Mackerel()
    {
        Weight = Random.Shared.Next(10, 60);
        Value = Weight * FishValue;
    }
    public String GetName() => "Mackerel";
}

