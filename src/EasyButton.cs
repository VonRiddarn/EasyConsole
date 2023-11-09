using VonRiddarn.EasyConsole.Graphics;

namespace VonRiddarn.EasyConsole.Menu
{
	public class EasyButton
	{
		string id = "";
		public string ID { get {return id; } }
		
		int index = 0;
		public int Index { get { return index; } }

		string text = "";
		public string Text { get { return text; } }
		
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
}