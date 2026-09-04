using Godot;
using System;

namespace Idle_game.scripts.Characters 
{
	public class Player
	{
		public event Action OnAnyStatUpdated;
		
		public PlayerStat ManaRegen { get; private set; } = new PlayerStat(0.0);
		public PlayerStat MaxMana { get; private set; } = new PlayerStat(5.0);
		
		public int Health { get; private set; } = 100;
		public Double CurrentMana { get; private set; } = 0;
		
		public Player()
		{
			// Tell the Player to listen to its own child objects.
			// Whenever a stat updates, it calls TriggerStatUpdate.
			ManaRegen.OnStatUpdated += TriggerStatUpdate;
			MaxMana.OnStatUpdated += TriggerStatUpdate;
		}
		private void TriggerStatUpdate()
		{
			// Rebroadcast the change to the rest of the game
			OnAnyStatUpdated?.Invoke();
		}
		
		
		public void IncreaseCurrentMana(double IncreaseAmount)
		{
			if (CurrentMana + IncreaseAmount >= MaxMana.Total) {
				CurrentMana = MaxMana.Total;
			} else {
				CurrentMana += IncreaseAmount;
			}
			OnAnyStatUpdated?.Invoke();
			
		}
		public void DecreaseCurrentMana(double DecreaseAmount)
		{
			// logic to check if the player has enough mana will occur before the spell/task is cast so no need to prevent it here.
			CurrentMana -= DecreaseAmount;
			OnAnyStatUpdated?.Invoke();
		}

		
	}
}
