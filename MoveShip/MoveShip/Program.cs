using System;
using System.Text;

namespace MoveShip
{
    class Program
    {
        static string[,] shipLight = new string[5, 1]    
        {
            {"    ▲    "},
            {"    Ο    "},
            {"  ║ Ο ║  "},
            {"╱╲╲╲Λ╱╱╱╲"},
            {"  <╱╦╲>  "}
        };

        /*
         * RunSpaceship - Allows a user to run the Spaceship.
         * Input:
         * Output:  
         */
        static void RunSpaceship()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            int leftRight = 53;    // Initial Left-Right position of Spaceship.
            int topBottom = 33;    // Initial Top-Bottom position of Spaceship.
            int oldLeftRight = leftRight;
            int oldTopBottom = topBottom;

            UI.ShowBattleMenu("Slava", "Ukraine", 100, 3, 0, 0, 20);
            UI.PrintSpacecraft(shipLight, ConsoleColor.DarkGray, leftRight, topBottom);

            ConsoleKeyInfo keyInfo = UI.AskConsole();

            do
            {
                BL.ModifyCoordinates(keyInfo, ref leftRight, ref topBottom);

                UI.ShowHideSpacecraft(shipLight, leftRight, topBottom, oldLeftRight, oldTopBottom);

                // Set previous coordinates
                oldLeftRight = leftRight;  
                oldTopBottom = topBottom;

                // Get new coordinates
                keyInfo = UI.AskConsole(); 

            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        static void Main()
        {
            UI.SetBufferSize(120, 40);

            RunSpaceship();

            Console.ReadKey();
        }
    }
}
