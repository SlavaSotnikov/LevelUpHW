using System;
using System.Text;

namespace Menu
{
    public class UI
    {
        public readonly string[] _options = { "1 PLAYER", "2 PLAYERS", "About", "Exit" };

        public static void ShowTitle(object sender, EventArgs e)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.Title = "Space Invaders";

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Text.Title);
            Console.ForegroundColor = prevColor;

            Console.OutputEncoding = Encoding.UTF8;

            //Menu.DisplayOptions();

            Console.SetCursorPosition(47, 25);
            Console.WriteLine("\xA9 2021 LevelUp\x2122");
        }

        public static void DisplayAboutInfo(string source)
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
        }
    }
}
