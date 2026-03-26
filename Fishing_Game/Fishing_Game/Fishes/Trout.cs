using System;

public class Trout : IFishable
{
    private const int FishValue = 52;
    public int Value { get; set; }
    public int Weight { get; set; }
    public String GetName() => "Trout";

    public void SetValue()
    {
        SetWeight();
        Value = Weight * FishValue;
    }

    public void SetWeight() => Weight = Random.Shared.Next(6, 15);
}
