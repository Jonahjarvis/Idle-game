using Godot;
using System;
using Idle_game.scripts.Player; 


namespace Idle_game.scripts.Tasks
{
	public abstract class ToggleTask : GameTask
	{
		public ToggleTask(string taskName, PlayerStats stats, TaskCategory category) 
			: base(taskName, stats, category){ }
			
			public override void Toggle()
			{
				// Just turns the task on or off
				if (!IsActive){
					EnableToggle();
				} else {
					DisableToggle();
				}
				IsActive = !IsActive;
			}
			protected abstract void EnableToggle();
			protected abstract void DisableToggle();
		
	}
}
