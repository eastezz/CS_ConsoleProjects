using System;

public class Tuna : IFishable
{
    private const int FishValue = 102;
    public int Value { get; set; }
    public int Weight { get; set; }
    public String GetName() => "Tuna";

    public void SetValue()
    {
        SetWeight();
        Value = Weight* FishValue;
    }

    public void SetWeight() => Weight = Random.Shared.Next(450, 900);
}
