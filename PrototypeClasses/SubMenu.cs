using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Menu;

namespace VonRiddarn.EasyConsole.Prototyping;
public class SubMenu : EasyMenu
{

	SubSubMenu subSubMenu = new SubSubMenu();

	protected override void ConfirmSelection(string buttonID)
	{
		if (buttonID == "ID_A")
			subSubMenu.Start(this);
			
		if (buttonID == "ID_B")
			EasyMenu.ForceStart(parentMenu, selectionColor, cursorColor);
			
		else if (buttonID == "ID_C")
			ExitMenu();
	}

	protected override void DrawMenu()
	{
		EasyGraphics.DrawHeader("SUB MENU", ConsoleColor.Blue);
		DrawButtons();
		EasyGraphics.DrawLine();
	}

	protected override EasyButton[] InitializeButtons()
	{
		return new EasyButton[]
		{
			new EasyButton("ID_A", "Go deeper!"),
			new EasyButton("ID_B", "Force start parent"),
			new EasyButton("ID_C", "Back")
		};
	}
}