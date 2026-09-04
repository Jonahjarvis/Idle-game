using Godot;
using System;
using Idle_game.scripts.Player;
 
namespace Idle_game.scripts.Tasks 
{
	public class IntelligenceTrainingTask : GameTask
	{
		public IntelligenceTrainingTask(PlayerStats stats) 
			: base("Cycling Mana", 5.0, stats,TaskCategory.Training) { }

		protected override void GrantReward()
		{
			Stats.IncreaseMana();
		}
	}
}
