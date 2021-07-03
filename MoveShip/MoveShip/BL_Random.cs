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

        public static int GetFlySpeed()
        {
            return value.Next(40000, 50000);
        }

        public static uint GetProduceSpeed()
        {
            uint result = (uint)value.Next(10000, 20000);

            return result;
        }
    }
}
