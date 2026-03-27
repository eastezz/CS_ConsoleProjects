using System;

public class Person : IOwner
{
	public string Name { get; set; }
	public Person(string Name)
	{
		this.Name = Name;
	}
}
