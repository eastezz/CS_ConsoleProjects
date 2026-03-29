using System;
using System.IO;
using System.Linq.Expressions;

public class BuildingLoader
{
	public Building<IOwner> NewBuilding { get; private set; }
	private string FileName;
	public BuildingLoader(string FileName)
	{
		this.FileName = FileName;
	}

	public void ReadTheFile()
	{
		string line;
		try
		{
			StreamReader sr = new StreamReader(FileName);

			line = sr.ReadLine();
			string[] parts = line.Split(",");

			string BuildingName = parts[0];
			string OwnerName = parts[1];
			string OwnerType = parts[2];

			IOwner owner;
			switch(OwnerType)
			{
				case "Person":
					owner = new Person(OwnerName);
					break;

				case "Company":
					owner = new Company(OwnerName);
					break;

				case "Organization":
					owner = new Organization(OwnerName);
					break;

				default:
					throw new InvalidFileFormatException("Unknown Owner Type!");
					
			}

			int row = int.Parse(parts[3]);
			int col = int.Parse(parts[4]);

			this.NewBuilding = new Building<IOwner>(BuildingName, owner, row, col);
			
			while(line != null)
			{
				line = sr.ReadLine();
				parts = line.Split(",");
                string RoomName = parts[0];
				row = int.Parse(parts[1]);
				col = int.Parse(parts[2]);

				NewBuilding.AddRoom(row, col, new Room(RoomName));
			}
		}
		catch(Exception e)
		{
			Console.WriteLine("Exception");
		}
	}
}
