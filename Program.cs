using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Menu;
using VonRiddarn.EasyConsole.Prototyping;
using VonRiddarn.EasyConsole.Utilities;

internal class Program
{
	public static void Main(string[] args)
	{
		// TODO: Add comments to the project.... like.... for real.
		
		EasyGraphics.DrawHeader("Program");
		EasyGraphics.ColoredMessage("Wow, look at that header!", ConsoleColor.Cyan);
		EasyGraphics.ColorFlowBegin(ConsoleColor.Yellow);
		Console.WriteLine("This is inside a color flow!");
		EasyGraphics.DrawLine();
		EasyGraphics.ColorFlowBegin(ConsoleColor.Red);
		Console.WriteLine("We can even nest color flows!");
		EasyGraphics.DrawLine();
		EasyGraphics.ColoredMessage("And override the colors with colored messages!", ConsoleColor.Green);
		EasyGraphics.ColorFlowEnd(); // End flow 2 -> Red
		EasyGraphics.ColorFlowEnd(); // End flow 1 -> Yellow
		Console.WriteLine("Back to default colors ):");
		EasyGraphics.SetDefaultColor(ConsoleColor.Cyan);
		Console.WriteLine("But now the default color is cool!");
		EasyGraphics.DrawLine();
		EasyUtilities.WaitForKey();
		// Below this point we are testing the menu system, and it is NICE.
		// We need an instance of this running as we are using a singleton pattern.
		EasyGlobalInputManager inputManager = new EasyGlobalInputManager();
		// We need an instance of each menu.
		// We could have a masterclass with all the diffrent menues saved
		// Then use EasyMenu.ForceStart() to move on a larger scale - This is untested as of now though.
		// A lot more functionality will be added to the menu system soon.
		MainMenu mainMenu = new MainMenu();
		
		// Start the menu.
		mainMenu.Start();
	}
}