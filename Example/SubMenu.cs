using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Menu;
using VonRiddarn.EasyConsole.Utilities;

namespace VonRiddarn.EasyConsole.Examples;
public class SubMenu : EasyMenu
{

	SubSubMenu subSubMenu = new SubSubMenu();

	protected override EasyButton[] InitializeButtons()
	{
		return new EasyButton[]
		{
			new EasyButton("BUTTON_SUBMENU", "Go deeper!"),
			new EasyButton("BUTTON_USELESS", "Useless button"),
			new EasyButton("BUTTON_BACK", "Back"),
		};
	}

	protected override void OnStart()
	{
		// There are methods for overriding diffrent things in the menu.
		// Such as: Selection curspr, cursor color and button text color
		// The default cursor is "> " and can be accessed with the EasyMenu.DefaultSelectionCursor property.
		// The default cursor can be changed with EasyMeny.SetDefaultSelectionCursor(newCursor)
		SetSelectionCursor(">> ", " <-><<");
	}

	protected override void DrawMenu()
	{
		EasyGraphics.DrawHeader("SUB MENU", EasyGraphics.CurrentColor, ConsoleColor.Yellow);

		DrawButtons();

		EasyGraphics.DrawLine(ConsoleColor.Yellow);
	}

	protected override void ConfirmSelection(string buttonID)
	{
		if (buttonID == "BUTTON_SUBMENU")
		{
			// Since we are starting this menu from inside a lifespan loop
			// We must NEVER forget to add this instance as a parameter.
			subSubMenu.Start(this);
		}
		else if (buttonID == "BUTTON_USELESS")
		{
			EasyGraphics.ColoredMessage("Wow, good job pressing that button...", ConsoleColor.Yellow);
			EasyUtilities.WaitForKey();
		}
		else if (buttonID == "BUTTON_BACK")
		{
			// This will automatically take parent class into consideration
			// and exit the lifespan loop after setting the global input index.
			ExitMenu();
		}
	}
}