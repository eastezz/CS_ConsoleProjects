using System;

public class Building<T> where T : IOwner
{
	public string BuildingName { get; set; }
	public T Owner { get; set; }
	public Room[,] Rooms { get; set; }

	public Building(string BuildingName, T Owner, int row, int col)
	{
		this.BuildingName = BuildingName;
		this.Owner = Owner;
		this.Rooms = new Room[row, col];
	}

	public void AddRoom(int row, int col, Room NewRoom)
	{
		if (row < 0 || row >= Rooms.GetLength(0) || col < 0 || col >= Rooms.GetLength(1))
		{
			throw new InvalidFileFormatException($"Wrong Coordinates! {(row,col)}");
		}
		else if (Rooms[row, col] != null)
		{
			throw new DuplicateRoomException($"The cell is aready occupied! {(row, col)}");
		}
		else
		{
			Rooms[row, col] = NewRoom;
		}
	}

}
