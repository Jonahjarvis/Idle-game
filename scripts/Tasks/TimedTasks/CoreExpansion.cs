using Godot;
using System;
using Idle_game.scripts.Characters;

namespace Idle_game.scripts.Tasks 
{
	public class CoreExpansionTask : TimerTask
	{

		public CoreExpansionTask(Player player) 
			: base("Core Expansion", 10.0, player, TaskCategory.Progression) { }

		protected override bool CanStart()
		{
			return Stats.currentMana >= Stats.MaxMana.Total;
		}

		protected override void OnStart()
		{
			Stats.DecreaseCurrentMana(Stats.MaxMana.Total);
		}

		// Triggered if the player clicks away before finishing
		public override void CancelTask()
		{
			// only set IsActive to false which preserves time spent if the user wants to pick the task up again.
			IsActive = false;
		}

		

		protected override void GrantReward()
		{
			Stats.MaxMana.IncreaseBaseValue(1.0);
		}
	}
}
