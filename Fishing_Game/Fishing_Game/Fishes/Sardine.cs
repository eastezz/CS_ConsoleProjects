using System;

public class Sardine : IFishable
{
    private const int FishValue = 5;
    public int Value { get; set; }
    public int Weight { get; set; }

    public Sardine()
    {
        Weight = Random.Shared.Next(1, 2);
        Value = Weight * FishValue;
    }
    public String GetName() => "Sardine";

    
}
