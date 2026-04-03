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

	public void ReadFile()
	{
		string? line;

		using (StreamReader sr = new StreamReader(FileName))
		{
			line = sr.ReadLine();
			string[] parts = line.Split(",");

			// Working with the first line
			CheckFirstLineLength(parts.Length);

			string BuildingName = parts[0];
			string OwnerName = parts[1];
			string OwnerType = parts[2];

			IOwner owner;

			owner = CheckOwnerType(OwnerType, OwnerName);

			int row = CheckCoordinatesType(parts[3]);
			int col = CheckCoordinatesType(parts[4]);

			// Creating the new building
			this.NewBuilding = new Building<IOwner>(BuildingName, owner, row, col);

			// Working with other lines
			while ((line = sr.ReadLine()) != null)
			{
				parts = line.Split(",");

				CheckOtherLinesLength(parts.Length);

				string RoomName = parts[2];
				row = CheckCoordinatesType(parts[0]);
				col = CheckCoordinatesType(parts[1]);

				NewBuilding.AddRoom(row, col, new Room(RoomName));

			}
		}
	}

	// Checks whether owner type exists or not 
	public IOwner CheckOwnerType(string OwnerType, string OwnerName)
	{
        switch (OwnerType)
        {
            case "Person":
                return new Person(OwnerName);

            case "Company":
				return new Company(OwnerName);

            case "Organization":
				return new Organization(OwnerName);

            default:
                throw new InvalidFileFormatException("Unknown Owner Type!");

        }
    }

	// Checks coordinates correctness
	public int CheckCoordinatesType(string input)
	{
		if(!int.TryParse(input, out int output))
		{
			throw new InvalidFileFormatException("Wrong Coordinates Type");
		}
		return output;
	}


	// Checks the length of the first line
	public void CheckFirstLineLength(int length)
	{
		if (length != 5) throw new InvalidFileFormatException("The file has wrong format!");
	}

	// Checks the length of the second line
	public void CheckOtherLinesLength(int length)
	{
        if (length != 3) throw new InvalidFileFormatException("The file has wrong format!");
    }


}
