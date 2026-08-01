using Godot;
using System;
using Idle_game.scripts.Tasks; 
using Idle_game.scripts.Player; 

namespace Idle_game.scripts.Core
{
	public partial class GameManager : Node
	{
		// Public properties so the UI can read the data, but private setters 
		// so the UI can't accidentally overwrite the player object.
		public PlayerStats CurrentPlayer { get; private set; }
		public GameTask CurrentTask { get; private set; }

		public override void _EnterTree()
		{
			// Initialize the data backend BEFORE the UI loads
			CurrentPlayer = new PlayerStats();
			CurrentTask = new StrengthTrainingTask(CurrentPlayer);
		}

		public override void _Process(double delta)
		{
			// The GameManager manages time, nothing else.
			CurrentTask?.ProcessTask(delta);
		}
		
		// A helper method so the UI can tell the backend what to do
		public void ToggleCurrentTask() 
		{
			CurrentTask?.Toggle();
		}
	}
}
