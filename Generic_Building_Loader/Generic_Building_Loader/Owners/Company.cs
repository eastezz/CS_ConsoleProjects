using System;
using System.Diagnostics;

public class Company : IOwner
{
	public string Name { get; set; }
	public Company(string Name)
	{
		this.Name = Name;
	}
}
