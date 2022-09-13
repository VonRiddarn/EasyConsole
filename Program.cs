using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Menu;
using VonRiddarn.EasyConsole.Prototyping;
using VonRiddarn.EasyConsole.Utilities;

internal class Program
{
	public static void Main(string[] args)
	{
		// We need an instance of this running as we are using a singleton pattern.
		EasyGlobalInputManager inputManager = new EasyGlobalInputManager();
		// We need an instance of each menu.
		// We could have a masterclass with all the diffrent menues saved
		// Then use EasyMenu.ForceStart() to move on a larger scale - This is untested as of now though.
		// A lot more functionality will be added to the menu system soon.
		MainMenu mainMenu = new MainMenu();
		
		// Start the menu.
		mainMenu.Start();
		
		
		// TODO: Add comments.... like.... for real.
		
	}
}