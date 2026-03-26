using System;

public class Boot : IFishable
{
    private const int FishValue = -32;
    public String GetName()
    {
        return "Boot";
    }

    public int GetValue()
    {
        return GetWeight() * FishValue;
    }

    public int GetWeight()
    {
        return Random.Shared.Next(1, 2);
    }
}
