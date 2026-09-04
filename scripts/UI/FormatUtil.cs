using Godot;

public static class FormatUtil
{
	public static string FormatNumber(double value)
	{
		// Millions (e.g., 1.52M)
		if (value >= 1_000_000) return (value / 1_000_000).ToString("F2") + "M";
		
		// Thousands (e.g., 10.50k)
		if (value >= 1_000) return (value / 1_000).ToString("F2") + "k";
		
		// Hundreds (e.g., 150)
		if (value >= 100) return value.ToString("F0");
		
		// Small numbers (e.g., 4.25)
		return value.ToString("F2");
	}
}
