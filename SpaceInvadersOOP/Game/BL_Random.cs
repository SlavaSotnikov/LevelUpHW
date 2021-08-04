using System;

namespace Game
{
    class BL_Random
    {
        private static Random value = new Random();

        public static int GetCoordinateX()
        {
            return value.Next(30, 83);
        }

        public static uint GetFlySpeed()
        {
            return (uint)value.Next(40000, 50000);
        }

        public static uint GetProduceSpeed()
        {
            return (uint)value.Next(10000, 20000);
        }
    }
}
