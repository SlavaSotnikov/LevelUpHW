using System;

namespace Swap_Min_Max
{
    class Program
    {
        private static int GetMin(int[] arr, out int indexMin)
        {
            int min = arr[0];
            indexMin = 0;

            for (int i = 1; i < arr.Length; i++)        //Looking for min, max and indexMin, indexMax values.
            {
                if (arr[i] <= min)
                {
                    min = arr[i];
                    indexMin = i;
                }
            }

            return min;
        }

        private static int GetMax(int[] arr, out int indexMax)
        {
            int max = arr[0];
            indexMax = 0;

            for (int i = 1; i < arr.Length; i++)        //Looking for min, max and indexMin, indexMax values.
            {
                if (arr[i] >= max)
                {
                    max = arr[i];
                    indexMax = i;
                }
            }

            return max;
        }

        static void Main()
        {
            int[] sourceArr = { 10, 1, 2, 3, 4, 5, 6, 7, 0, 9 };

            int indexMin;
            int indexMax;

            Console.Write("     Source array: ");
            for (int i = 0; i < sourceArr.Length; i++)
            {
                Console.Write("{0} ", sourceArr[i]);
            }

            Console.WriteLine();

            int min = GetMin(sourceArr, out indexMin);

            int max = GetMax(sourceArr, out indexMax);    

            sourceArr.SetValue(min, indexMax);            //Set Min value instead Max one
            sourceArr.SetValue(max, indexMin);            //Set Max value instead Min one

            Console.Write("Destination array: ");
            for (int i = 0; i < sourceArr.Length; i++)
            {
                Console.Write("{0} ", sourceArr[i]);
            }

            Console.ReadKey();
        }
    }
}
