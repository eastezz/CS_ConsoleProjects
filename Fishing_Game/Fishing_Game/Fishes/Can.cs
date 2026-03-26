using System;

public class Can : IFishable
{
    private const int FishValue = -13;
    public int Value { get; set; }
    public int Weight { get; set; }
    public String GetName() => "Can";

    public void SetValue()
    {
        SetWeight();
        Value = Weight * FishValue;
    }

    public void SetWeight() => Weight = Random.Shared.Next(1, 5);
}
