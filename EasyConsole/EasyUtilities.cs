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


	// TODO: Anything that isn't this.
	// Fix this hacky mess...
	#region  Forced Inputs - aka Unholy hacky stuff meant to stay hidden from mere mortals
	public static int ForceInputInt(string prompt, string error) => ForceInputInt(prompt, error, EasyGraphics.CurrentColor);
	public static int ForceInputInt(string prompt, string error, ConsoleColor inputColor, ConsoleColor errorColor = ConsoleColor.Red)
	{
		bool containsErrorMessage = false;

		while (true)
		{
			if (prompt.Length > 0)
				Console.Write(prompt);

			EasyGraphics.ColorFlowBegin(inputColor);
			string input = Console.ReadLine();
			EasyGraphics.ColorFlowEnd();

			if (int.TryParse(input, out int value))
			{
				if (containsErrorMessage)
					EasyUtilities.ClearLine();

				return value;
			}
			else
			{
				// TODO: Make sure that we don't send error messages down.
				// We want to move the cursor up and remove the line to rewrite the message.
				if (error.Length > 0)
				{
					EasyGraphics.ColoredMessage(error, errorColor);
					containsErrorMessage = true;
					//Console.SetCursorPosition(0, Console.CursorTop - 2);
					EasyUtilities.ClearLine(-2, false);
				}
			}
		}
	}

	public static float ForceInputFloat(string prompt, string error) => ForceInputFloat(prompt, error, EasyGraphics.CurrentColor);
	public static float ForceInputFloat(string prompt, string error, ConsoleColor inputColor, ConsoleColor errorColor = ConsoleColor.Red)
	{
		bool containsErrorMessage = false;

		while (true)
		{
			if (prompt.Length > 0)
				Console.Write(prompt);

			EasyGraphics.ColorFlowBegin(inputColor);
			string input = Console.ReadLine();
			EasyGraphics.ColorFlowEnd();

			if (float.TryParse(input, out float value))
			{
				if (containsErrorMessage)
					EasyUtilities.ClearLine();

				return value;
			}
			else
			{
				// TODO: Make sure that we don't send error messages down.
				// We want to move the cursor up and remove the line to rewrite the message.
				if (error.Length > 0)
				{
					containsErrorMessage = true;
					EasyGraphics.ColoredMessage(error, errorColor);
					//Console.SetCursorPosition(0, Console.CursorTop - 2);
					EasyUtilities.ClearLine(-2, false);
				}
			}
		}
	}

	public static double ForceInputDouble(string prompt, string error) => ForceInputDouble(prompt, error, EasyGraphics.CurrentColor);
	public static double ForceInputDouble(string prompt, string error, ConsoleColor inputColor, ConsoleColor errorColor = ConsoleColor.Red)
	{
		bool containsErrorMessage = false;

		while (true)
		{
			if (prompt.Length > 0)
				Console.Write(prompt);

			EasyGraphics.ColorFlowBegin(inputColor);
			string input = Console.ReadLine();
			EasyGraphics.ColorFlowEnd();

			if (double.TryParse(input, out double value))
			{
				if (containsErrorMessage)
					EasyUtilities.ClearLine();

				return value;
			}
			else
			{
				// TODO: Make sure that we don't send error messages down.
				// We want to move the cursor up and remove the line to rewrite the message.
				if (error.Length > 0)
				{
					containsErrorMessage = true;
					EasyGraphics.ColoredMessage(error, errorColor);
					//Console.SetCursorPosition(0, Console.CursorTop - 2);
					EasyUtilities.ClearLine(-2, false);
				}
			}
		}
	}

	public static char ForceInputChar(string prompt, string error) => ForceInputChar(prompt, error, EasyGraphics.CurrentColor);
	public static char ForceInputChar(string prompt, string error, ConsoleColor inputColor, ConsoleColor errorColor = ConsoleColor.Red)
	{
		bool containsErrorMessage = false;

		while (true)
		{
			if (prompt.Length > 0)
				Console.Write(prompt);

			EasyGraphics.ColorFlowBegin(inputColor);
			string input = Console.ReadLine();
			EasyGraphics.ColorFlowEnd();

			if (char.TryParse(input, out char value))
			{
				if (containsErrorMessage)
					EasyUtilities.ClearLine();

				return value;
			}
			else
			{
				// TODO: Make sure that we don't send error messages down.
				// We want to move the cursor up and remove the line to rewrite the message.
				if (error.Length > 0)
				{
					containsErrorMessage = true;
					EasyGraphics.ColoredMessage(error, errorColor);
					//Console.SetCursorPosition(0, Console.CursorTop - 2);
					EasyUtilities.ClearLine(-2, false);
				}
			}
		}
	}

	#endregion

}