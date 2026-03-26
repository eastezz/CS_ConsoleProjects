using System;

// Interface that implemented by all kinds of fish
public interface IFishable
{
    public int Value { get; set; }
    public int Weight { get; set; }
    public string GetName();
    public void SetValue();
    public void SetWeight();
}
