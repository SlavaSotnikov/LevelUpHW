﻿using System;

using BL;

namespace ConsolePuzzleGame
{
    public class ConsoleUI
    {
        const byte X = 15;
        const byte Y = 3;

        readonly IGame _game;
        readonly byte _size;

        public ConsoleUI(IGame source, byte size)
        {
            source.InitializeBL();
            _game = source;
            _size = size;
            _game.FinishGame += ShowFinish;
        }

        public void Run()
        {
            ShowButtons();

            AskUser();
        }

        private void AskUser()
        {
            int x = X;
            int y = Y;

            Console.SetCursorPosition(x, y);
            ConsoleKeyInfo consoleKey;

            do
            {
                consoleKey = Console.ReadKey(true);

                if (consoleKey.Key == ConsoleKey.UpArrow)
                {
                    y--;
                }

                if (consoleKey.Key == ConsoleKey.DownArrow)
                {
                    y++;
                }

                if (consoleKey.Key == ConsoleKey.LeftArrow)
                {
                    x -= 4;
                }

                if (consoleKey.Key == ConsoleKey.RightArrow)
                {
                    x += 4;
                }

                if (consoleKey.Key == ConsoleKey.Spacebar)
                {
                    _game.ClickCell(x / 5, y);

                    ShowButtons();
                }

                Console.SetCursorPosition(x, y);

            } while (consoleKey.Key != ConsoleKey.Escape);
        }

        private void ShowButtons()
        {
            Console.Clear();

            int number;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    number = _game.GetNumber(j, i);

                    if (number == 16)
                    {
                        number = 0;
                    }

                    Console.Write("{0, 4}", number);
                }

                Console.WriteLine();
            }
        }

        public static void ShowFinish(object sender, EventArgs e)
        {
            Console.SetCursorPosition(22, 2);
            Console.WriteLine("Congrats! You've won!");
            Console.ReadKey();
        }
    }
}
