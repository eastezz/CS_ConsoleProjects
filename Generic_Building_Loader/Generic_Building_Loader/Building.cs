using System;

public class Building<T> where T : IOwner
{
	public string BuildingName { get; private set; }
	public T Owner { get; private set; }
	public Room[,] Rooms { get;  private set; }

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
            throw new InvalidFileFormatException("Invalid coordinates");
        }

        if (Rooms[row, col] != null)
        {
            throw new DuplicateRoomException("Cell already occupied");
        }

        Rooms[row, col] = NewRoom;
    }

    public void GetBuildingInfo()
    {
        Console.WriteLine($"{BuildingName}, {Owner.Name}, {Owner}, {Rooms.GetLength(0)}, {Rooms.GetLength(1)}");
        for(int row = 0; row < Rooms.GetLength(0); row++)
        {
            for(int col = 0; col < Rooms.GetLength(1); col++)
            {
                Console.WriteLine($"{row}, {col}, {Rooms[row, col].Name}");
            }
        }
        
    }
}
