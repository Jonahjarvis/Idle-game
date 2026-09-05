using Godot;
using System;
using Idle_game.scripts.Characters;
 
namespace Idle_game.scripts.Tasks 
{
	public class ManaCyclingTask : ToggleTask
	{
		public ManaCyclingTask(Player stats) 
			: base("Cycling Mana", stats,TaskCategory.Training) 
			{ 
				
			}
		// use Stats not stats because parent class is actually what holds the Stat value
		// Task specific stat modifiers to prevent directly modifying stats themselves
		public override void StartTask()
		{
			// first variable is flat modifier, second is multiplicative modifier
			Stats.ManaRegen.SetActiveTaskBonus(0.01,2.0); 
			IsActive = true;
		}
		
		public override void CancelTask()
		{
			Stats.ManaRegen.SetActiveTaskBonus(0.0,1); 
			IsActive = false;
		}
		
	}
}
