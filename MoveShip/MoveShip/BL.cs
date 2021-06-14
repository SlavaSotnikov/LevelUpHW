using System;

namespace MoveShip
{
    class BL
    {
        const int LEFT_BORDER = 30;
        const int RIGHT_BORDER = 83;
        const int TOP_BORDER = 0;
        const int BOTTOM_BORDER = 33;

        /*
         * ModifyCoordinate - It changes the coordinates X or Y.
         * Input:
         *   keyInfo - Contains the value of pressed key.
         *   leftRight - Reference of X coordinate
         *   topBottom - Reference of Y coordinate
         * Output:
         *   leftRight - Reference of X coordinate
         *   topBottom - Reference of Y coordinate
         */
        public static void ModifyCoordinates(ConsoleKeyInfo keyInfo, ref int leftRight, ref int topBottom)
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
        }
    }
}
