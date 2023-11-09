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

		// Test the forced input:
		int i = EasyUtilities.ForceInputOfType<int>("Enter int: ", "Must be an int!");
		float fl = EasyUtilities.ForceInputOfType<float>("Enter float: ", "Must be an float!");
		double db = EasyUtilities.ForceInputOfType<double>("Enter double: ", "Must be an double!");
		char ch = EasyUtilities.ForceInputOfType<char>("Enter char: ", "Must be an char!");

		// This is absolutely unnecessary. I was just checking the limits of the method.
		string s = EasyUtilities.ForceInputOfType<string>("Enter string: ", "Must be an string!");

		Console.WriteLine(i);
		Console.WriteLine(fl);
		Console.WriteLine(db);
		Console.WriteLine(db + fl);
		Console.WriteLine(db + fl + i);
		Console.WriteLine(ch);
		Console.WriteLine((int)ch);
		Console.WriteLine(s);
		Console.ReadKey();

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