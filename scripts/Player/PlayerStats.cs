using Godot;
using System;

namespace Idle_game.scripts.Player 
{
	public class PlayerStats
	{
		// notify any listeners when stats are updated
		public event Action OnStatsUpdated;
		
		public int Health { get; private set; } = 100;
		public float Mana { get; private set; } = 0;
		public int MaxMana { get; private set; } = 0;
		public double ManaRegen { get; private set; } = 0.0;
		public int MaxManaIncrement { get; private set; } = 1;

		public void IncreaseMaxMana() 
		{
			MaxMana += MaxManaIncrement;
			OnStatsUpdated?.Invoke();
		}
		public void IncreaseManaRegen(float regenIncrease)
		{
			ManaRegen += regenIncrease;
		}
	}
}
