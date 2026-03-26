using System;

// Player state responsibility
public class Player
{
	public int Score { get; set; }

	// Adds score during the fishing
	public void AddScore(int amount) => Score += amount;
	
}
