using System;
using System.Text;
using static System.Console;

namespace Movement
{
    class Program
    {
        static void ShowLightStarShip(int sides, int updown)
        {
            CursorVisible = false;
            OutputEncoding = Encoding.UTF8;            

            char[,] shipLight = new char[5, 9]
            {
                { '\0', '\0', '\0', '\0', '\u25B2', '\0', '\0', '\0', '\0'        },
                { '\0', '\0', '\0', '\0', 'Ο', '\0', '\0', '\0', '\0'             },
                { '\0', '\0', '\u2016', '\0', 'Ο', '\0', '\u2016', '\0', '\0'     },
                { '/', '\u005C', '\u005C', '\u005C', 'Ο', '/', '/', '/', '\u005C' },
                { '\0', '\0', '<', '/', '\u2566', '\u005C', '>', '\0', '\0'       }
            };


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int right = sides + j;
                    if (right >= 100)
                    {
                        right = 100;
                        SetCursorPosition(right, updown + i);
                        Write(shipLight[i, j]);
                    }
                    else
                    {
                        SetCursorPosition(right, updown + i);
                        Write(shipLight[i, j]);
                    }                                       
                }
                WriteLine();
            }

            //System.Threading.Thread.Sleep(10);
        }
        static void Main()
        {
            OutputEncoding = Encoding.UTF8;
            SetBufferSize(120, 40);

            int redo = 0;
            int sides = 52;
            int updown = 24;
            ConsoleKeyInfo Keyinfo;


            do
            {
                Keyinfo = ReadKey(true);
                Clear();

                switch (Keyinfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        sides++;                        
                        if (sides >= 90)
                        {
                            sides = 90;
                            SetCursorPosition(sides, updown);
                            ShowLightStarShip(sides, updown);
                        }
                        else
                        {
                            SetCursorPosition(sides, updown);
                            ShowLightStarShip(sides, updown);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        sides--;
                        if (sides <= 20)
                        {
                            sides = 20;
                            SetCursorPosition(sides, updown);
                            ShowLightStarShip(sides, updown);
                        }
                        else
                        {
                            SetCursorPosition(sides, updown);
                            ShowLightStarShip(sides, updown);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        updown--;
                        if (updown <= 0)
                        {
                            updown = 0;
                            SetCursorPosition(sides, updown);
                            ShowLightStarShip(sides, updown);
                        }
                        else
                        {
                            SetCursorPosition(sides, updown);
                            ShowLightStarShip(sides, updown);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        updown++;
                        if (updown >= 24)
                        {
                            updown = 24;
                            SetCursorPosition(sides, updown);
                            ShowLightStarShip(sides, updown);
                        }
                        else
                        {
                            SetCursorPosition(sides, updown);
                            ShowLightStarShip(sides, updown);
                        }
                        break;
                    default:
                        break;
                }

            } while (redo == 0);

            ReadLine();
        }
    }
}
