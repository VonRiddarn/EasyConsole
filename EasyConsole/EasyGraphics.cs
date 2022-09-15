namespace VonRiddarn.EasyConsole.Graphics;

public static class EasyGraphics
{
	static string originalLine = "--------------------------------------------------";
	static string currentLine = originalLine;

	static List<ConsoleColor> cachedColors = new List<ConsoleColor>() { Console.ForegroundColor };
	static int currentColorCacheIndex = 0;

	public static ConsoleColor CurrentColor { get { return cachedColors[currentColorCacheIndex]; } }
	public static ConsoleColor DefaultColor { get { return cachedColors[0]; } }

	static ConsoleColor internalCachedColor = Console.ForegroundColor;


	#region SETTINGS - SetDefaultColor, ResetColorCache
	
	///<summary>Sets the default color of the console.</summary>
	///<remarks>Note: This is the local default value stored in the cache for EasyGraphics, 
	///not the default value that can be found in the Console class.</remarks>
	public static void SetDefaultColor(ConsoleColor color)
	{
		cachedColors[0] = color;
		Console.ForegroundColor = CurrentColor;
	}
	
	
	// TODO: Rename this to something like "ColorFlowEndAll"
	// Makse sure to tell the users not to use this unless needed.
	// This will clear the color cache and mess up any and all ColorFlows that has not been ended.
	///<summary>This method is currently experimental. It should not be used</summary>
	public static void ResetColorCache()
	{
		ConsoleColor c = DefaultColor;
		cachedColors = new List<ConsoleColor>() { DefaultColor };
	}
	#endregion

	#region COLORFLOW - ColorFlowBegin, ColorFlowEnd
	
	///<summary>Start a color flow with the specified color.</summary>
	///<remarks>A color flow will change all console colors to the specified color until stopped by the ColorFlowEnd method.<br/>
	///Infinite color flows can be nested, but they must all have an individual ColorFlowEnd call. 
	///Any EasyGraphics method that has a color attribute / parameter can overwrite the color flow. 
	///You can always access the current color represented with the EasyGraphics.CurrentColor property.</remarks>
	public static void ColorFlowBegin(ConsoleColor color)
	{
		Console.ForegroundColor = color;
		cachedColors.Add(Console.ForegroundColor);
		currentColorCacheIndex += 1;
	}
	
	///<summary>End the last started color flow.</summary>
	public static void ColorFlowEnd()
	{
		//TODO: Add a failsafe so that if the color cahce is cleared we wont actually do anything here (other than sending a warning)
		// If cache looks good: Do the thing
		// Else ColoredMessage("Color cache is empty, there is no flow to end.", ConsoleColor.Yellow);
		currentColorCacheIndex--;
		Console.ForegroundColor = cachedColors[currentColorCacheIndex];

		cachedColors.RemoveAt(cachedColors.Count - 1);
	}
	
	#endregion

	#region DRAWCALLS - ColoredMessage, ColoredInput
	
	///<summary>Send a colored message to the console using either Write or WriteLine(default).</summary>
	public static void ColoredMessage(string message, ConsoleColor color, bool useWriteLine = true)
	{
		ColorFlowBegin(color);

		if (useWriteLine)
			Console.WriteLine(message);
		else
			Console.Write(message);

		ColorFlowEnd();
	}
	
	///<summary>Functions the same as Console.Readline except the user input text is colored.</summary>
	public static string? ColoredInput(ConsoleColor color)
	{
		ColorFlowBegin(color);
		string? returnString = Console.ReadLine();
		ColorFlowEnd();

		return returnString;
	}
	
	#endregion

	#region HEADER - Draw
	
	///<summary>Draw a header with the specified title using the current color of the console.</summary>
	public static void DrawHeader(string title) => DrawHeader(title, CurrentColor, CurrentColor);
	
	///<summary>Draw a header with the specified title and text color.</summary>
	public static void DrawHeader(string title, ConsoleColor textColor) => DrawHeader(title, textColor, CurrentColor);
	
	///<summary>Draw a header with the specified title and text / line colors.</summary>
	public static void DrawHeader(string title, ConsoleColor textColor, ConsoleColor lineColor)
	{
		DrawLine(lineColor);
		ColoredMessage(title, textColor);
		DrawLine(lineColor);
	}
	
	// TODO: Make a method for editing headers (?) maybe.
	
	#endregion

	#region LINE - Draw, Set, Reset
	
	///<summary>Draw a line using the current color of the console</summary>
	public static void DrawLine() => DrawLine(CurrentColor);
	
	///<summary>Draw a line with the specified color</summary>
	public static void DrawLine(ConsoleColor color)
	{
		ColorFlowBegin(color);

		Console.WriteLine(currentLine);

		ColorFlowEnd();
	}

	///<summary>Set the string to use with all DrawLine calls.</summary>
	///<remarks>This includes the lines in headers. Can be reset with ResetLine.</remarks>
	public static void SetLine(string line) => currentLine = line;
	
	///<summary>Resets the DrawLine calls to use the default line (50x '-').</summary>
	public static void ResetLine() => currentLine = originalLine;
	
	#endregion

}