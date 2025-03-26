using System.Globalization;
using Microsoft.VisualBasic;

public class Room
{
    public bool Entered {get; set;}

    public Room ()
    {

    }

    public void PrintRoom(int x, int y, string characterSprite)
    {
        if(!Entered)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.SetCursorPosition(Console.CursorLeft+(x*7), 0 + (y*3));
        Console.WriteLine("*******");
        Console.SetCursorPosition(Console.CursorLeft+(x*7), 0 + (y * 3) + 1);
        Console.WriteLine(characterSprite);
        Console.SetCursorPosition(Console.CursorLeft+(x*7), 0 + (y * 3) + 2);
        Console.WriteLine("*******");
    }
}