using System;

public class Mackerel : IFishable
{
    private const int FishValue = 60;
    public String GetName()
    {
        return "Mackerel";
    }

    public int GetValue()
    {
        return GetWeight() * FishValue;
    }

    public int GetWeight()
    {
        return Random.Shared.Next(10, 60);
    }
}
