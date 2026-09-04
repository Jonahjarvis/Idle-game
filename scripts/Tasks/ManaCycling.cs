using Godot;
using System;
using Idle_game.scripts.Player;
 
namespace Idle_game.scripts.Tasks 
{
	public class IntelligenceTrainingTask : ToggleTasks
	{
		public ManaCyclingTask(PlayerStats stats) 
			: base("Cycling Mana", stats,TaskCategory.Training) { }
		
		protected override void GrantReward()
		{
			
			Stats.IncreaseMana();
		}
	}
}
