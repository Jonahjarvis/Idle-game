using Godot;
using System;
using System.Collections.Generic;
using Idle_game.scripts.Core;
using Idle_game.scripts.Tasks;

namespace Idle_game.scripts.UI
{
	public partial class UIManager : Control
	{
		// Export makes GameManager visible for UIManager in the inspector tool
		// So I can drag the GameManager node into UIManagers inspector to give UIManager a reference
		[Export] public GameManager GameManagerNode { get; set; }
		// Containers and labels for displaying stats and tasks
		[Export] public Godot.TextureProgressBar TaskProgressBar;
		
		private Label statsLabel;
		private VBoxContainer trainingContainer;
		private VBoxContainer combatContainer;
		private VBoxContainer progressionContainer;
		
		
		// Dictionary of all generated task buttons
		private Dictionary<GameTask, Button> taskButtons = new Dictionary<GameTask, Button>();

		public override void _Ready()
		{
			// Get references to the existing display sections
			statsLabel = GetNode<Label>("TrainingPage/StatsLabel");
			trainingContainer = GetNode<VBoxContainer>("TrainingPage/HBoxContainer/TrainingColumn");
			combatContainer = GetNode<VBoxContainer>("TrainingPage/HBoxContainer/CombatColumn");
			progressionContainer = GetNode<VBoxContainer>("TrainingPage/HBoxContainer/ProgressionColumn");
			// Listen for when stats change to update display
			GameManagerNode.CurrentPlayer.OnAnyStatUpdated += UpdateStatsDisplay;
			
			// Listen for when the active task changes so we can update button text
			GameManagerNode.OnActiveTaskChanged += UpdateButtonVisuals;

			UpdateStatsDisplay();
			GenerateTaskButtons();
		}
		
		public override void _Process(double delta) 
		{
			UpdateTaskProgressBar();
		}
		
		private void UpdateTaskProgressBar()
		{
			// 1. Get the current task from the GameManager
			GameTask currentTask = GameManagerNode.ActiveTask;
			// 2. Check if it's a TimerTask and if it's running
			if (currentTask is TimerTask activeTimer && activeTimer.IsActive)
			{
				TaskProgressBar.Visible = true;
				TaskProgressBar.MaxValue = activeTimer.Duration;
				TaskProgressBar.Value = activeTimer.TimeSpent;
			}
			else
			{

				// Hide the bar if no timer task is active
				TaskProgressBar.Visible = false;
			}
		}

		private void GenerateTaskButtons()
		{
			// Generate a button for every task in AvailableTasks
			foreach (var task in GameManagerNode.AvailableTasks)
			{
				Button newButton = new Button();
				newButton.Text = $"Start {task.TaskName}";
				
				// Use ToggleTask logic for the specific task when its associated button is pressed
				newButton.Pressed += () => GameManagerNode.ToggleTask(task);

				// Task buttons are sorted into different parts of the UI depending on category
				switch (task.Category)
				{
					case TaskCategory.Training:
						trainingContainer.AddChild(newButton);
						break;
					case TaskCategory.Combat:
						combatContainer.AddChild(newButton);
						break;
					case TaskCategory.Progression:
						progressionContainer.AddChild(newButton);
						break;
				}

				// Save the button to dictionary
				taskButtons.Add(task, newButton);
			}
		}

		private void UpdateButtonVisuals()
		{
			// Loop through all generated buttons and ensure their text is correct
			foreach (var kvp in taskButtons)
			{
				GameTask task = kvp.Key;
				Button button = kvp.Value;

				// If this is the active task, say "Stop", otherwise say "Start"
				button.Text = task.IsActive ? $"Stop {task.TaskName}" : $"Start {task.TaskName}";
			}
		}
		
		private void UpdateStatsDisplay()
		{
			statsLabel.Text =
				$"Health: {FormatUtil.FormatNumber(GameManagerNode.CurrentPlayer.health)}\n" +
				$"Mana: {FormatUtil.FormatNumber(GameManagerNode.CurrentPlayer.currentMana)}/{FormatUtil.FormatNumber(GameManagerNode.CurrentPlayer.MaxMana.Total)} \n" +
				$"Mana Regen: {FormatUtil.FormatNumber(GameManagerNode.CurrentPlayer.ManaRegen.Total)}/s";
		}
	}
}
