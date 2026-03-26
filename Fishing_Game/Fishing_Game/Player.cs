using System;

// Player state responsibility
public class Player
{
	public int score { get; set; }

	// Adds score during the fishing
	public void AddScore(int amount) => score += amount;
	
}
