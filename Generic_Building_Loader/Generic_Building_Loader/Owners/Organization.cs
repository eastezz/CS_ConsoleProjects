using System;

public class Organization : IOwner
{
	public string Name { get; set; }
	public Organization(string Name)
	{
		this.Name = Name;
	}
}
