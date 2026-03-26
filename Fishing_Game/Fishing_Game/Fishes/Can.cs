using System;

public class Can : IFishable
{
    private const int FishValue = -13;
    public int Value { get; set; }
    public int Weight { get; set; }

    public Can()
    {
        Weight = Random.Shared.Next(1, 5);
        Value = Weight * FishValue;
    }
    public String GetName() => "Can";
}
