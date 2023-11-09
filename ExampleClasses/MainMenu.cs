using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Menu;
using VonRiddarn.EasyConsole.Utilities;

namespace VonRiddarn.EasyConsole.Examples;
public class MainMenu : EasyMenu
{
	SubMenu subMenuInstance = new SubMenu();
	
	// This method is called from the base class to make it easier to implement buttons.
	protected override EasyButton[] InitializeButtons()
	{
		return new EasyButton[]
		{
			new EasyButton("BUTTON_ADD", "Add numbers"),
			new EasyButton("BUTTON_SUB", "Subtract numbers"),
			new EasyButton("BUTTON_MUL", "Multiply numbers"),
			new EasyButton("BUTTON_DIV", "Divide numbers"),
			new EasyButton("BUTTON_SUBMENU", "Enter submenu"),
			new EasyButton("BUTTON_EXIT", "Exit")
		};
	}

	// Needed implementation because it's abstract
	// Called after initialization but before the first itteration of the lifespan loop.
	protected override void OnStart() { }
	
	// Called each itteration of the lifespan loop.
	protected override void DrawMenu()
	{
		EasyGraphics.DrawHeader("Main Menu");

		DrawButtons();

		EasyGraphics.DrawLine();
	}
	
	// Called whenever the input system detects a button press.
	// Sends the ID of the button pressed as a parameter.
	protected override void ConfirmSelection(string buttonID)
	{
		if (buttonID == "BUTTON_ADD")
		{
			EasyGraphics.ColoredMessage("40 + 2 = ", ConsoleColor.Blue, false);
			EasyGraphics.ColoredMessage("42", ConsoleColor.Green);

			EasyUtilities.WaitForKey();
		}
		else if (buttonID == "BUTTON_SUB")
		{
			EasyGraphics.ColoredMessage("676 - 634 = ", ConsoleColor.Blue, false);
			EasyGraphics.ColoredMessage("42", ConsoleColor.Green);

			EasyUtilities.WaitForKey();
		}
		else if (buttonID == "BUTTON_MUL")
		{
			EasyGraphics.ColoredMessage("1000 * 0,042 = ", ConsoleColor.Blue, false);
			EasyGraphics.ColoredMessage("42", ConsoleColor.Green);

			EasyUtilities.WaitForKey();
		}
		else if (buttonID == "BUTTON_DIV")
		{
			EasyGraphics.ColoredMessage("1764 / 42 = ", ConsoleColor.Blue, false);
			EasyGraphics.ColoredMessage("42", ConsoleColor.Green);

			EasyUtilities.WaitForKey();
		}
		else if (buttonID == "BUTTON_SUBMENU")
		{
			// Since we are starting a menu from inside this menus lifespan loop
			// We MUST set ourselves as the submenus parent menu.

			subMenuInstance.Start(this);

			// We come back here when the submenu uses the ExitMenu method.
			// If we are not set as parents and the menus have a diffrent amount of buttons on their page
			// The global input system will throw an out of range exception.
		}
		else if (buttonID == "BUTTON_EXIT")
		{
			// Since we don't have a parent menu we will just exit the lifespan loop.
			ExitMenu();
		}
	}
}