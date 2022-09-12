namespace VonRiddarn.EasyConsole.Graphics;

public static class EasyGraphics
{
	static string originalLine = "--------------------------------------------------";
	static string line = originalLine;

	static ConsoleColor cachedColor = Console.ForegroundColor;
	static ConsoleColor currentColor = cachedColor;
	public static ConsoleColor CurrentColor { get { return currentColor; } }
	
	static ConsoleColor internalCachedColor = Console.ForegroundColor;

	public static void ColorStart(ConsoleColor color)
	{
		cachedColor = Console.ForegroundColor;
		Console.ForegroundColor = color;
		
		currentColor = Console.ForegroundColor;
	}
	
	public static void ColorEnd()
	{
		Console.ForegroundColor = cachedColor;
		internalCachedColor = cachedColor;
		
		currentColor = Console.ForegroundColor;
	}
	
	// TODO: Rename to ColoredMessage
	public static void ColorMessage(string message, ConsoleColor color, bool useWriteLine = true)
	{

		InternalColorStart(color);

		if (useWriteLine)
			Console.WriteLine(message);
		else
			Console.Write(message);

		InternalColorEnd();
	}
	
	
	public static void DrawLine() => DrawLine(0, currentColor);
	public static void DrawLine(int lineOffset) => DrawLine(lineOffset, currentColor);
	public static void DrawLine(ConsoleColor color) => DrawLine(0, color);
	public static void DrawLine(int lineOffset, ConsoleColor color)
	{
		InternalColorStart(color);
		
		Console.CursorTop += lineOffset;
		Console.WriteLine(line);
		Console.CursorTop -= lineOffset;
		
		InternalColorEnd();
	}
	
	public static string? ColoredInput(ConsoleColor color)
	{
		InternalColorStart(color);
		string? returnString = Console.ReadLine();
		InternalColorEnd();
		
		return returnString;
	}
	
	// Internal methods!
	static void InternalColorStart(ConsoleColor color)
	{
		internalCachedColor = Console.ForegroundColor;
		Console.ForegroundColor = color;
	}
	public static void InternalColorEnd() => Console.ForegroundColor = internalCachedColor;
	
	
	public static bool IsCachedColor(ConsoleColor color)
	{
		return color == cachedColor;
	}
	
}