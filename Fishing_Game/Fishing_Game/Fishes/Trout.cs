using System;

public class Trout : IFishable
{
    private const int FishValue = 52;
    public String GetName()
    {
        return "Trout";
    }

    public int GetValue()
    {
        return GetWeight() * FishValue;
    }

    public int GetWeight()
    {
        return Random.Shared.Next(6, 15);
    }
}
