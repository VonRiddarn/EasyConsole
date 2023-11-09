using VonRiddarn.EasyConsole.Graphics;

namespace VonRiddarn.EasyConsole.Menu
{
	public abstract class EasyMenu
	{
		// The idea with the ID is to add a EasyMenuManager in the future (or implement it into EasyMenu)
		// Where there is a list of all menu instances, and you can reference them by doing:
		// EasyMenuManager.GetMenuFromID(id) -> Loop list -> Return first instance match as EasyMenu.
		// This means we could move the ForceStart method:
		// EasyMenuManager.ForceStart(menuId, parentMenuId) -> We can pass in either objects or IDs with overloads.
		// The problem with using something like ForceStart is that in a worst case scenario, we dive into an endless callstack. =bad ): 
		// 
		// Also, now that we have OnStart() we could implement EasyMenuManager.AddToGlobalMenuList(EasyMenu menu)
		// And have the user add their menu in the start method.
		// In the AddToGlobalMenuList we just need to make sure that the menu we are trying to add isn't already in the list.

		// TODO: Make the cursor a set array of 2 strings.
		// index 0 = prefixCursor | inxex 1 = suffixCursor
		// That way we can make 2 arrows pointing at the element like so:
		// > button <

		// Since we are using the singleton pattern, we know the instance of EasyGlobalInput should not be null
		// Therefore we are applying the null forgiving operator to it so we don't get loads of nullable errors from the compiler.
		// EG: EasyGlobalInputManager.instance!.InitializeNewMenu(MaxSelectionIndex); Notice the !
		// A "problem" with this would be if the instance IS null. Because then there would be hell to pay.

		// Static
		static string[] defaultSelectionCursor = new string[2] { "> ", string.Empty };
		public static string[] DefaultSelectionCursor { get { return new string[] { defaultSelectionCursor[0], defaultSelectionCursor[1] }; } }

		// Instance
		protected string id = string.Empty;
		public string ID { get { return id; } }

		protected bool keepAlive = true;
		protected bool clearOnDrawMenu = true;

		protected EasyMenu? parentMenu = null;

		protected EasyButton[] buttons = new EasyButton[0];
		public int MaxSelectionIndex { get { return buttons.Length - 1; } }

		protected ConsoleColor selectionTextColor = ConsoleColor.Green;
		public ConsoleColor SelectionTextColor { get { return selectionTextColor; } }

		protected ConsoleColor selectionCursorColor = ConsoleColor.Green;
		public ConsoleColor SelectionCursorColor { get { return selectionCursorColor; } }

		protected string[] selectionCursor = DefaultSelectionCursor;
		public string[] SelectionCursor { get { return new string[] { selectionCursor[0], selectionCursor[1] }; } }

		///<summary>Starts the lifespan loop of the menu instance.</summary>
		///<remarks>Parent menu is only to be used when calling a new menu INSIDE another menu's LIFESPAN LOOP.<br/>
		///This means the parent menu will always get passed as "this".<br/>
		/// Trying to use it for any other purpose will lead to catastrophic failures.</remarks>
		public void Start(EasyMenu? parentMenu = null)
		{
			keepAlive = true;

			buttons = InitializeButtons();

			EasyGlobalInputManager.instance!.InitializeNewMenu(MaxSelectionIndex);

			if (parentMenu != null)
				this.parentMenu = parentMenu;


			OnStart();

			// Lifespan loop
			while (keepAlive)
			{
				// TODO: Initialize the menu here insted.
				// On the InitializeNewMenu call, check if the parameters do NOT match with the index.
				// Also, check if the currentmenu in the input system is = to this menu.
				// If yes, keep button index
				// If no : Reset button index and set the current menu to this
				// That means we don't need to pass a parent when we initialize a menu, and we can jump between any menus.
				// To make sure we aren't creating infinite callstacks we could simply keep all menus in a list
				// If we go to a menu that already exists in the list, force quit all the menus all the way back to that list ? 

				// We still need to initialize the buttons above the OnStart.

				if (clearOnDrawMenu)
					Console.Clear();

				DrawMenu();

				if (EasyGlobalInputManager.instance.ReadInput())
					ConfirmSelection(buttons[EasyGlobalInputManager.instance.SelectedIndex].ID);
			}
		}


		///<summary>Exit the menu</summary>
		///<remarks>If a parent menu exists, this method will initialize that menus index to the global input system 
		///before existing its lifespan loop.</remarks>
		protected void ExitMenu()
		{
			if (parentMenu != null)
				EasyGlobalInputManager.instance!.InitializeNewMenu(parentMenu.MaxSelectionIndex);

			keepAlive = false;
		}

		///<summary>Draw all the buttons on the screen.</summary>
		///<remarks>This will automatically consider if the button is selected or not and draw the cursor as well as change the color</remarks>
		protected void DrawButtons()
		{
			for (int i = 0; i < buttons.Length; i++)
			{
				if (buttons[i] == buttons[EasyGlobalInputManager.instance!.SelectedIndex])
					buttons[i].Draw(selectionCursor, selectionCursorColor, selectionTextColor);
				else
					buttons[i].Draw();
			}
		}

		#region Protected abstract dependencies / promises

		///<summary>This method is used to create menu buttons.</summary>
		///<remarks>Return an array of the buttons you wish to add, like so: 
		///return new EasyButton[] { new EasyButton("BUTTON_ID", "Button text") };</remarks>
		protected abstract EasyButton[] InitializeButtons();

		///<summary>This method runs after menu initialization but before the first Draw call.</summary>
		///<remarks>Although this starts with "On" it isn't technically an event. 
		///It's just a method that runs within the Start method each time it's called.</remarks>
		protected abstract void OnStart();
		// TODO: Think about if ^this should be abstract or virtual

		///<summary>This is called each time the menu loop udates.</summary>
		///<remarks>Don't forget to use the DrawButtons method in here to get your buttons drawn on the screen.</remarks>
		protected abstract void DrawMenu();

		///<summary>This is called whenever the end-user presses the confirm key on a button.</summary>
		///<remarks>The buttonID represents the ID you created for each button in the InitializeButtons method.</remarks>
		protected abstract void ConfirmSelection(string buttonID);
		// EXAMPLE: EasyGraphics.ColoredMessage($"You pressed button with ID:{buttonID}!", ConsoleColor.Green);

		#endregion

		#region Public setters

		///<summary>Sets the cursor for this menu instance.</summary>
		public void SetSelectionCursor(string selectionCursorPrefix, string selectionCursorSuffix)
		{
			selectionCursor[0] = selectionCursorPrefix;
			selectionCursor[1] = selectionCursorSuffix;
		}
		///<summary>Sets the cursor color for this menu instance.</summary>
		/// <remarks>Allows you to also override the selection text color.</remarks>
		public void SetSelectionCursor(ConsoleColor selectionCursorColor, bool overrideSelectionColor)
		{
			this.selectionCursorColor = selectionCursorColor;

			if (overrideSelectionColor)
				this.selectionTextColor = selectionCursorColor;
		}
		///<summary>Sets the cursor and its color for this menu instance.</summary>
		///<remarks>Allows you to also override the selection text color.</remarks>
		public void SetSelectionCursor(string[] selectionCursor, ConsoleColor selectionCursorColor, bool overrideSelectionTextColor)
		{
			this.selectionCursor = selectionCursor;
			this.selectionCursorColor = selectionCursorColor;

			if (overrideSelectionTextColor)
				this.selectionTextColor = selectionCursorColor;
		}
		///<summary>Sets the color of the button text for this menu instance.</summary>
		/// <remarks>Allows you to also override the cursor color.</remarks>
		public void SetSelectionColor(ConsoleColor selectionTextColor, bool overrideCursorColor)
		{
			this.selectionTextColor = selectionTextColor;
			if (overrideCursorColor)
				this.selectionCursorColor = selectionTextColor;
		}

		///<summary>Sets the bool for if the console should be cleared each update in the lifespan loop.</summary>
		public void SetClearOnDrawMenu(bool clearOnDrawMenu) => this.clearOnDrawMenu = clearOnDrawMenu;

		///<summary>Allows you to change the menu ID at runtime.</summary>
		/// <remarks>This method is for edge case scenarios and is NOT recommended for regular use.</remarks>
		public void SetID(string newID) => this.id = newID;

		#endregion

		#region Public static setters

		public static void SetDefaultCursor(string[] newCursor) => defaultSelectionCursor = newCursor;

		#endregion

	}
}