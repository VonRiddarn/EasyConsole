# Easy Console

<p align="center">
  <img src="https://i.imgur.com/68XPEBA.png"/>
</p>
<p align="center">Easy to use library to handle graphics, inputs and menus in your .NET console project.</p>

## About

This is a simple library containing tools that makes it <span style="color:blue">easy</span> to develop nice looking and responsive .NET console applications.<br/>
The library is written in .NET 6.0 and has not been checked for backwards compatibility, it should however run smoothly on any and all versions of .NET & .NET Core.</br>

## IMPORTANT NOTICE:
This library is currently in very early stages of development.</br>
Should you come across this at this time, do NOT use it in production code as there will be many changes made to the core over the comming month(s).</br>
When this notice is removed from the readme file, the library has reached a stable condition and will be safe for production.

## What you can achieve
Something like this: https://i.imgur.com/gBkx6uf.png
Or this: https://i.imgur.com/rHAqO2H.png

Note: These screenshots are old and do not fully represent the state of the library.
For the best understanding look through the source.
The source is sadly uncommented as of now, but that will be fixed later this week.
Promise made (2022 - 09 - 14).

## How To use

These instructions are incomplete and subject to change.
The library is still in early development as stated above!

namespaces:
VonRiddarn.EasyConsole.Utilities = Tools for managing end-user input.
VonRiddarn.EasyConsole.Graphics = Tools for changing colors and displaying extras such as headers and lines.
VonRiddarn.EasyConsole.Menu = Tools for managing global end-user menu input and managing nestable menues.

Graphics (All commands must start with EasyGraphics.):

SetDefaultColor(ConsoleColor color)
> Set the default color for the terminal via the cached color system.

ColorFlowBegin(ConsoleColor color)
> Starts a colorflow.
> All writelines and other things inside of this flow will become a certain color.
> Can be nested within another colorflow.
> Can be overridden temporarily by any EasyGraphics elements that utilize colors, such as ColoredMessage.

ColorFlowEnd()
> Ends the last started color flow.
> If you have nested colorflows, you need one ColorFlowEnd for each of them.

ColoredMessage(string message, ConsoleColor color, bool useWriteLine = true)
> Send a colored message to the console.
> Utilizes Console.WriteLine by default, but can be changed in the 3rd parameter.

ColoredInput(ConsoleColor color)
> Utilizes and functions the exact same as Console.ReadLine.
> The only diffrence being you can change the color of the end-user input text.

DrawHeader(string title)
DrawHeader(string title, ConsoleColor textColor)
DrawHeader(string title, ConsoleColor textColor, ConsoleColor lineColor)
> Draw a header with a title.
> Overloads allow you to override the title and line colors.

DrawLine()
DrawLine(ConsoleColor color)
> Draw a line with the current color (affected by ColorFlow)
> Overload allows you to override the color.

SetLine(string line)
> Override the line that is drawn using DrawLine with a custom string.

ResetLine()
> Remove your nasty override because you realised my original line was better looking.

ResetColorCache()
> Force reset the color cache.
> This is currently dangerous to use...
> So don't use it.
