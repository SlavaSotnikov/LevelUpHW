using System;

namespace Menu
{
    public class UI
    {
        public void DisplayAboutInfo(string source)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(35, 10);
            Console.WriteLine("This game was created by Slava Sotnikov.");
            Console.SetCursorPosition(35, 11);
            Console.WriteLine("It uses assets from http://patorjk.com.");
            Console.SetCursorPosition(35, 12);
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey(true);
            RunMainMenu();
        }
    }
}
