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
			// first variable is flat modifier, second is multiplicative modifier
			if (CanStart())
			{
				IsActive = true;
				
			}
			
			
		}
		
		public override void CancelTask()
		{
			IsActive = false;
		}

		// Delta math to determine if a task has been completed or not
		public override void ProcessTask(double delta)
		{
			if (!IsActive) return;
			// delta is time since last frame rendered so keeps task progress consistent regardless of frame rate
			TimeSpent += delta;

			while (TimeSpent >= Duration)
			{
				TimeSpent = 0;
				GrantReward(); // Calls the specific reward logic
				if (!CanStart())
				{
					CancelTask();
				}
			}
		}
	}
}
