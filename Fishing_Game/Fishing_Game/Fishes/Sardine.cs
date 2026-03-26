using System;

public class Sardine : IFishable
{
    private const int FishValue = 5;
    public String GetName()
    {
        return "Sardine";
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
