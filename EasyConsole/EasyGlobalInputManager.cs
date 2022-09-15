using VonRiddarn.EasyConsole.Graphics;

namespace VonRiddarn.EasyConsole.Menu;

public class EasyGlobalInputManager
{

	// TODO: Add an event for each time the readkey method has run.
	// That way if we want to listen for a sequence of keys, or a specific key, it's possible.

	// This system is using a singleton pattern
	public static EasyGlobalInputManager? instance = null;

	int selectedIndex = 0;
	public int SelectedIndex { get { return selectedIndex; } }
	
	int maxSelectionIndex = 0;

	bool confirmSelection = false;

	// Chache the input key to save memory - min maxing at its finest!
	ConsoleKey currentInput = ConsoleKey.NoName;
	ConsoleKey confirmKey = ConsoleKey.NoName;

	public EasyGlobalInputManager(ConsoleKey confirmKey = ConsoleKey.Enter)
	{
		if (instance != null)
		{
			EasyGraphics.ColoredMessage("Warning: A singleton of GlobalInputManager already exists.", ConsoleColor.Red);
			return;
		}

		instance = this;
		this.confirmKey = confirmKey;
	}
	
	///<summary>Called from a menu instances lifespan loop.</summary>
	///<remarks>Returns true if the key pressed is the confirmation key (default is enter).</remarks>
	public bool ReadInput()
	{
		currentInput = Console.ReadKey().Key;
		return ProcessInput();
	}
	
	///<summary>Process the input after it being read by ReadInput</summary>
	bool ProcessInput()
	{
		if (currentInput == confirmKey)
		{
			currentInput = ConsoleKey.NoName;
			return true;
		}

		if (currentInput == ConsoleKey.UpArrow)
		{
			if (selectedIndex - 1 >= 0)
				selectedIndex--;
			else
				selectedIndex = maxSelectionIndex;
		}
		else if (currentInput == ConsoleKey.DownArrow)
		{
			if (selectedIndex + 1 <= maxSelectionIndex)
				selectedIndex++;
			else
				selectedIndex = 0;
		}

		currentInput = ConsoleKey.NoName;
		return false;
		// Arrow keys = move the selected index
		// Enter = Confirm
		// We may want to store a reference to the buttons of the currently initialized menu
		// So that we may run their method right from here?
		// Oterwise just confirm selection and move on.
		// Alternative: We save a reference to the current menu:
		// And when we confirm we run a confirm command on that menu sending through the index of the button we pressed.
	}
	
	///<summary>Called from the Start method of menus</summary>
	///<remarks>Also called on ExitMenu if the parentmenu for the instance that calls ExitMenu is not null.
	///The index sent through in that case is parentMenu.MaxSelectionIndex</remarks>
	public void InitializeNewMenu(int maxSelectionIndex)
	{
		selectedIndex = 0;
		this.maxSelectionIndex = maxSelectionIndex;
		confirmSelection = false;
	}
}