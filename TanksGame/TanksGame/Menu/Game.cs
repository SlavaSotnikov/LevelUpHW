using System;

namespace Menu
{
    class Game
    {
        public void Start()
        {
            Console.Title = "Space Invaders";

            RunMainMenu();
        }

        private void RunMainMenu()
        {
            Console.CursorVisible = false;

            
            
            string[] options = { "1 PLAYER", "2 PLAYERS", "About", "Exit" };
            Menu mainMenu = new Menu(Text.Title, options);
            int selectedIndex = mainMenu.Run();

            Options menu = (Options)selectedIndex;

            switch (menu)
            {
                case Options.OnePlayer:
                    RunFirstChoice();
                    break;
                case Options.TwoPlayers:
                    RunSecondChoice();
                    break;
                case Options.About:
                    DisplayAboutInfo(Text.About);
                    break;
                case Options.Exit:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }

        private void ExitGame()
        {
            Console.WriteLine("\n\t\t\t\t\t   Press any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        private void DisplayAboutInfo(string source)
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

        private void RunFirstChoice()
        {
            Console.WriteLine("\n\t\t\t\t\t  Placeholder for 1st choice");
            ExitGame();
        }

        private void RunSecondChoice()
        {
            Console.WriteLine("\n\t\t\t\t\t  Placeholder for 2nd choice");
        }
    }
}
