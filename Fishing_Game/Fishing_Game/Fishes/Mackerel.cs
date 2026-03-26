using System;

public class Mackerel : IFishable
{
    private const int FishValue = 60;
    public int Value { get; set; }
    public int Weight { get; set; }
    public String GetName() => "Mackerel";

    public void SetValue()
    {
        SetWeight();
        Value = Weight * FishValue;
    }

    public void SetWeight() => Weight = Random.Shared.Next(10, 60);
}

