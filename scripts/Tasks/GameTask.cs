using Godot;
using System;
using Idle_game.scripts.Characters; 


namespace Idle_game.scripts.Tasks
{
	// task type enum for formatting (similar tasks will have buttons grouped)
	public enum TaskCategory 
	{
		Training,
		Combat,
		Progression
	}
	
	public abstract class GameTask
	{
		// Basic overarching Task abstract class for all common tasks that will be implemented
		public string TaskName { get; protected set; }
		public bool IsActive { get; protected set; }
		
		public TaskCategory Category { get; protected set; }
		// Pass in Player so the task can grant the reward/stat modifier to the player
		protected Player Stats; 

		public GameTask(string taskName, Player stats, TaskCategory taskCategory)
		{
			TaskName = taskName;
			Stats = stats;
			IsActive = false;
			Category = taskCategory;
		}
		
		protected virtual bool CanStart()
		{
			return true;
		}
		protected virtual void OnStart()
		{
			// does nothing by default, some tasks might have something happen when starting	
		}
		
		public virtual void ProcessTask(double delta)
		{
		// Does nothing because unused by toggled tasks. Other subclasses like TimerTask will override this.
		}
		protected virtual void GrantReward()
		{
		// Does nothing because unused by toggled tasks. Other subclasses like TimerTask will override this.
		}
		// turns the task on 
		public abstract void StartTask();
		
		// turns the task off
		public abstract void CancelTask();

		

	}
}
