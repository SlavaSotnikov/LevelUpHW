using System;

namespace MoveShip
{
    class BL_Random
    {
        private static Random value = new Random();

        public static int GetCoordinateX()
        {
            return value.Next(30, 83);
        }

        public static int GetSpeed()
        {
            return value.Next(20000, 30000);
        }

        public static uint GetProduceSpeed()
        {
            uint result = (uint)value.Next(10000, 20000);

            return result;
        }
    }
}
