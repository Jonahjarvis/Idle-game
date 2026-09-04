using Godot;
using System;
using Idle_game.scripts.Characters; 


namespace Idle_game.scripts.Tasks
{
	
	public abstract class TimerTask : GameTask
	{

		public double Duration { get; private set; }
		public double TimeSpent { get; private set; }
		

		public TimerTask(string taskName, double duration, Player stats, TaskCategory taskCategory)
			: base(taskName, stats, taskCategory)
		{
			Duration = duration;
			TimeSpent = 0;
		}

		public override void Toggle()
		{
			// Just turns the task on or off
			IsActive = !IsActive;
			if (!IsActive) TimeSpent = 0; // Reset progress if canceled
		}

		// Delta math to determine if a task has been completed or not
		public override void ProcessTask(double delta)
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
		

	}
}
