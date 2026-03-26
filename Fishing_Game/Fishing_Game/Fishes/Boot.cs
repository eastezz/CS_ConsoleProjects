using System;

public class Boot : IFishable
{
    private const int FishValue = -32;
    public int Value { get; set; }
    public int Weight { get; set; }

    public Boot()
    {
        Weight = Random.Shared.Next(1, 2);
        Value = Weight * FishValue;
    }
    public String GetName() => "Boot";
}
