using Godot;
using System;
using System.Collections.Generic;
using Idle_game.scripts.Core;
using Idle_game.scripts.Tasks;

namespace Idle_game.scripts.UI
{
	public partial class UIManager : Control
	{
		[Export] 
		public GameManager GameManagerNode { get; set; }

		private Label statsLabel;
		private VBoxContainer trainingContainer;
		private VBoxContainer combatContainer;
		
		// Dictionary of generated buttons to easily change text
		private Dictionary<GameTask, Button> taskButtons = new Dictionary<GameTask, Button>();

		public override void _Ready()
		{
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
			foreach (var task in GameManagerNode.AvailableTasks)
			{
				Button newButton = new Button();
				newButton.Text = $"Start {task.TaskName}";
				
				// The button now tells the Manager to handle the toggle logic
				newButton.Pressed += () => GameManagerNode.ToggleTask(task);

				if (task.Category == TaskCategory.Training)
				{
					trainingContainer.AddChild(newButton);
				}
				else if (task.Category == TaskCategory.Combat)
				{
					combatContainer.AddChild(newButton);
				}

				// Save the button in our dictionary
				taskButtons.Add(task, newButton);
			}
		}

		private void UpdateButtonVisuals()
		{
			// Loop through all our generated buttons and ensure their text is correct
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
				$"Strength: {GameManagerNode.CurrentPlayer.Strength}\n" +
				$"Magical Power: {GameManagerNode.CurrentPlayer.MagicalPower}\n" +
				$"Mana: {GameManagerNode.CurrentPlayer.Mana}";
		}
	}
}
