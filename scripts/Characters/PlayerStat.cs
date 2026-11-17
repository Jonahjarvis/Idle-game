using Godot;
using System;

public class PlayerStat
{
	public double BaseValue { get; private set; } = 0.0;
	
	// Flat Increases
	public double ActiveTaskFlat { get; private set; } = 0.0;
	public double PerkFlat { get; private set; } = 0.0;

	// Multiplicative increases
	public double ActiveTaskMult { get; private set; } = 1.0;
	public double PerkMult { get; private set; } = 1.0;

	public double Total => (BaseValue + ActiveTaskFlat + PerkFlat) * (ActiveTaskMult * PerkMult);

	public PlayerStat(double startingBase)
	{
		BaseValue = startingBase;
	}
	
	public void SetActiveTaskBonus(double flat, double multiplier)
	{
		ActiveTaskFlat = flat;
		ActiveTaskMult = multiplier;
		
	}
	
	public void SetActivePerkBonus(double flat, double multiplier)
	{
		PerkFlat = flat;
		PerkMult = multiplier;
		
	}
	
	// These should only ever be used for permanent progression milestones
	public void IncreaseBaseValue(double increase)
	{
		BaseValue += increase;
	}
	public void DecreaseBaseValue(double decrease)
	{
		BaseValue -= decrease;
	}
	
	
}
