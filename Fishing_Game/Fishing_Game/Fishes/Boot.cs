using System;

public class Boot : IFishable
{
    private const int FishValue = -32;
    public int Value { get; set; }
    public int Weight { get; set; }
    public String GetName() => "Boot";

    public void SetValue()
    {
        SetWeight();
        Value = Weight * FishValue;
    }

    public void SetWeight() => Weight = Random.Shared.Next(1, 2);
}
