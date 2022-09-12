namespace VonRiddarn.EasyConsole.Graphics;

public static class EasyGraphics
{
	static string originalLine = "--------------------------------------------------";
	static string line = originalLine;

	static List<ConsoleColor> cachedColors = new List<ConsoleColor>(){Console.ForegroundColor};
	static int currentColorCacheIndex = 0;
	public static ConsoleColor CurrentColor { get { return cachedColors[currentColorCacheIndex]; } }
	
	static ConsoleColor internalCachedColor = Console.ForegroundColor;


	// TODO: Fix so this can be set withing a colorflow nest
	public static void SetDefaultColor(ConsoleColor color)
	{
		cachedColors[0] = color;
		Console.ForegroundColor = CurrentColor;
	}
	
	public static void ColorFlowStart(ConsoleColor color)
	{
		cachedColors.Add(Console.ForegroundColor);
		currentColorCacheIndex += 1;
		
		Console.ForegroundColor = color;
	}
	
	public static void ColorFlowEnd()
	{
		Console.ForegroundColor = cachedColors[currentColorCacheIndex];
		currentColorCacheIndex--;
		
		cachedColors.RemoveAt(cachedColors.Count-1);
	}
	
	// TODO: Rename to ColoredMessage
	public static void ColoredMessage(string message, ConsoleColor color, bool useWriteLine = true)
	{

		ColorFlowStart(color);

		if (useWriteLine)
			Console.WriteLine(message);
		else
			Console.Write(message);

		ColorFlowEnd();
	}
	
	
	public static void DrawLine() => DrawLine(0, CurrentColor);
	public static void DrawLine(int lineOffset) => DrawLine(lineOffset, CurrentColor);
	public static void DrawLine(ConsoleColor color) => DrawLine(0, color);
	public static void DrawLine(int lineOffset, ConsoleColor color)
	{
		ColorFlowStart(color);
		
		Console.CursorTop += lineOffset;
		Console.WriteLine(line);
		Console.CursorTop -= lineOffset;
		
		ColorFlowEnd();
	}
	
	public static string? ColoredInput(ConsoleColor color)
	{
		ColorFlowStart(color);
		string? returnString = Console.ReadLine();
		ColorFlowEnd();
		
		return returnString;
	}
}