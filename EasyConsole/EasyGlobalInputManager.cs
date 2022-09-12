namespace VonRiddarn.EasyConsole.Menu;

public class EasyGlobalInputManager
{
	// This system is using a singleton pattern
	public static EasyGlobalInputManager? instance = null;
	
	int selectedIndex = 0;
	int maxIndex = 0;
	
	bool confirmSelection = false;
	public bool ConfirmSelection {get { return confirmSelection; } }
	
	// Chache the input key to save memory
	ConsoleKey currentInput = ConsoleKey.NoName;
	ConsoleKey confirmKey = ConsoleKey.NoName;
	
	public EasyGlobalInputManager(ConsoleKey confirmKey = ConsoleKey.Enter)
	{
		if(instance != null)
		{
			ConsoleColor color = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Warning: A singleton of GlobalInputManager already exists.");
			Console.ForegroundColor = color;
			return;
		}
		
		instance = this;
		this.confirmKey = confirmKey;
	}
	
	public void ReadInput()
	{
		currentInput = Console.ReadKey().Key;
		ProcessInput();
	}
	
	void ProcessInput()
	{
		// Arrow keys = move the selected index
		// Enter = Confirm
		// We may want to store a reference to the buttons of the currently initialized menu
		// So that we may run their method right from here?
		// Oterwise just confirm selection and move on.
		// Alternative: We save a reference to the current menu:
		// And when we confirm we run a confirm command on that menu sending through the index of the button we pressed.
	}
	
	public void InitializeNewMenu(Button[] buttons)
	{
		selectedIndex = 0;
		maxIndex = 0;
		confirmSelection = false;
		
		for(int i = 0; i < buttons.Length; i++)
		{
			RegisterButton(buttons[i].Index);
		}
	}
	
	// TODO: Maybe add the possibility to send a method in the parameter
	// so that we can call the methods straight from the InputSystem instead of locally?
	void RegisterButton(int localIndex)
	{
		if(localIndex > maxIndex)
			maxIndex = localIndex;
	}
	
}