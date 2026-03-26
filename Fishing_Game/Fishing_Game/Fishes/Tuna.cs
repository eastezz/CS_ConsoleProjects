using System;

public class Tuna : IFishable
{
    private const int FishValue = 102;
    public int Value { get; set; }
    public int Weight { get; set; }

    public Tuna()
    {
        Weight = Random.Shared.Next(450, 900);
        Value = Weight * FishValue;
    }
    public String GetName() => "Tuna";
    
}
