using System;

namespace Quick_Sort
{
    class Program
    {
        private static readonly Random rnd = new Random();
        private static void GetQuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int left = start;
                int right = end;

                int mid = arr[(start + end) / 2];

                while (left < right)
                {
                    while (arr[left] < mid)
                    {
                        left++;
                    }
                    while (arr[right] > mid)
                    {
                        right--;
                    }
                    if (left <= right)
                    {
                        int tmp = arr[left];
                        arr[left] = arr[right];
                        arr[right] = tmp;

                        left++;
                        right--;
                    }                   
                };

                GetQuickSort(arr, start, right);
                GetQuickSort(arr, left, end);
            }

            return;
        }
        static void Main()
        {
            int[] myArr = new int[10];

            for (int i = myArr.Length - 1; i >= 0; i--)
            {
                myArr[i] = rnd.Next(0, 101);
            }

            int start = 0;
            int end = myArr.Length - 1;

            Console.Write("    Source array: ");
            for (int i = 0; i < myArr.Length; i++)
            {
                Console.Write("{0} ", myArr[i]);
            }

            GetQuickSort(myArr, start, end);

            Console.Write("\nQuick Sort array: ");
            for (int i = 0; i < myArr.Length; i++)
            {
                Console.Write("{0} ", myArr[i]);
            }

            Console.ReadKey();
        }
    }
}
