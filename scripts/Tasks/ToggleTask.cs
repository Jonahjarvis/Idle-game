using Godot;
using System;
using Idle_game.scripts.Player; 


namespace Idle_game.scripts.Tasks
{
	
	public abstract class ToggleTask : GameTask
	{
		


		public override void Toggle()
		{
			// Just turns the task on or off
			IsActive = !IsActive;

		}


	}
}
