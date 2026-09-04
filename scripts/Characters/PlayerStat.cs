using Godot;
using System;

public class PlayerStat
{
	// event for listeners when stats are modified
	public event Action OnStatUpdated;
	public double BaseValue { get; set; } = 0.0;
	
	// Flat Increases
	public double ActiveTaskFlat { get; set; } = 0.0;
	public double PerkFlat { get; set; } = 0.0;

	// Multiplicative increases
	public double ActiveTaskMult { get; set; } = 1.0;
	public double PerkMult { get; set; } = 1.0;

	public double Total => (BaseValue + ActiveTaskFlat + PerkFlat) * (ActiveTaskMult * PerkMult);

	public PlayerStat(double startingBase)
	{
		BaseValue = startingBase;
	}
	
	public void SetActiveTaskBonus(double flat, double multiplier)
	{
		ActiveTaskFlat = flat;
		ActiveTaskMult = multiplier;
		
		// Trigger event for updating the UI or other listeners
		OnStatUpdated?.Invoke(); 
	}
	
	public void SetActivePerkBonus(double flat, double multiplier)
	{
		PerkFlat = flat;
		PerkMult = multiplier;
		
		// Trigger event for updating the UI or other listeners
		OnStatUpdated?.Invoke(); 
	}
	
	
}
