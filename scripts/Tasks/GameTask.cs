using Godot;
using System;
using Idle_game.scripts.Player; 


namespace Idle_game.scripts.Tasks
{
	// task type enum for formatting (similar tasks will have buttons grouped)
	public enum TaskCategory 
	{
		Training,
		Combat
	}
	
	public abstract class GameTask
	{
		// Basic overarching Task abstract class for all common tasks that will be implemented
		public string TaskName { get; private set; }
		public bool IsActive { get; private set; }
		
		public TaskCategory Category { get; private set; }
		// Pass in PlayerStats so the task can grant the reward/stat modifier to the player
		protected PlayerStats Stats; 

		public GameTask(string taskName, PlayerStats stats, TaskCategory taskCategory)
		{
			TaskName = taskName;
			Stats = stats;
			IsActive = false;
			Category = taskCategory;
		}

		public void Toggle()
		{
			// Just turns the task on or off
			IsActive = !IsActive;
		}

		// Task execution logic
		public abstract void ProcessTask();


	}
}
