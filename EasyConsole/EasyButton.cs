using VonRiddarn.EasyConsole.Graphics;

public class EasyButton
{
	string id = "";
	public string ID { get {return id; } }
	
	int index = 0;
	public int Index { get { return index; } }

	string text = "";
	public string Text { get { return text; } }

	// TODO: Add a parameter for overriding the color of unselected buttons.
	// This lamda might work, IDK haven't tested it lol...
	//public Button(string ID, string text) => new Button(ID, text, EasyGraphics.CurrentColor); 
	// The thought is that the button requires a color always, but we add it behind the scenes
	// Like we have done for many other overloads.
	// Alternative: Have 2 Constructors. One of them sets the overrideColor, one does not.
	public EasyButton(string ID, string text)
	{
		// overrideColor = EasyGraphics.CurrentColor;
		this.id = ID;
		this.text = text;
	}
	
	///<summary>Draw a button that is not selected.</summary>
	public void Draw() => Console.WriteLine(text);
	
	///<summary>Draw a button that is selected.</summary>
	public void Draw(string[] selectionCursor, ConsoleColor cursorColor, ConsoleColor selectionColor)
	{
		EasyGraphics.ColoredMessage(selectionCursor[0], cursorColor, false);
		EasyGraphics.ColoredMessage($"{text}", selectionColor, false);
		EasyGraphics.ColoredMessage(selectionCursor[1], cursorColor, true);
	}
	
}