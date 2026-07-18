using Godot;
using System;

public partial class Main : Control
{
	// initialize player state and UI
	private PlayerStats playerStats;
	
	private Label statsLabel;
	private Button trainButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Initialize player and UI
		playerStats = new PlayerStats();
		statsLabel = GetNode<Label>("VBoxContainer/StatsLabel");
		trainButton = GetNode<Button>("VBoxContainer/TrainButton");
	   
		// Button pressed logic
		trainButton.Pressed += OnTrainButtonPressed;
	
		// Display player stats
		UpdateStatsDisplay();
	}
	
	private void OnTrainButtonPressed()
	{
		playerStats.IncreaseStrength();

		UpdateStatsDisplay();
	}

	
	private void UpdateStatsDisplay()
	{
		statsLabel.Text =
			$"Health: {playerStats.Health}\n" +
			$"Strength: {playerStats.Strength}\n" +
			$"Magical Power: {playerStats.MagicalPower}\n" +
			$"Mana: {playerStats.Mana}";
	}


}
