using Godot;
using System;

public class PlayerStats
{
	// notify 
	public event Action OnStatsUpdated;
	
	public int Health { get; private set; } = 100;
	public int Mana { get; private set; } = 0;
	public int Strength { get; private set; } = 0;
	public int MagicalPower { get; private set; } = 1;
	public int ManaRegen { get; private set; } = 1;

	public void IncreaseStrength() 
	{
		int StrengthIncrement = 1;
		Strength += StrengthIncrement;
		OnStatsUpdated?.Invoke();
	}

}
