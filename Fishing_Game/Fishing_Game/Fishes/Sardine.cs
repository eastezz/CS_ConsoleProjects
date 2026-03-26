using System;

public class Sardine : IFishable
{
    private const int FishValue = 5;
    public int Value { get; set; }
    public int Weight { get; set; }
    public String GetName() => "Sardine";

    public void SetValue()
    {
        SetWeight();
        Value = Weight * FishValue;
    }

    public void SetWeight() => Weight = Random.Shared.Next(1, 2);
}
