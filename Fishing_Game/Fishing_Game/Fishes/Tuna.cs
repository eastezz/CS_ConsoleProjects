using System;

public class Tuna : IFishable
{
    private const int FishValue = 102;
    public String GetName()
    {
        return "Tuna";
    }

    public int GetValue()
    {
        return GetWeight() * FishValue;
    }

    public int GetWeight()
    {
        return Random.Shared.Next(450, 900);
    }
}
