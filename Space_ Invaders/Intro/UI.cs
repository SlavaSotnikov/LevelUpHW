using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    class UI
    {
        public static void ShowLightStarShip(int sides, int updown)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            string[,] shipLight = new string[5, 1]
            {
                {"    ▲    "},
                {"    Ο    "},
                {"  ║ Ο ║  "},
                {"╱╲╲╲Λ╱╱╱╲"},
                {"  <╱╦╲>  "}
            };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    int right = sides + j;
                    if (right >= 100)
                    {
                        right = 100;
                        Console.SetCursorPosition(right, updown + i);
                        Console.Write(shipLight[i, j]);
                    }
                    else
                    {
                        Console.SetCursorPosition(right, updown + i);
                        Console.Write(shipLight[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
