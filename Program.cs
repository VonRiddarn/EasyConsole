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
		
		EasyGraphics.ColorEnd();
		
		EasyGraphics.DrawLine();
	}
}