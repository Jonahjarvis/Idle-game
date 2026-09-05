using Godot;
using System;
using Idle_game.scripts.Characters;

namespace Idle_game.scripts.Tasks 
{
	public class CoreExpansionTask : TimerTask
	{
		// Cache the amount of mana paid
		private double _manaPaid = 0.0;

		public CoreExpansionTask(Player player) 
			: base("Core Expansion", 10.0, player, TaskCategory.Progression) { }

		protected override bool CanStart()
		{
			return Stats.currentMana >= Stats.MaxMana.Total;
		}

		protected override void OnStart()
		{
			// Save the exact cost, then deduct it
			_manaPaid = Stats.MaxMana.Total;
			Stats.DecreaseCurrentMana(_manaPaid);
		}

		// Triggered if the player clicks away before finishing
		public override void CancelTask()
		{
			// Refund the mana spent
			Stats.IncreaseCurrentMana(_manaPaid);
			
			// Call the base method to reset TimeSpent and IsActive
			base.CancelTask();
		}

		protected override void GrantReward()
		{
			
			Stats.MaxMana.IncreaseBaseValue(1.0);
		}
	}
}
