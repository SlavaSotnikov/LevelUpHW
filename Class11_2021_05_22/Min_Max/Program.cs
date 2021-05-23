using System;

namespace Min_Max
{
    class Program
    {
        private static Random rnd = new Random();

        private static void GetTwoMinMax(int[] arr, out int min, out int max, out int min2, out int max2, ref int indexMin, ref int indexMax, ref int indexMin2, ref int indexMax2)
        {
            min = arr[0];
            max = arr[0];

            for (int i = 1; i < arr.Length; i++)        //Looking for min, max and indexMin, indexMax values.
            {
                if (arr[i] <= min)
                {
                    min = arr[i];
                    indexMin = i;
                }
                if (arr[i] >= max)
                {
                    max = arr[i];
                    indexMax = i;
                }
            }

            int j = arr.Length - 1;
            while (arr[j] == min
                || max == arr[j])                      //It helps us to avoid initializing min2, max2 like min, max. 
            {
                --j;
            }

            min2 = arr[j];                              //Initializing min2, max2 non min, max values.           
            max2 = arr[j];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if ((i == indexMin) || (i == indexMax)) //Skipping min, max value.
                {
                    continue;
                }
                if (arr[i] <= min2)                     // Looking for min2, max2 and indexMin2, indexMax2.
                {
                    min2 = arr[i];
                    indexMin2 = i;
                }
                if (arr[i] >= max2)
                {
                    max2 = arr[i];
                    indexMax2 = i;
                }
            }
        }

        static void Main()
        {
            int[] arr = new int [10];                    //An array.

            for (int i = arr.Length - 1; i >= 0; i--)    //Generating numbers into the array.
            {
                arr[i] = rnd.Next(-10, 101);
            }

            Console.Write("       Ind: ");
            for (int i = 0; i < arr.Length; i++)        //Show source array's numbers.
            {
                Console.Write("{0}  ", i);
            }

            Console.WriteLine();

            Console.Write("Your array: ");
            for (int i = 0; i < arr.Length; i++)        //Show source array's numbers.
            {
                Console.Write("{0} ", arr[i]);
            }
            
            Console.WriteLine();

            int min = 0;                           //Initially we can pick any array's index and initialize min, max.
            int max = 0;
            int min2 = 0;                               //Initializing min2, max2 non min, max values.           
            int max2 = 0;
            int indexMin = 0;
            int indexMax = 0;
            int indexMin2 = 0;
            int indexMax2 = 0;

            GetTwoMinMax(arr, out min, out max, out min2, out max2, ref indexMin, ref indexMax, ref indexMin2, ref indexMax2);

            Console.WriteLine("\nInd:  ({0})     ({1})", indexMin, indexMax);
            Console.WriteLine("Min:   {0} Max: {1}", min, max);
            Console.WriteLine("\nInd:  ({0})     ({1})", indexMin2, indexMax2);
            Console.WriteLine("Min:   {0} Max: {1}", min2, max2);

            Console.ReadKey();
        }
    }
}
