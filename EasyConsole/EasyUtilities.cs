using System.ComponentModel;
using VonRiddarn.EasyConsole.Graphics;

namespace VonRiddarn.EasyConsole.Utilities;

public static class EasyUtilities
{
	// TODO: Add color override here
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

	public static void ClearLine(int heightOffset = 0, bool rubberBand = false)
	{
		//Console.SetCursorPosition(0, Console.CursorTop - 2);

		Console.CursorTop += heightOffset;

		// Reset cursor to the left
		// Build a string of spaces with the length Console.WindowWidth
		// Reset the cursor to the left
		Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");

		if (rubberBand)
			Console.CursorTop -= heightOffset;
	}

	// TODO: Add ClearLine that clears the lines from a start to end.


	///<summary>This will lock the end-user in an input loop that they cannot escape unless they give a valid input of type T</summary>
	///<remarks>The value is then returned as an object, meaning you need to case the return to the type you want it to be.
	///Like so: int i = (ForceInputOfType-int-("text", "text"));</remarks>
	public static object ForceInputOfType<T>(string prompt, string error) => ForceInputOfType<T>(prompt, error, EasyGraphics.CurrentColor);
	///<summary>This will lock the end-user in an input loop that they cannot escape unless they give a valid input of type T</summary>
	///<remarks>The value is then returned as an object, meaning you need to case the return to the type you want it to be.
	///Like so: int i = (ForceInputOfType-int-("text", "text"));</remarks>
	public static object ForceInputOfType<T>(string prompt, string error, ConsoleColor inputColor, ConsoleColor errorColor = ConsoleColor.Red)
	{
		bool containsErrorMessage = false;

		while (true)
		{

			if (prompt.Length > 0)
				Console.Write(prompt);


			EasyGraphics.ColorFlowBegin(inputColor);
			string input = Console.ReadLine();
			EasyGraphics.ColorFlowEnd();

			try
			{
				object returnValue = (T)Convert.ChangeType(input, typeof(T));
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