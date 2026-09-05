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

		public override void StartTask()
		{
			// sets the task to active only to prevent outside classes modifying IsActive directly
			IsActive = true;
		}
			
		protected override void OnComplete()
		{
			GrantReward();
			TimeSpent = 0;
		}
		
		public override void CancelTask()
		{
			IsActive = false;
		}

		// Delta math to determine if a task has been completed or not
		public override void ProcessTask(double delta)
		{
			if (!IsActive) return;

			if (TimeSpent == 0)
			{
				if (CanStart()) {
					// checks to see if task can start 
					OnStart();
				} else {
					// requirements to repeat the task not met yet
					return;
				}
			}
			// delta is time since last frame rendered so keeps task progress consistent regardless of frame rate
			TimeSpent += delta;
			if (TimeSpent >= Duration)
			{
				OnComplete(); // Calls the specific reward logic
			}
			
		}
	}
}
