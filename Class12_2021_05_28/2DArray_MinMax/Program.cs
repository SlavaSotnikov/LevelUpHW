using System;

namespace _2DArray_MinMax
{
    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            int[,] arr = new int[5, 5];

            // Put random values in the array
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(-10, 101);
                }
            }

            // Show array's numbers in Console
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0} ", arr[i, j]);
                }

                Console.WriteLine();
            }


            Console.WriteLine();

            int min = arr[0, 0];
            int max = arr[0, 0];

            // Looking for Min, Max values
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (min > arr[i, j])
                    {
                        min = arr[i, j];
                    }

                    if (max < arr[i, j])
                    {
                        max = arr[i, j];
                    }
                }
            }

            Console.WriteLine("Min: {0} Max: {1}", min, max);
            Console.ReadKey();
        }
    }
}
