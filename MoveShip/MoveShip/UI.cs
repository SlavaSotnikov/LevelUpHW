using System;

namespace MoveShip
{
    class UI
    {
        public static void ShowSpacecraft(string[,] spacecraft, ConsoleColor color, int leftRight, int topBottom)
        {
            for (int i = 0; i < spacecraft.GetLength(0); i++)
            {
                for (int j = 0; j < spacecraft.GetLength(1); j++)
                {
                    Console.SetCursorPosition(leftRight, topBottom + i);

                    Console.ForegroundColor = color;
                    Console.Write(spacecraft[i, j]);
                }
            }
        }

        public static void ShowBattleMenu()
        {
            Console.ResetColor();

            Console.SetCursorPosition(45, 38);
            Console.Write("Pilot: Slava");
            Console.SetCursorPosition(58, 38);
            Console.Write("From: Ukraine");
            Console.SetCursorPosition(30, 39);
            Console.Write("HP: 100");
            Console.SetCursorPosition(38, 39);
            Console.Write("Energy: 120");
            Console.SetCursorPosition(51, 39);
            Console.Write("Missed Enemies: 0");
            Console.SetCursorPosition(70, 39);
            Console.Write("MyKills: 0");
            Console.SetCursorPosition(81, 39);
            Console.Write("Enemies: 20");
        }

        public static void SetBufferSize(int width, int height)
        {
            Console.SetBufferSize(width, height);
        }
    }
}
