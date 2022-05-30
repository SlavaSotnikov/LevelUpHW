using System;

namespace SpaceInvadersDLL
{
    internal class BL_Random
    {
        private static Random value = new Random();

        public static int GetCoordinateX()
        {
            return value.Next(30, 83);
        }

        public static uint GetFlySpeed()
        {
            return (uint)value.Next(40, 50); // 40000, 50000
        }

        public static byte GetRndY()
        {
            return (byte)value.Next(1, 20);
        }
    }
}
