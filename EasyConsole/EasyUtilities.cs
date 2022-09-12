using VonRiddarn.EasyConsole.Graphics;

namespace VonRiddarn.EasyConsole.Utilities;

public static class EasyUtilities
{
	// TODO: Add color override here
	public static void WaitForKey(string message = "Press any key to continue.", ConsoleKey key = ConsoleKey.NoName, bool useWriteLine = true)
	{
		if(message.Length > 0)
		{
			if(useWriteLine)
				Console.WriteLine(message);
			else
				Console.Write(message);
		}
		
		while(true)
		{
			ConsoleKey input = Console.ReadKey(true).Key;
			
			if(key != ConsoleKey.NoName)
			{
				if(input == key)
					return;
			}
			else
				return;
		}
	}
	
	public static int ForceInputInt()
	{
		// No message
		// No error
		// Default color
		return ForceInputInt(string.Empty, string.Empty, EasyGraphics.CurrentColor);
	}
	public static int ForceInputInt(string prompt)
	{
		// Custom message
		// No error
		// Default color
		return ForceInputInt(prompt, string.Empty, EasyGraphics.CurrentColor);
	}
		public static int ForceInputInt(string prompt, string error)
	{
		// Custom message
		// Custom error
		// Default color
		return ForceInputInt(prompt, error, EasyGraphics.CurrentColor);
	}
	public static int ForceInputInt(string prompt, string error, ConsoleColor inputColor, ConsoleColor errorColor = ConsoleColor.Red)
	{
		while(true)
		{
			if(prompt.Length > 0)
				Console.Write(prompt);
				
			EasyGraphics.ColorStart(inputColor);
			string input = Console.ReadLine();
			EasyGraphics.ColorEnd();
			
			if(int.TryParse(input, out int value))
				return value;
			else
			{
				if(error.Length > 0)
					EasyGraphics.ColoredMessage(error, errorColor);
			}
		}
	}
	
}