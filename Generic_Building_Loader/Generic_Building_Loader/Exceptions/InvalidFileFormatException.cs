using System;

public class InvalidFileFormatException : Exception
{
	public InvalidFileFormatException(string message) : base(message)
	{
	}
}
