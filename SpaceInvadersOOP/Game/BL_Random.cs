using System;

namespace Game
{
    class BL_Random
    {
        private static Random _rndValue = new Random();

        public static int GetX()
        {
            return _rndValue.Next(30, 83);
        }

        public static int GetY()
        {
            return _rndValue.Next(0, 18);
        }

        public static uint GetFlySpeed()
        {
            return (uint)_rndValue.Next(40000, 50000);
        }

        public static byte GetRndY()
        {
            return (byte)_rndValue.Next(1, 20);
        }
    }
}
