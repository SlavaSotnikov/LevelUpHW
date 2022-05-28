using System;
using System.Collections.Generic;

namespace Threads_2022_02_05
{
    internal static class Extentions
    {
        public static IEnumerable<int> NextSet(this Random rnd, int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                yield return rnd.Next(101);
            }
        }
    }
}
