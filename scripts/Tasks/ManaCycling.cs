using Godot;
using System;
using Idle_game.scripts.Player;
 
namespace Idle_game.scripts.Tasks 
{
	public class ManaCyclingTask : ToggleTask
	{
		public ManaCyclingTask(PlayerStats stats) 
			: base("Cycling Mana", stats,TaskCategory.Training) { }
		private double ManaRegen = Stats.ManaRegen;
		
		
		protected override void EnableToggle()
		{
			Stats.IncreaseBonusManaRegen((ManaRegen*5)+0.1);
		}
		
		protected override void DisableToggle()
		{
			Stats.DecreaseBonusManaRegen((ManaRegen*5)+0.1);
		}
		
	}
}
