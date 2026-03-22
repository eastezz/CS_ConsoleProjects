using System;
using System.Collections.Generic;

// Saves player cards state during the game
public class Player
{
	private List<Cards> personalStack;
	private char keyboardKey;  
	public Player(char keyboardKey)
	{
		this.personalStack = new List<Cards>();
		this.keyboardKey = keyboardKey;
	}

	// Returns the List of the player cards 
	public List<Cards> GetPersonalStack()
	{
		return this.personalStack;
	}

	// Returns the key, binded to the player 
	public char GetPlayerKey()
	{
		return this.keyboardKey;
	}
}
