using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Menu
{
    class Game
    {
        public void Start()
        {

            Title = "Space Invaders";

            RunMainMenu();
        }

        private void RunMainMenu()
        {
            CursorVisible = false;

            string prompt = @"
                      _____                        _____                     _               
                     / ____|                      |_   _|                   | |              
                    | (___  _ __   __ _  ___ ___    | |  _ ____   ____ _  __| | ___ _ __ ___ 
                     \___ \| '_ \ / _` |/ __/ _ \   | | | '_ \ \ / / _` |/ _` |/ _ \ '__/ __|
                     ____) | |_) | (_| | (_|  __/  _| |_| | | \ V / (_| | (_| |  __/ |  \__ \
                    |_____/| .__/ \__,_|\___\___| |_____|_| |_|\_/ \__,_|\__,_|\___|_|  |___/
                           | |                                                               
                           |_|                                                               
";
            
            string[] options = { "1 PLAYER", "2 PLAYERS", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    RunSecondChoice();
                    break;
                case 2:
                    DisplayAboutInfo();
                    break;
                case 3:
                    ExitGame();
                    break;
            }
        }

        private void ExitGame()
        {
            WriteLine("\n\t\t\t\t\t   Press any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void DisplayAboutInfo()
        {
            CursorVisible = false;
            Clear();
            SetCursorPosition(35, 10);
            WriteLine("This game was created by Slava Sotnikov.");
            SetCursorPosition(35, 11);
            WriteLine("It uses assets from http://patorjk.com.");
            SetCursorPosition(35, 12);
            WriteLine("Press any key to return to the menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private void RunFirstChoice()
        {
            WriteLine("\n\t\t\t\t\t  Placeholder for 1st choice");
            ExitGame();
        }

        private void RunSecondChoice()
        {
            WriteLine("\n\t\t\t\t\t  Placeholder for 2nd choice");
        }
    }
}
