using System;

namespace _2DArray_MinMax
{
    class Program
    {
        static Random rnd = new Random();

        private static void Print2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0} ", arr[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void GetMinMax(int[,] arr, out int min, out int max)
        {
            min = int.MaxValue;
            max = int.MinValue;

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
        }

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


            Print2DArray(arr);

            Console.WriteLine();

            int min;
            int max;

            GetMinMax(arr, out min, out max);

            Console.WriteLine("Min: {0} Max: {1}", min, max);
            Console.ReadKey();
        }
    }
}
