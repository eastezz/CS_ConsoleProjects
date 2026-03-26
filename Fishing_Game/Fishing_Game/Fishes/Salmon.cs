using System;

public class Salmon : IFishable
{
    private const int FishValue = 74;
    public int Value { get; set; }
    public int Weight { get; set; }
    public String GetName() => "Salmon";

    public void SetValue()
    {
        SetWeight();
        Value = Weight * FishValue;
    }

    public void SetWeight() => Weight = Random.Shared.Next(10, 30);
}
