using Godot;
using System;
using Idle_game.scripts.Player;
 
namespace Idle_game.scripts.Tasks 
{
	public class ManaCyclingTask : ToggleTask
	{
		public ManaCyclingTask(PlayerStats stats) 
			: base("Cycling Mana", stats,TaskCategory.Training) { }
		private float ManaRegen = Stats.ManaRegen;
		
		
		protected override void EnableToggle()
		{
			Stats.IncreaseManaRegen((ManaRegen*5)+0.1);
		}
		
		protected override void DisableToggle()
		{
			Stats.DecreaseManaRegen((ManaRegen*5)+0.1);
		}
		
	}
}
