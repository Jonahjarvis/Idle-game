using Godot;
using System;
using Idle_game.scripts.Characters; 


namespace Idle_game.scripts.Tasks
{
	public abstract class ToggleTask : GameTask
	{
		public ToggleTask(string taskName, Player stats, TaskCategory category) 
			: base(taskName, stats, category){ }
			
		
	}
}
