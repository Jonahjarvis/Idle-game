using Godot;
using System;
using Idle_game.scripts.Core; 

namespace Idle_game.scripts.UI
{
	public partial class UIManager : Control
	{
		// [Export] makes the class visible in the Godot Editor Inspector
		[Export] 
		private GameManager gameManager;

		private Label statsLabel;
		
		
		private Button trainButton;

		public override void _Ready()
		{
			statsLabel = GetNode<Label>("VBoxContainer/StatsLabel");
			trainButton = GetNode<Button>("VBoxContainer/TrainButton");
			
			trainButton.Pressed += OnTrainButtonPressed;
			
			// Subscribe to the backend data event!
			gameManager.CurrentPlayer.OnStatsUpdated += UpdateStatsDisplay;
			
			// Run once to populate the initial text
			UpdateStatsDisplay();
		}

		private void OnTrainButtonPressed()
		{
			// The UI doesn't do any math; it just passes the command to the manager.
			gameManager.ToggleCurrentTask();
			
			// Update the button visually
			trainButton.Text = gameManager.CurrentTask.IsActive ? 
				$"Stop {gameManager.CurrentTask.TaskName}" : 
				$"Start {gameManager.CurrentTask.TaskName}";
		}

		private void UpdateStatsDisplay()
		{
			// The UI reads the data from the manager and formats it.
			statsLabel.Text =
				$"Health: {gameManager.CurrentPlayer.Health}\n" +
				$"Strength: {gameManager.CurrentPlayer.Strength}\n" +
				$"Magical Power: {gameManager.CurrentPlayer.MagicalPower}\n" +
				$"Mana: {gameManager.CurrentPlayer.Mana}";
		}
	}
}
