using Godot;
using System;
using Idle_game.scripts.Characters;

namespace Idle_game.scripts.Tasks 
{
	public class CoreExpansionTask : TimerTask
	{
		
		public override string TaskName => $"Core Expansion: {Cost:F1} Mana";
		public CoreExpansionTask(Player player) 
			: base($"Core Expansion", 10.0, player, TaskCategory.Progression) {
				 Cost = Stats.MaxMana.Total;
				 }
			
			
		protected override bool CanStart()
		{
			return Stats.currentMana >= Cost;
		}

		protected override void OnStart()
		{
			Stats.DecreaseCurrentMana(Cost);
		}

		// Triggered if the player clicks away before finishing
		public override void CancelTask()
		{
			// only set IsActive to false which preserves time spent if the user wants to pick the task up again.
			IsActive = false;
		}

		

		protected override void GrantReward()
		{
			Cost += 1.0;
			Stats.MaxMana.IncreaseBaseValue(1.0);
		}
	}
}
