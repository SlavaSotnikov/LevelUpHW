using System;
using System.Text;
using System.Threading;

namespace Intro
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

        static int SelectedIndex = 0;
        static string[] Options = { "1 PLAYER", "2 PLAYERS", "About", "Exit" };
        static string Name = @"
                         _____                        _____                     _               
                        / ____|                      |_   _|                   | |              
                       | (___  _ __   __ _  ___ ___    | |  _ ____   ____ _  __| | ___ _ __ ___ 
                        \___ \| '_ \ / _` |/ __/ _ \   | | | '_ \ \ / / _` |/ _` |/ _ \ '__/ __|
                        ____) | |_) | (_| | (_|  __/  _| |_| | | \ V / (_| | (_| |  __/ |  \__ \
                       |_____/| .__/ \__,_|\___\___| |_____|_| |_|\_/ \__,_|\__,_|\___|_|  |___/
                              | |                                                               
                              |_|                                                               ";
                        
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

        static string aboutText = "This game was created by Slava Sotnikov.\n" +
                                  "It uses assets from http://patorjk.com.\n" +
                                "\nPress any key to return to the menu...";

        static string dialogue = "Captain: Greetings, fly lieutenant. Report! What is your name?" +
            "Where are you come from?" +
            "Captain: Pick your ship.";

        static void ShowDialogue(string dialogue)
        {

        }

        static void MoveShip()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int redo = 0;
            int sides = 52;
            int updown = 44;
            ConsoleKeyInfo Keyinfo;

            do
            {
                Keyinfo = Console.ReadKey(true);

                Console.Clear();

                switch (Keyinfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        sides++;
                        if (sides >= 90)
                        {
                            sides = 90;
                            Console.SetCursorPosition(sides, updown);
                        }
                        else
                        {
                            Console.SetCursorPosition(sides, updown);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        sides--;
                        if (sides <= 20)
                        {
                            sides = 20;
                            Console.SetCursorPosition(sides, updown);
                        }
                        else
                        {
                            Console.SetCursorPosition(sides, updown);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        updown--;
                        if (updown <= 0)
                        {
                            updown = 0;
                            Console.SetCursorPosition(sides, updown);
                        }
                        else
                        {
                            Console.SetCursorPosition(sides, updown);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        updown++;
                        if (updown >= 34)
                        {
                            updown = 34;
                            Console.SetCursorPosition(sides, updown);
                        }
                        else
                        {
                            Console.SetCursorPosition(sides, updown);
                        }
                        break;
                    default:
                        break;
                }

                UI.ShowShip(shipLight, sides, updown);

            } while (redo == 0);
        }

        

        static void StartGame(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.CursorVisible = false;

            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("Start Game");
                    Thread.Sleep(2000);
                    Console.Clear();
                    MoveShip();
                }
                else
                {
                    Console.SetCursorPosition(50, 18);
                    Console.WriteLine("Press <Enter> to start...");
                }

            } while (keyInfo.Key != ConsoleKey.Enter);
            
        }

        static void ExitGame()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(43, 20);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        static void DisplayAboutInfo(string aboutText)
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

        static void RunFirstChoice()
        {
            Console.SetCursorPosition(50, 18);
            Print(introduction, 50);
        }

        static void RunSecondChoice()
        {
            Console.SetCursorPosition(42, 18);
            Console.WriteLine("Placeholder for 2nd choice");
            ExitGame();
        }

        static void DisplayOptions()
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

        static int Run()
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

        static void RunMainMenu()
        {
            Console.CursorVisible = false;
           
            int selectedIndex = Run();

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

        static void Start()
        {
            Console.Title = "Space Invaders.";

            RunMainMenu();
        }
        static void Print(string text, int sleep)
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
            StartGame(100, 15);
        }
        static void Main()
        {
            Console.SetBufferSize(120, 40);

            UI.Start();
            
            Console.ReadKey();
        }
    }
}
