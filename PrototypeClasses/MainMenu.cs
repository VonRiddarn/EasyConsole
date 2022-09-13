using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Menu;
using VonRiddarn.EasyConsole.Utilities;

namespace VonRiddarn.EasyConsole.Prototyping;
public class MainMenu : EasyMenu
{
	SubMenu settingsMenu = new SubMenu();
	
	protected override void ConfirmSelection(string buttonID)
	{
		if(buttonID == "ID_SETTINGS")
		{
			settingsMenu.Start(this);
		}
		if(buttonID == "ID_CREDITS")
		{
			EasyGraphics.ColoredMessage("This library / framework(?) is made by: ", ConsoleColor.Blue, false);
			EasyGraphics.ColoredMessage("VonRiddarn", ConsoleColor.Yellow);
			EasyUtilities.WaitForKey();
		}
		if(buttonID == "ID_EXIT")
			Environment.Exit(0);
	}

	protected override void DrawMenu()
	{
		EasyGraphics.DrawHeader("Main Menu", ConsoleColor.Yellow);
		DrawButtons();
		EasyGraphics.DrawLine();
	}

	protected override EasyButton[] InitializeButtons()
	{
		return new EasyButton[] 
		{
			new EasyButton("ID_START", "Start Game"),
			new EasyButton("ID_SETTINGS", "Enter submenu"),
			new EasyButton("ID_CREDITS", "Credits"),
			new EasyButton("ID_INFO", "Info"),
			new EasyButton("ID_EXIT", "Exit")
		};
	}
}