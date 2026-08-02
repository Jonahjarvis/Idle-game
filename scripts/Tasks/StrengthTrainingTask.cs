using Godot;
using System;
using Idle_game.scripts.Player;
 
namespace Idle_game.scripts.Tasks 
{
	public class StrengthTrainingTask : GameTask
	{
		public StrengthTrainingTask(PlayerStats stats) 
			: base("Training Strength", 5.0, stats,TaskCategory.Training) { }

		protected override void GrantReward()
		{
			Stats.IncreaseStrength();
		}
	}
}
