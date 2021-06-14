using System;
using System.Text;

namespace MoveShip
{
    class Program
    {
        const int LEFT_BORDER = 30;
        const int RIGHT_BORDER = 83;
        const int TOP_BORDER = 0;
        const int BOTTOM_BORDER = 33;

        static string[,] shipLight = new string[5, 1]    
        {
            {"    ▲    "},
            {"    Ο    "},
            {"  ║ Ο ║  "},
            {"╱╲╲╲Λ╱╱╱╲"},
            {"  <╱╦╲>  "}
        };

        static void MoveShip()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            int leftRight = 53;    // Initial Left-Right position of Spaceship.
            int topBottom = 33;    // Initial Top-Bottom position of Spaceship.
            int oldLeftRight = leftRight;
            int oldTopBottom = topBottom;

            UI.ShowBattleMenu();
            UI.ShowSpacecraft(shipLight, ConsoleColor.DarkGray, leftRight, topBottom);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            do
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        ++leftRight;
                        if (leftRight >= RIGHT_BORDER)
                        {
                            leftRight = RIGHT_BORDER;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        --leftRight;
                        if (leftRight <= LEFT_BORDER)
                        {
                            leftRight = LEFT_BORDER;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        --topBottom;
                        if (topBottom <= TOP_BORDER)
                        {
                            topBottom = TOP_BORDER;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        ++topBottom;
                        if (topBottom >= BOTTOM_BORDER)
                        {
                            topBottom = BOTTOM_BORDER;
                        }
                        break;
                    default:
                        break;
                }

                if (leftRight != oldLeftRight || topBottom != oldTopBottom)
                {
                    UI.ShowSpacecraft(shipLight, ConsoleColor.Black, oldLeftRight, oldTopBottom); 
                }

                UI.ShowSpacecraft(shipLight, ConsoleColor.Gray, leftRight, topBottom);

                oldLeftRight = leftRight;
                oldTopBottom = topBottom;

                keyInfo = Console.ReadKey(true);

            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        static void Main()
        {
            UI.SetBufferSize(120, 40);

            MoveShip();

            Console.ReadKey();
        }
    }
}
