namespace VonRiddarn.EasyConsole.Menu;

public abstract class EasyMenu
{
	protected Button[] buttons;
	
	public void Start()
	{
		EasyGlobalInputManager.instance.InitializeNewMenu(buttons);
		
		while(!EasyGlobalInputManager.instance.ConfirmSelection)
		{
			DrawMenuUI();
			EasyGlobalInputManager.instance.ReadInput();
		}
	}
	
	protected virtual void DrawMenuUI()
	{
		// Here we draw the menu the way we want it.
		// This is the method that will loop.
		// Since it's directly related to the interface, this can be overridden.
		// This ensures that the users of this framework can make custom UI's without a problem.
	}
	
	protected void DrawButtons()
	{
		// Here we draw the menu's buttons
		// This will be used in the menu loop.
		// It displays all the buttons of the menu by calling the "Draw()" method on each of them.
	}
	
}