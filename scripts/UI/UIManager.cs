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
		[Export] 
		public GameManager GameManagerNode { get; set; }
		// Containers and labels for displaying stats and tasks
		private Label statsLabel;
		private VBoxContainer trainingContainer;
		private VBoxContainer combatContainer;
		
		// Dictionary of all generated task buttons
		private Dictionary<GameTask, Button> taskButtons = new Dictionary<GameTask, Button>();

		public override void _Ready()
		{
			// Get references to the existing display sections
			statsLabel = GetNode<Label>("TrainingPage/StatsLabel");
			trainingContainer = GetNode<VBoxContainer>("TrainingPage/HBoxContainer/TrainingColumn");
			combatContainer = GetNode<VBoxContainer>("TrainingPage/HBoxContainer/CombatColumn");
			
			// Listen for when stats change to update display
			GameManagerNode.CurrentPlayer.OnStatsUpdated += UpdateStatsDisplay;
			
			// Listen for when the active task changes so we can update button text
			GameManagerNode.OnActiveTaskChanged += UpdateButtonVisuals;

			UpdateStatsDisplay();
			GenerateTaskButtons();
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
				if (task.Category == TaskCategory.Training)
				{
					trainingContainer.AddChild(newButton);
				}
				else if (task.Category == TaskCategory.Combat)
				{
					combatContainer.AddChild(newButton);
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
				$"Health: {GameManagerNode.CurrentPlayer.Health}\n" +
				$"Mana: {GameManagerNode.CurrentPlayer.Mana:F2}\n" +
				$"Mana Regen: {GameManagerNode.CurrentPlayer.ManaRegen}";
		}
	}
}
