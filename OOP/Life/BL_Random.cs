using System;

namespace Life
{
    class BL_Random
    {
        public static Random rnd = new Random();

        public static int GetRnd(int max)
        {
            return rnd.Next(max);
        }
    }
}
