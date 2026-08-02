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
		public string TaskName { get; private set; }
		public double Duration { get; private set; }
		public double TimeSpent { get; private set; }
		public bool IsActive { get; private set; }
		
		public TaskCategory Category { get; private set; }
		// Pass in PlayerStats so the task can grant the reward to the player
		protected PlayerStats Stats; 

		public GameTask(string taskName, double duration, PlayerStats stats, TaskCategory taskCategory)
		{
			TaskName = taskName;
			Duration = duration;
			Stats = stats;
			TimeSpent = 0;
			IsActive = false;
			Category = taskCategory;
		}

		public void Toggle()
		{
			// Just turns the task on or off
			IsActive = !IsActive;
			if (!IsActive) TimeSpent = 0; // Reset progress if canceled
		}

		// Delta math to determine if a task has been completed or not
		public void ProcessTask(double delta)
		{
			if (!IsActive) return;
			// delta is time since last frame rendered so keeps task progress consistent regardless of frame rate
			TimeSpent += delta;

			while (TimeSpent >= Duration)
			{
				TimeSpent -= Duration;
				GrantReward(); // Calls the specific reward logic
			}
		}

		// All tasks need rewards
		protected abstract void GrantReward();
	}
}
