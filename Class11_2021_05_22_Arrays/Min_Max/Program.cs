using System;

namespace Min_Max
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main()
        {
            int[] arr = new int[10];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = rnd.Next(-10, 101);
            }

            Console.Write("Your array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }

            int min = 0;
            int index = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[0])
                {
                    arr[0] = arr[i];
                    min = arr[0];
                }
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (min == arr[i])
                {
                    index = i;
                }
            }

            Console.WriteLine("\nMin value: {0} Index: {1}", min, index);

            Console.ReadKey();
        }
    }
}
