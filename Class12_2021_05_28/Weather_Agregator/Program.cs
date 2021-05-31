using System;

namespace Weather_Agregator
{
    class Program
    {
        static void Main()
        {
            int[][] weatherAgr = new int[4][];

            weatherAgr[(int)Period.Year]  = new int[10];
            weatherAgr[(int)Period.Month] = new int[12];
            weatherAgr[(int)Period.Day]   = new int[31];
            weatherAgr[(int)Period.Hour]  = new int[24];

            for (int i = 0; i < weatherAgr.Length; i++)
            {
                for (int j = 0; j < weatherAgr[i].Length; j++)
                {
                    Console.Write("{0,2}", weatherAgr[i][j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
