using System;

public class Can : IFishable
{
    private const int FishValue = -13;
    public String GetName()
    {
        return "Can";
    }

    public int GetValue()
    {
        return GetWeight() * FishValue;
    }

    public int GetWeight()
    {
        return Random.Shared.Next(1, 5);
    }
}
