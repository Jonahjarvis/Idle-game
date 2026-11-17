using Godot;
using System;
using Idle_game.scripts.Characters;

namespace Idle_game.scripts.Tasks 
{
	public class ConcentrateManaFlowTask : TimerTask
	{
		private double ManaRequirement;
		public ConcentrateManaFlowTask(Player player) 
			: base("Concentrate Mana Flow", 5.0, player, TaskCategory.Progression) { 
				ManaRequirement = Stats.MaxMana.Total;
			}
		
		protected override bool CanStart()
		{
			return Stats.currentMana >= ManaRequirement;
		}

		protected override void OnStart()
		{
			Stats.DecreaseCurrentMana(ManaRequirement);
			ManaRequirement += 0.1;
		}

		// Triggered if the player clicks away before finishing
		public override void CancelTask()
		{
			// only set IsActive to false which preserves time spent if the user wants to pick the task up again.
			IsActive = false;
		}

		

		protected override void GrantReward()
		{
			Stats.ManaRegen.IncreaseBaseValue(0.02);
		}
	}
}
