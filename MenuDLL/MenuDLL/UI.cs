using System;
using System.Text;
using System.Threading;

namespace MenuDLL
{
    internal class UI
    {
        public static string Name { get; private set; }

        public static string Country { get; private set; }

        private static byte _model;

        public static byte Model { get { return _model; } }

        public readonly string[] _options = { "1 PLAYER", "2 PLAYERS", "About", "Exit" };

        public static void ShowTitle()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.Title = "Space Invaders";

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Text.Title);
            Console.ForegroundColor = prevColor;

            Console.SetCursorPosition(47, 25);
            Console.WriteLine("\xA9 2021 LevelUp\x2122");
        }

        public static void ShowAboutInfo(string source)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(35, 10);
            Console.WriteLine("This game was created by Slava Sotnikov.");
            Console.SetCursorPosition(35, 11);
            Console.WriteLine("It uses assets from http://patorjk.com.");
            Console.SetCursorPosition(35, 13);
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void Print(string text, int sleep = 50)
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.CursorVisible = true;

            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    count++;
                    Console.SetCursorPosition(30, 10 + count);
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.Write(text[i]);
                    Thread.Sleep(sleep);
                }

                // Skip the animation if a key(Spacebar) is pressed.

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        for (int j = i + 1; j < text.Length; j++)
                        {
                            if (text[j] == '\n')
                            {
                                count++;
                                Console.SetCursorPosition(30, 10 + count);
                            }
                            else
                            {
                                Console.Write(text[j]);
                            }
                        }

                        Console.ReadKey(true);
                        break;
                    }
                }
            }
        }

        public static void PrintDialogue(string text, int left, int top, int sleep, int count = 0)
        {
            Console.Clear();

            Console.SetCursorPosition(left, top);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    count++;

                    if (count == 1)
                    {
                        do
                        {
                            Console.SetCursorPosition(left, top + count);
                            Name = Console.ReadLine();

                        } while (string.IsNullOrWhiteSpace(Name));
                    }

                    if (count == 2)
                    {
                        do
                        {
                            Console.SetCursorPosition(left, top + 3);
                            Country = Console.ReadLine();

                        } while (string.IsNullOrWhiteSpace(Country));
                    }

                    Console.SetCursorPosition(left, top + count + 1);
                }
                else
                {
                    Console.Write(text[i]);
                    Thread.Sleep(sleep);
                }
            }
        }

        public static void PickAShip()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            Console.SetCursorPosition(35, 1);
            Console.WriteLine("Captain: Pick your bird press 1 or 2");

            Console.SetCursorPosition(35, 4);
            Console.WriteLine("Light Ship(1): posseses higer mobility and fire rate");
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("Special Weapon: Suppressing Fire.");

            for (int i = 0; i < Text.LightShip.Length; i++)
            {
                Console.SetCursorPosition(45, 7 + i);
                Console.Write(Text.LightShip[i]);
            }

            Console.SetCursorPosition(35, 13);
            Console.WriteLine("Heavy Ship(2): fire power, heavy armor, less mobility");
            Console.SetCursorPosition(35, 14);
            Console.WriteLine("Special Weapon: Armour Piercer.");

            for (int i = 0; i < Text.HeavyShip.Length; i++)
            {
                Console.SetCursorPosition(45, 16 + i);
                Console.Write(Text.HeavyShip[i]);
            }

            Console.SetCursorPosition(35, 22);

            string userInput;

            do
            {
                Console.SetCursorPosition(43, 22);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(43, 22);
                Console.ForegroundColor = ConsoleColor.White;
                userInput = Console.ReadLine();

            } while (!byte.TryParse(userInput, out _model)
                || (_model != 1) && (_model != 2));
        }
    }
}
