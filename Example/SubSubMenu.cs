using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Menu;
using VonRiddarn.EasyConsole.Utilities;

namespace VonRiddarn.EasyConsole.Examples;

public class SubSubMenu : EasyMenu
{
	protected override EasyButton[] InitializeButtons()
	{
		return new EasyButton[]
		{
			new EasyButton("BUTTON_REFLECT", "Reflection"),
			new EasyButton("BUTTON_BACK", "Back")
		};
	}

	protected override void OnStart()
	{
		// We can change the cursor if we want to.
		// Look at "SubMenu.cs" OnStart for a better explanation. 
		string[] cursor = new string[]{">>> ", " <<<"};
		SetSelectionCursor(cursor, ConsoleColor.Cyan, true);
	}

	protected override void DrawMenu()
	{
		EasyGraphics.DrawHeader("SUB-SUB MENU", ConsoleColor.Yellow, ConsoleColor.Blue);

		DrawButtons();

		EasyGraphics.DrawLine(ConsoleColor.Blue);
	}

	protected override void ConfirmSelection(string buttonID)
	{
		if (buttonID == "BUTTON_REFLECT")
		{
			EasyGraphics.ColoredMessage("Is it just me, or did that first page have an uncomfortable amount of references to HHGTTG?", ConsoleColor.Yellow);
			EasyUtilities.WaitForKey();
		}
		else if (buttonID == "BUTTON_BACK")
		{
			// Automatically takes the parent 
			ExitMenu();
		}
	}
}