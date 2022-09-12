using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Utilities;

internal class Program
{
	public static void Main(string[] args)
	{
		
		EasyGraphics.DrawLine();
		
		EasyGraphics.DrawLine(ConsoleColor.Yellow);
		
		EasyGraphics.ColorStart(ConsoleColor.Red);
		
		EasyGraphics.DrawLine();
		EasyGraphics.DrawLine(ConsoleColor.Blue);
		Console.WriteLine("LOL THIS IS RED");
		
		EasyGraphics.ColorStart(ConsoleColor.Green);
		
		Console.WriteLine("AND THIS IS GREEN!");
		
		EasyGraphics.ColorEnd();
		
		Console.WriteLine("Man, I sure hope this is red...");
		
		EasyGraphics.ColorEnd();
		
		Console.WriteLine("And this is default!");
		
		EasyGraphics.DrawLine();
	}
}