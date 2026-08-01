using Godot;
using System;

public abstract class GameTask
{
	public string TaskName { get; private set; }
	public double Duration { get; private set; }
	public double TimeSpent { get; private set; }
	public bool IsActive { get; private set; }
	
	// We pass in PlayerStats so the task knows who to give the reward to
	protected PlayerStats Stats; 

	public GameTask(string taskName, double duration, PlayerStats stats)
	{
		TaskName = taskName;
		Duration = duration;
		Stats = stats;
		TimeSpent = 0;
		IsActive = false;
	}

	public void Toggle()
	{
		IsActive = !IsActive;
		if (!IsActive) TimeSpent = 0; // Reset progress if canceled
	}

	// This handles the delta math for EVERY task in the game
	public void ProcessTask(double delta)
	{
		if (!IsActive) return;

		TimeSpent += delta;

		while (TimeSpent >= Duration)
		{
			TimeSpent -= Duration;
			GrantReward(); // Calls the specific reward logic
		}
	}

	// The 'abstract' keyword forces any child class to write this specific method
	protected abstract void GrantReward();
}
