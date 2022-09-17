using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Menu;
using VonRiddarn.EasyConsole.Examples;
using VonRiddarn.EasyConsole.Utilities;

internal class Program
{
	public static void Main(string[] args)
	{
		// Get rid of that pesky white box.
		Console.CursorVisible = false;
		
		// Below this point we are testing the menu system, and it is NICE.
		// We need an instance of this running as we are using a singleton pattern.
		EasyGlobalInputManager inputManager = new EasyGlobalInputManager();
		
		// As the system stands today we need an instance of each menu.
		// You can pre create them in a master class, or create them on the fly.
		// Either way they need to be instantiated before they are called.
		
		MainMenu mainMenu = new MainMenu();
		
		// Start the lifespan loop of the menu.
		// No parent menu needed as the menu wont exit into another menus lifespan loop.
		mainMenu.Start();
		
		// We continue here when the menu has called ExitMenu
		
		EasyGraphics.ColoredMessage("So long, and thanks for all the fish!", ConsoleColor.Green);
	}
}