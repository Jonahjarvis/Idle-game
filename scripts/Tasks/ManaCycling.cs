using Godot;
using System;
using Idle_game.scripts.Player;
 
namespace Idle_game.scripts.Tasks 
{
	public class ManaCyclingTask : ToggleTask
	{
		public ManaCyclingTask(PlayerStats stats) 
			: base("Cycling Mana", stats,TaskCategory.Training) 
			{ 
				
			}
		
		
		protected override void EnableToggle()
		{
			Stats.IncreaseBonusManaRegen((Stats.ManaRegen*5)+0.1);
		}
		
		protected override void DisableToggle()
		{
			Stats.DecreaseBonusManaRegen((Stats.ManaRegen*5)+0.1);
		}
		
	}
}
