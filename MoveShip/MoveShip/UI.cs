using System;

namespace MoveShip
{
    class UI
    {
        /*
         * PrintSpacecraft - Print a spacecraft. 
         * Input:
         *   spacecraft - A model of spacecraft
         *   color - Hide-Black, Show-White
         *   coordX - coordinate X
         *   coordY - coordinate Y
         * Output:
         *   Print the spacecraft in console.
         */
        public static void PrintSpacecraft(string[,] spacecraft, ConsoleColor color, int coordX, int coordY)
        {
            for (int i = 0; i < spacecraft.GetLength(0); i++)
            {
                for (int j = 0; j < spacecraft.GetLength(1); j++)
                {
                    Console.SetCursorPosition(coordX, coordY + i);

                    Console.ForegroundColor = color;
                    Console.Write(spacecraft[i, j]);
                }
            }
        }

        /*
         * ShowBattleMenu - Prints the battle menu in console.
         * Input:
         *   name - Pilot's name
         *   country - Country of pilot from
         *   hp - Hit points
         *   life - Points of life
         *   Missed enemies
         *   killed - Killed enemies
         *   enemies - Amount of enemies
         * Output:
         *   Ptint in console.
         */
        public static void ShowBattleMenu(string name, string country, int hp, int life, int skip, int killed, int enemies)
        {
            Console.ResetColor();

            Console.SetCursorPosition(45, 38);
            Console.Write("Pilot: {0}", name);
            Console.SetCursorPosition(58, 38);
            Console.Write("From: {0}", country);
            Console.SetCursorPosition(30, 39);
            Console.Write("HP: {0}%", hp);
            Console.SetCursorPosition(40, 39);
            Console.Write("Life: {0}", life);
            Console.SetCursorPosition(51, 39);
            Console.Write("Missed Enemies: {0}", skip);
            Console.SetCursorPosition(70, 39);
            Console.Write("MyKills: {0}", killed);
            Console.SetCursorPosition(81, 39);
            Console.Write("Enemies: {0}", enemies);
        }

        /*
         * SetBufferSize - Initial buffer size of console.
         */
        public static void SetBufferSize(int width, int height)
        {
            Console.SetBufferSize(width, height);
        }

        /*
         * ShowHideSpacecraft - It hides or shows the spacecraft. It depends on the color you transmit.
         * Input:
         *   spacecraft - A model of spacecraft
         *   color - Hide-Black, Show-White
         *   coordX - coordinate X
         *   coordY - coordinate Y
         *   oldCoordX - previous coordinate X
         *   oldCoordY - previous coordinate Y
         */
        public static void ShowHideSpacecraft(string[,] spacecraft, int coordX, int coordY, int oldCoordX, int oldCoordY)
        {
            // Hide previous coordinates of the Spaceship.
            if (coordX != oldCoordX || coordY != oldCoordY)
            {
                PrintSpacecraft(spacecraft, ConsoleColor.Black, oldCoordX, oldCoordY);
            }

            // Show the Spaceship.
            PrintSpacecraft(spacecraft, ConsoleColor.Gray, coordX, coordY);
        }

        public static ConsoleKeyInfo AskConsole()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            return keyInfo;
        }
    }
}
