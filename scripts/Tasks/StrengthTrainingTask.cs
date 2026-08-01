using Godot;
using System;
using Idle_game.scripts.Player;
 
namespace Idle_game.scripts.Tasks 
{
	public class StrengthTrainingTask : GameTask
	{
		public StrengthTrainingTask(PlayerStats stats) 
			: base("Train Strength", 5.0, stats) { }

		protected override void GrantReward()
		{
			Stats.IncreaseStrength();
		}
	}
}
