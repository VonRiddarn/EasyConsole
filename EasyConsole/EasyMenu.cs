using VonRiddarn.EasyConsole.Graphics;

namespace VonRiddarn.EasyConsole.Menu;

public abstract class EasyMenu
{
	protected EasyButton[] buttons;

	public int MaxSelectionIndex { get { return buttons.Length-1; } }

	protected EasyMenu? parentMenu = null;
	protected bool exitMenu = false;

	protected ConsoleColor selectionColor = ConsoleColor.Green;
	protected ConsoleColor cursorColor = ConsoleColor.Green;
	protected string selectionCursor = "> ";
	
	
	public void Start(EasyMenu parentMenu) => Start(selectionColor, cursorColor, selectionCursor, parentMenu);
	public void Start() => Start(selectionColor, cursorColor, selectionCursor);
	public void Start(string selectionCursor) => Start(selectionColor, cursorColor, selectionCursor);
	public void Start(ConsoleColor selectionColor) => Start(selectionColor, selectionColor, selectionCursor);
	public void Start(ConsoleColor selectionColor, string selectionCursor) => Start(selectionColor, selectionColor, selectionCursor);
	public void Start(ConsoleColor selectionColor, ConsoleColor cursorColor, string selectionCursor, EasyMenu? parentMenu = null)
	{
		exitMenu = false;
		
		buttons = InitializeButtons();
		
		if (parentMenu != null)
			this.parentMenu = parentMenu;

		this.selectionColor = selectionColor;
		this.cursorColor = cursorColor;

		EasyGlobalInputManager.instance.InitializeNewMenu(MaxSelectionIndex);

		while (!exitMenu)
		{
			Console.Clear();

			DrawMenu();
			if (EasyGlobalInputManager.instance.ReadInput())
			{
				ConfirmSelection(buttons[EasyGlobalInputManager.instance.SelectedIndex].ID);
			}
		}
	}
	
	// TODO: Make sure to "unhack" this method.
	// We might want to be able to pass just the EasyMenu, and then have a property or something that sets everything else.
	// That way all we need to make sure is that we are passing a valid instance - which would be imposible not to do.
	public static void ForceStart(EasyMenu menu, ConsoleColor selectionColor, ConsoleColor cursorColor, string selectionCursor, EasyMenu? parentMenu = null)
	{
		menu.Start(selectionColor, cursorColor, selectionCursor, parentMenu);
	}
	
	protected void ExitMenu()
	{
		if (parentMenu != null)
			EasyGlobalInputManager.instance.InitializeNewMenu(parentMenu.MaxSelectionIndex);

		exitMenu = true;
	}

	protected void DrawButtons()
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			if (buttons[i] == buttons[EasyGlobalInputManager.instance.SelectedIndex])
				buttons[i].Draw(selectionCursor, cursorColor, selectionColor);
			else
				buttons[i].Draw();
		}
	}
	
	protected abstract EasyButton[] InitializeButtons();
	// EXAMPLE: return new Button[] {new Button("ID_START", "Start Game")}
	
	protected abstract void DrawMenu();
	// EXAMPLE: DrawButtons();

	protected abstract void ConfirmSelection(string buttonID);
	// EXAMPLE: EasyGraphics.ColoredMessage($"You pressed button with ID:{buttonID}!", ConsoleColor.Green);
}