namespace VonRiddarn.EasyConsole.Graphics;

public static class EasyGraphics
{
	static string originalLine = "--------------------------------------------------";
	static string line = originalLine;

	static List<ConsoleColor> cachedColors = new List<ConsoleColor>(){Console.ForegroundColor};
	static int currentColorCacheIndex = 0;
	static ConsoleColor currentColor = cachedColors[0];
	public static ConsoleColor CurrentColor { get { return currentColor; } }
	
	static ConsoleColor internalCachedColor = Console.ForegroundColor;


	public static void SetDefaultColor(ConsoleColor color) => cachedColors[0] = color;

	public static void ColorStart(ConsoleColor color)
	{
		cachedColors.Add(Console.ForegroundColor);
		currentColorCacheIndex += 1;
		
		currentColor = color;
		Console.ForegroundColor = color;
	}
	
	public static void ColorEnd()
	{
		Console.ForegroundColor = cachedColors[currentColorCacheIndex];
		currentColorCacheIndex--;
		
		currentColor = cachedColors[currentColorCacheIndex];
		cachedColors.RemoveAt(cachedColors.Count-1);
	}
	
	// TODO: Rename to ColoredMessage
	public static void ColoredMessage(string message, ConsoleColor color, bool useWriteLine = true)
	{

		ColorStart(color);

		if (useWriteLine)
			Console.WriteLine(message);
		else
			Console.Write(message);

		ColorEnd();
	}
	
	
	public static void DrawLine() => DrawLine(0, CurrentColor);
	public static void DrawLine(int lineOffset) => DrawLine(lineOffset, CurrentColor);
	public static void DrawLine(ConsoleColor color) => DrawLine(0, color);
	public static void DrawLine(int lineOffset, ConsoleColor color)
	{
		ColorStart(color);
		
		Console.CursorTop += lineOffset;
		Console.WriteLine(line);
		Console.CursorTop -= lineOffset;
		
		ColorEnd();
	}
	
	public static string? ColoredInput(ConsoleColor color)
	{
		ColorStart(color);
		string? returnString = Console.ReadLine();
		ColorEnd();
		
		return returnString;
	}
	
	// Internal methods!
	/*static void InternalColorStart(ConsoleColor color)
	{
		internalCachedColor = Console.ForegroundColor;
		Console.ForegroundColor = color;
	}
	public static void InternalColorEnd() => Console.ForegroundColor = internalCachedColor;
	
	
	public static bool IsCachedColor(ConsoleColor color)
	{
		return color == cachedColor;
	}*/
	
}