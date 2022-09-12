using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Utilities;

internal class Program
{
	public static void Main(string[] args)
	{
		EasyGraphics.SetDefaultColor(ConsoleColor.Magenta);
		
		Console.WriteLine("Default color text.");
		
		EasyGraphics.ColorStart(ConsoleColor.Cyan);
		Console.WriteLine("Colorflow colored text.");
		
		EasyGraphics.ColoredMessage(">Green text!", ConsoleColor.Green);
		
		EasyGraphics.ColoredMessage("Blue Prompt (with red input): ", ConsoleColor.Blue, false);
		string? s = EasyGraphics.ColoredInput(ConsoleColor.Red);
		Console.WriteLine(s);
		Console.WriteLine("Still colorflow text.");
		
		EasyGraphics.ColorEnd();
		
		Console.WriteLine("Wellp, back to default, lets change it to green.");
		EasyGraphics.SetDefaultColor(ConsoleColor.Green);
		Console.WriteLine("Yeah, now it's green.");
	}
}