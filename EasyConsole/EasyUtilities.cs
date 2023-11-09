using System.ComponentModel;
using VonRiddarn.EasyConsole.Graphics;

namespace VonRiddarn.EasyConsole.Utilities;

public static class EasyUtilities
{
	
	public static void WaitForKey(string message = "Press any key to continue.", ConsoleKey key = ConsoleKey.NoName, bool useWriteLine = true)
	{
		if (message.Length > 0)
		{
			if (useWriteLine)
				Console.WriteLine(message);
			else
				Console.Write(message);
		}

		while (true)
		{
			ConsoleKey input = Console.ReadKey(true).Key;

			if (key != ConsoleKey.NoName)
			{
				if (input == key)
					return;
			}
			else
				return;
		}
	}

	public static void ClearLine(int heightOffset = 0, bool rubberBand = false)
	{
		// Move the cursor to a line
		Console.CursorTop += heightOffset;

		// Reset cursor to the left
		// Build a string of spaces with the length Console.WindowWidth
		// Reset the cursor to the left
		Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");

		// If true: Send the cursor back to its start position after clearing.
		if (rubberBand)
			Console.CursorTop -= heightOffset;
	}


	// TODO: Add ClearLine that clears the lines from a start to end.
	// Tried this. My small walnut brain couldn't handle it, so thats a future feature.

	///<summary>This will lock the end-user in an input loop that they cannot escape unless they give a valid input of type T</summary>
	///<remarks>The value is then returned as an object, meaning you need to case the return to the type you want it to be.
	///Like so: int i = (ForceInputOfType-int-("text", "text"));</remarks>
	public static T ForceInputOfType<T>(string prompt, string error) => ForceInputOfType<T>(prompt, error, EasyGraphics.CurrentColor);
	///<summary>This will lock the end-user in an input loop that they cannot escape unless they give a valid input of type T</summary>
	///<remarks>The value is then returned as an object, meaning you need to case the return to the type you want it to be.
	///Like so: int i = (ForceInputOfType-int-("text", "text"));</remarks>
	public static T ForceInputOfType<T>(string prompt, string error, ConsoleColor inputColor, ConsoleColor errorColor = ConsoleColor.Red)
	{
		bool containsErrorMessage = false;

		while (true)
		{

			Console.Write(prompt);

			string? input = EasyGraphics.ColoredInput(inputColor);

			try
			{
				// ! at the end is a compiler null forgiveable operator
				T returnValue = (T)Convert.ChangeType(input, typeof(T))!;

				if (containsErrorMessage)
					EasyUtilities.ClearLine();

				return returnValue;
			}
			catch
			{
				if (error.Length > 0)
				{
					EasyGraphics.ColoredMessage(error, errorColor);
					containsErrorMessage = true;
					EasyUtilities.ClearLine(-2, false);
				}
			}
		}
	}
}