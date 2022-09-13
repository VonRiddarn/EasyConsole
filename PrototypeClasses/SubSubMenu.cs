using VonRiddarn.EasyConsole.Graphics;
using VonRiddarn.EasyConsole.Menu;

namespace VonRiddarn.EasyConsole.Prototyping;
public class SubSubMenu : EasyMenu
{
	protected override void ConfirmSelection(string buttonID)
	{
		if(buttonID == "ID_D")
			ExitMenu();
	}

	protected override void DrawMenu()
	{
		EasyGraphics.DrawHeader("SUB SUB MENU", ConsoleColor.Red);
		DrawButtons();
		EasyGraphics.DrawLine();
	}

	protected override EasyButton[] InitializeButtons()
	{
		return new EasyButton[] 
		{
			new EasyButton("ID_A", "Wow. No out of bounds errors!"),
			new EasyButton("ID_B", "Another button"),
			new EasyButton("ID_C", "Test"),
			new EasyButton("ID_D", "Back"),
		};
	}
}