using Godot;
using System;
using System.Collections.Generic;
using Idle_game.scripts.Tasks; 
using Idle_game.scripts.Player; 

 
namespace Idle_game.scripts.Core
{
	public partial class GameManager : Node
	{
		// Public properties so the UI can read the players data
		public PlayerStats CurrentPlayer { get; private set; }
		
		// List of all tasks available in the game, each task has a category to identify which part of the UI it should be placed in.
		
		public List<GameTask> AvailableTasks { get; private set;}
		
		public GameTask ActiveTask { get; private set; }
		// Event for UI to listen to when the selected task changes
		public event Action OnActiveTaskChanged;

		public override void _EnterTree()
		{
			// Initialize the player and task list
			CurrentPlayer = new PlayerStats();
			AvailableTasks = new List<GameTask>();
			// Add starting tasks to AvailableTasks
			AvailableTasks.Add(new ManaCyclingTask(CurrentPlayer));
		}

		public override void _Process(double delta)
		{
			// The GameManager manages time, nothing else.
			CurrentPlayer.IncreaseMana((CurrentPlayer.ManaRegen + CurrentPlayer.BonusManaRegen) * delta);
			ActiveTask?.ProcessTask(delta);
		}
		
		// The UI will call this when a task button is clicked
		public void ToggleTask(GameTask clickedTask)
		{
			// If task is already on, switch off
			if (ActiveTask == clickedTask)
			{
				// This sets IsActive to false and resets TimeSpent
				ActiveTask.Toggle(); 
				ActiveTask = null;
			}
			// If task is not already on
			else
			{
				// Turn off the old task if one was running
				if (ActiveTask != null)
				{
					ActiveTask.Toggle();
				}

				// Set the new task as active and turn it on
				ActiveTask = clickedTask;
				ActiveTask.Toggle();
			}

			// Alert any listeners (the UI) that the active task has changed
			OnActiveTaskChanged?.Invoke();
		}
	}
}
