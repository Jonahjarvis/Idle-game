using Godot;
using System;

namespace Idle_game.scripts.Player 
{
	public class PlayerStats
	{
		// notify any listeners when stats are updated
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
		public void IncreaseMana() 
		{
			int ManaIncrement = 1;
			Mana += ManaIncrement;
			OnStatsUpdated?.Invoke();
		}
	}
}
