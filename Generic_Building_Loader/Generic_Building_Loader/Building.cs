using System;

public class Building <T : IOwner>
{
	public string BuildingName { get; set; }
	public T Owner { get; set; }
	public string[,] Rooms { get; set; }
	public building(string BuildingName, T Owner, int row, int col)
	{
		this.BuildingName = BuildingName;
		this.Owner = Owner;
		this.Rooms = new string[row][col]
	}

	public void AddRoom(int row, int col, Room NewRoom)
	{
		try
		{
			if (Rooms[row][col].Equals(null))
			{
				Rooms[row, col] = NewRoom;
			}
			else throw DuplicateRoomException("The cell is already occupied");
		}
		catch(IndexOutOfRangeException)
		{
			throw InvalidFileFormatException("Invalid file format");
		}
	}
}
