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
		public double BonusManaRegen { get; private set; } = 0.0;
		
		public int MaxManaIncrement { get; private set; } = 1;

		public void IncreaseMaxMana() 
		{
			MaxMana += MaxManaIncrement;
			OnStatsUpdated?.Invoke();
		}
		
		public void IncreaseMana(double ManaIncrease) 
		{
			Mana += ManaIncrease;
			OnStatsUpdated?.Invoke();
		}
		public void DecreaseMana(double ManaDecrease) 
		{
			// Decreases mana by given 
			Mana -= ManaDecrease;
			OnStatsUpdated?.Invoke();
		}
		
		public void IncreaseManaRegen(float regenIncrease)
		{
			// base mana regen can be increased as player progresses
			ManaRegen += regenIncrease;
		}
		
		// increases or decreases to regen will always be a flat cost hence the bonus stat to keep base regen stable
		public void IncreaseBonusManaRegen(float regenIncrease)
		{
		
			BonusManaRegen += regenIncrease;
		}
		
		public void DecreaseBonusManaRegen(float regenDecrease)
		{
			BonusManaRegen -= regenDecrease;
		}
		
	}
}
