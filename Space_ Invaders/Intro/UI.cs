using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intro
{
    class UI
    {
        static string pilotName = String.Empty;
        static string country = String.Empty;

        static string[,] shipLight = new string[5, 1]    // TODO: Use char's array
        {
            {"    ▲    "},
            {"    Ο    "},
            {"  ║ Ο ║  "},
            {"╱╲╲╲Λ╱╱╱╲"},
            {"  <╱╦╲>  "}
        };

        static string[,] shipHeavy = new string[5, 1]
        {
            {"    ▲    "},
            {"   ╱Ο╲   "},
            {" ∩╱UKR╲∩ "},
            {"║═══Λ═══║"},
            {" <╱*╦*╲> "}
        };

        private static int SelectedIndex = 0;
        private static string[] Options = { "1 PLAYER", "2 PLAYERS", "About", "Exit" };

        private static string Name = @"
                         _____                        _____                     _               
                        / ____|                      |_   _|                   | |              
                       | (___  _ __   __ _  ___ ___    | |  _ ____   ____ _  __| | ___ _ __ ___ 
                        \___ \| '_ \ / _` |/ __/ _ \   | | | '_ \ \ / / _` |/ _` |/ _ \ '__/ __|
                        ____) | |_) | (_| | (_|  __/  _| |_| | | \ V / (_| | (_| |  __/ |  \__ \
                       |_____/| .__/ \__,_|\___\___| |_____|_| |_|\_/ \__,_|\__,_|\___|_|  |___/
                              | |                                                               
                              |_|                                                               ";

        private static string aboutText = "This game was created by Slava Sotnikov.\n" +
                                  "It uses assets from http://patorjk.com.\n" +
                                "\nPress any key to return to the menu...";

        static string introduction = "AD2030. Human scientists discovered that they are not the\n" +
                "only intelligence in the galaxy....\n" +

                "\nAD2035. Human and aliens had their first contact....\n" +

                "\nYet this contact turned out to be the beginning of alien invasion...\n" +

                "\nThey tried to slave earth and dried up the resource of humanity \n" +
                "until the extinction of human civilization...\n" +

                "\nHuman military suffers a unmeasurable loss and can not \n" +
                "afford an effective counterattack...\n" +

                "\nWhen most of people wew losing their faith to survive, \n" +
                "there are a few people willing to stand out \n" +
                "and sacriface themselves to protect the people they love...";

        static string dialogue = "Captain: Greetings, fly lieutenant. Report! What is your name? \n" +
               "Captain: Where are you come from? \n" +
               "Captain: Pick your ship.";

        private static void DisplayOptions()
        {
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Name);
            Console.ForegroundColor = prevColor;

            int count = 0;

            for (int i = 0; i < Options.Length; i++)
            {
                ++count;
                string currentOption = Options[i];
                string pointer;

                if (i == SelectedIndex)
                {
                    pointer = "\u2192";
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.ResetColor();
                    pointer = " ";
                }
                Console.SetCursorPosition(50, 8 + count);
                Console.WriteLine($"{pointer} {currentOption} ");
            }
            Console.ResetColor();

            Console.SetCursorPosition(47, 25);
            Console.WriteLine("\xA9 2021 LevelUp\x2122");
        }

        private static int GetMenuPointer()
        {
            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }

        private static void RunMainMenu()
        {
            Console.CursorVisible = false;

            int selectedIndex = GetMenuPointer();

            Menu menu = (Menu)selectedIndex;

            switch (menu)
            {
                case Menu.OnePlayer:
                    RunFirstChoice();
                    break;
                case Menu.TwoPlayers:
                    RunSecondChoice();
                    break;
                case Menu.About:
                    DisplayAboutInfo(aboutText);
                    break;
                case Menu.Exit:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }

        private static void PrintDialogue(string text, int left, int top, int sleep, ref string pilotName,
                                          ref string country, int count = 0)
        {
            Console.Clear();

            Console.SetCursorPosition(left, top);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    count++;
                    Console.SetCursorPosition(left, top + count);
                    if (count == 1)
                    {
                        pilotName = Console.ReadLine();
                        Console.SetCursorPosition(left, top + count + 1);
                    }
                    else if (count == 2)
                    {
                        Console.SetCursorPosition(left, top + count + 1);
                        country = Console.ReadLine();
                        Console.SetCursorPosition(left, top + count + 2);
                    }
                }
                else
                {
                    Console.Write(text[i]);
                    Thread.Sleep(sleep);
                }
            }

            PickAShip(shipLight, shipHeavy);
        }

        static void PickAShip(string[,] shipLight, string[,] shipHeavy)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            Console.SetCursorPosition(35, 1);
            Console.WriteLine("Captain: Pick your bird press 1 or 2");

            Console.SetCursorPosition(35, 4);
            Console.WriteLine("Light Ship(1): posseses higer mobility and fire rate");
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("Special Weapon: Suppressing Fire.");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Console.SetCursorPosition(45, 7 + i);
                    Console.Write(shipLight[i, j]);
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(35, 13);
            Console.WriteLine("Heavy Ship(2): fire power, heavy armor, less mobility");
            Console.SetCursorPosition(35, 14);
            Console.WriteLine("Special Weapon: Armour Piercer.");           

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Console.SetCursorPosition(45, 16 + i);
                    Console.Write(shipHeavy[i, j]);
                }
                Console.WriteLine();
            }

            ConsoleKey keyInfo = ConsoleKey.Escape;

            Console.SetCursorPosition(35, 22);

            int inextString = 0;

            do
            {
                Console.SetCursorPosition(43, 22 + inextString);
                keyInfo = Console.ReadKey().Key;

                switch (keyInfo)
                {
                    case ConsoleKey.D1:
                        StartGame(45, 16);
                        break;
                    case ConsoleKey.D2:
                        break;
                    default:
                        Console.SetCursorPosition(45, 22 + inextString);
                        Console.WriteLine("Try again");
                        break;
                }

                ++inextString;

            } while (keyInfo != ConsoleKey.D1 || keyInfo != ConsoleKey.D2);            
        }

        static void StartGame(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.CursorVisible = false;

            ConsoleKey key = ConsoleKey.Escape;

            do
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.SetCursorPosition(52, 15);
                    Console.WriteLine("Start Game");
                    Thread.Sleep(1000);
                    Console.Clear();
                    MoveShip();
                }
                else
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("Press <Enter> to start...");
                }

            } while (key != ConsoleKey.Enter);

        }

        static void MoveShip()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int redo = 0;
            int sides = 53;
            int updown = 33;

            

            ConsoleKey key = ConsoleKey.Escape;

            do
            {
                key = Console.ReadKey(true).Key;

                //Console.Clear();


                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        ++sides;
                        if (sides >= 83)
                        {
                            sides = 83;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        --sides;
                        if (sides <= 30)
                        {
                            sides = 30;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        --updown;
                        if (updown <= 0)
                        {
                            updown = 0;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        ++updown;
                        if (updown >= 33)
                        {
                            updown = 33;
                        }
                        break;
                    default:
                        break;
                }

                Console.SetCursorPosition(sides, updown);
                ShowShip(shipLight, sides, updown);

            } while (redo == 0);
        }

        private static void PrintText(string text, int left, int top, int sleep, int count = 0)
        {
            Console.Clear();

            Console.CursorVisible = true;

            Console.SetCursorPosition(left, top);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    ++count;
                    Console.SetCursorPosition(left, top + count);
                }
                else
                {
                    Console.Write(text[i]);
                    Thread.Sleep(sleep);
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
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
                        break;
                    }
                }
            }

            PrintDialogue(dialogue, left: 30, top: 10, sleep: 0, ref pilotName, ref country);

        }

        private static void RunFirstChoice()
        {
            PrintText(introduction, 30, 10, 50);
        }

        private static void RunSecondChoice()
        {
            Console.SetCursorPosition(42, 18);
            Console.WriteLine("Placeholder for 2nd choice");
            ExitGame();
        }

        private static void DisplayAboutInfo(string aboutText)
        {
            Console.Clear();
            Console.SetCursorPosition(38, 10);

            int count = 0;

            for (int i = 0; i < aboutText.Length; i++)
            {
                if (aboutText[i] == '\n')
                {
                    count++;
                    Console.SetCursorPosition(38, 10 + count);
                }
                else
                {
                    Console.Write(aboutText[i]);
                }
            }

            Console.ReadKey(true);
            RunMainMenu();
        }

        static void ExitGame()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(43, 20);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        public static void Start()
        {
            Console.Title = "Space Invaders.";

            RunMainMenu();
        }

        public static void ShowShip(string[,] ship, int sides, int updown)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;


            Console.SetCursorPosition(46, 38);
            Console.Write("Pilot:{0}", pilotName);
            Console.SetCursorPosition(60, 38);
            Console.Write("From:{0}", country);
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

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    int right = sides + j;
                    if (right >= 100)
                    {
                        right = 100;
                        Console.SetCursorPosition(right, updown + i);
                        Console.Write(ship[i, j]);
                    }
                    else
                    {
                        Console.SetCursorPosition(right, updown + i);
                        Console.Write(ship[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
