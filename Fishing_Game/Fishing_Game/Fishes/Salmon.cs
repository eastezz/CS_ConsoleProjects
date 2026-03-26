using System;

public class Salmon : IFishable
{
    private const int FishValue = 74;
    public String GetName()
    {
        return "Salmon";
    }

    public int GetValue()
    {
        return GetWeight() * FishValue;
    }

    public int GetWeight()
    {
        return Random.Shared.Next(10, 30);
    }
}
