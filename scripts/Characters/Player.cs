using Godot;
using System;

namespace Idle_game.scripts.Characters 
{
	public class Player
	{
		public event Action OnAnyStatUpdated;
		
		public PlayerStat ManaRegen { get; private set; } = new PlayerStat(0.1);
		public PlayerStat MaxMana { get; private set; } = new PlayerStat(5.0);
		
		public int health { get; private set; } = 100;
		public Double currentMana { get; private set; } = 0;
		
		public Player()
		{
			//chillin
		}
		
		
		public void IncreaseCurrentMana(double IncreaseAmount)
		{
			if (currentMana + IncreaseAmount >= MaxMana.Total) {
				currentMana = MaxMana.Total;
			} else {
				currentMana += IncreaseAmount;
			}

			
		}
		public void DecreaseCurrentMana(double DecreaseAmount)
		{
			// logic to check if the player has enough mana will occur before the spell/task is cast so no need to prevent it here.
			currentMana -= DecreaseAmount;
		}

		
	}
}
