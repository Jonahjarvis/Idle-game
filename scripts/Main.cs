using Godot;
using System;

public partial class Main : Control
{
	// initialize player state and UI
	private PlayerStats playerStats;
	
	// initialize display objects, buttons and text etc.
	private Label statsLabel;
	private Button trainButton;
	
	// initialize time tracking variables for tasks.
	private bool isTraining = false;
	private double timeSpentOnTask = 0.0;
	private readonly double taskDuration = 5.0; // 5 seconds to complete
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Initialize player and UI
		playerStats = new PlayerStats();
		statsLabel = GetNode<Label>("VBoxContainer/StatsLabel");
		trainButton = GetNode<Button>("VBoxContainer/TrainButton");
	   
		// Button pressed logic
		trainButton.Pressed += OnTrainButtonPressed;
	
		// Display player once manually
		UpdateStatsDisplay();
	}
	
	// The button now toggles the action on and off instead of doing it instantly
	private void OnTrainButtonPressed()
	{
		isTraining = !isTraining;
		
		// Visual feedback for the player
		trainButton.Text = isTraining ? "Stop Training" : "Start Training";
		
		// Optional: Reset progress if they cancel the task
		if (!isTraining) 
		{
			timeSpentOnTask = 0.0;
		}
	}
	public override void _Process(double delta)
	{
		// If player isn't actively training, do nothing and exit the frame
		if (!isTraining) return;
		
		// Whenever a stat is changed, update the display
		playerStats.OnStatsUpdated += UpdateStatsDisplay;
		
		// Add time since last frame was rendered for consistent training time regardless of frame rate
		// Using a variable accumulator also makes offline time easy to calculate
		timeSpentOnTask += delta;

		// Check if task is complete
		while (timeSpentOnTask >= taskDuration)
		{
			// Remove the task duration, keeping any "leftover" time
			timeSpentOnTask -= taskDuration;
			
			// Grant the player their strength increase
			playerStats.IncreaseStrength();
		
		}
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
