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
	// TODO: Fix so this can be set withing a colorflow nest
	public static void SetDefaultColor(ConsoleColor color)
	{
		cachedColors[0] = color;
		Console.ForegroundColor = CurrentColor;
	}

	// Makse sure to tell the users not to use this unless needed.
	// This will clear the color cache and mess up any and all ColorFlows that has not been ended.
	public static void ResetColorCache()
	{
		ConsoleColor c = DefaultColor;
		cachedColors = new List<ConsoleColor>() { DefaultColor };
	}
	#endregion

	#region COLORFLOW - ColorFlowBegin, ColorFlowEnd
	public static void ColorFlowBegin(ConsoleColor color)
	{
		Console.ForegroundColor = color;
		cachedColors.Add(Console.ForegroundColor);
		currentColorCacheIndex += 1;
	}

	public static void ColorFlowEnd()
	{
		currentColorCacheIndex--;
		Console.ForegroundColor = cachedColors[currentColorCacheIndex];

		cachedColors.RemoveAt(cachedColors.Count - 1);
	}
	#endregion

	#region DRAWCALLS - ColoredMessage, ColoredInput
	public static void ColoredMessage(string message, ConsoleColor color, bool useWriteLine = true)
	{

		ColorFlowBegin(color);

		if (useWriteLine)
			Console.WriteLine(message);
		else
			Console.Write(message);

		ColorFlowEnd();
	}

	public static string? ColoredInput(ConsoleColor color)
	{
		ColorFlowBegin(color);
		string? returnString = Console.ReadLine();
		ColorFlowEnd();

		return returnString;
	}
	#endregion

	#region HEADER - Draw
	///<summary>Draw a header with the specified title.</summary>
	///<remarks>Overloads for this method makes you able to overrride text and line colors.</remarks>
	public static void DrawHeader(string title) => DrawHeader(title, CurrentColor, CurrentColor);
	///<summary>Draw a header with the specified title using the title color.</summary>
	///<remarks>Overloads for this method makes you able to overrride line colors as well.</remarks>
	public static void DrawHeader(string title, ConsoleColor textColor) => DrawHeader(title, textColor, CurrentColor);
	///<summary>Draw a header with the specified title using the title and line colors.</summary>
	public static void DrawHeader(string title, ConsoleColor textColor, ConsoleColor lineColor)
	{
		DrawLine(lineColor);
		ColoredMessage(title, textColor);
		DrawLine(lineColor);
	}
	#endregion

	#region LINE - Draw, Set, Reset
	///<summary>Draw a line</summary>
	///<remarks>Overloads for this method makes you able to override the color.</remarks>
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