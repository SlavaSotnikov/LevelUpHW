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

            Title = "Battle City - Tanks!";

            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @" 
                       ██████╗ █████╗██████████████████╗    ███████╗     ██████████████████╗   ██╗
                       ██╔══████╔══██╚══██╔══╚══██╔══██║    ██╔════╝    ██╔════██╚══██╔══╚██╗ ██╔╝
                       ██████╔███████║  ██║     ██║  ██║    █████╗      ██║    ██║  ██║   ╚████╔╝ 
                       ██╔══████╔══██║  ██║     ██║  ██║    ██╔══╝      ██║    ██║  ██║    ╚██╔╝  
                       ██████╔██║  ██║  ██║     ██║  ██████████████╗    ╚████████║  ██║     ██║   
                       ╚═════╝╚═╝  ╚═╝  ╚═╝     ╚═╝  ╚══════╚══════╝     ╚═════╚═╝  ╚═╝     ╚═╝   
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
            Clear();
            WriteLine("\t\t\t\t This game was created by Slava Sotnikov.");
            WriteLine("\t\t\t\t It uses assets from http://patorjk.com.");
            WriteLine("\n\t\t\t\t Press any key to return to the menu.");
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
