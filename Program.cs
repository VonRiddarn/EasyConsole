using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Utilities;

internal class Program
{
	public static void Main(string[] args)
	{
		EasyGraphics.SetDefaultColor(ConsoleColor.Magenta);

		Console.WriteLine("Default color text.");
		Console.WriteLine(Console.CursorTop);
		EasyGraphics.ColorFlowBegin(ConsoleColor.Cyan);
		Console.WriteLine("Colorflow colored text.");

		EasyGraphics.ColoredMessage(">Green text!", ConsoleColor.Green);

		EasyGraphics.ColoredMessage("Blue Prompt (with red input): ", ConsoleColor.Blue, false);
		string? s = EasyGraphics.ColoredInput(ConsoleColor.Red);
		Console.WriteLine(s);
		Console.WriteLine("Still colorflow text.");

		EasyGraphics.ColorFlowEnd();
		
		EasyUtilities.ForceInputInt("write a number: ", "Input bust be a number!", EasyGraphics.CurrentColor, ConsoleColor.Yellow);
		EasyGraphics.DrawHeader("Hej!", ConsoleColor.Green, ConsoleColor.Cyan);
		EasyGraphics.SetLine("-_--_--_--_--_--_--_--_--_--_--_--_--_--_-");
		EasyGraphics.DrawLine();
		Console.WriteLine("Man, that looked awful...");
		EasyGraphics.ResetLine();
		EasyGraphics.DrawLine();
		Console.WriteLine("That's better!");
		Console.ReadLine();
		Console.WriteLine(Console.CursorTop);
		Console.WriteLine(Console.CursorTop);
		Console.WriteLine(Console.CursorTop);
		Console.WriteLine(Console.CursorTop);

		Console.WriteLine("Wellp, back to default, lets change it to green.");
		EasyGraphics.SetDefaultColor(ConsoleColor.Green);
		Console.WriteLine("Yeah, now it's green.");
	}
}