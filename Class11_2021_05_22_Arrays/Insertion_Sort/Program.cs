using System;

namespace Insertion_Sort
{
    class Program
    {
        private static Random rnd = new Random();

        private static void GetInsertionSort(int[] yourArr, int i = 0, int memory = 0)
        {
            while (i < yourArr.Length - 1)
            {
                if (yourArr[i] > yourArr[i + 1])
                {
                    int tmp = yourArr[i];
                    yourArr[i] = yourArr[i + 1];
                    yourArr[i + 1] = tmp;

                    if (i != 0)
                    {
                        i--;
                    }
                    else
                    {
                        memory++;
                        i = memory;
                    }
                }
                else
                {
                    memory++;
                    i = memory;
                }
            }

            return;
        }

        static void Main()
        {
            int[] yourArr = new int[10];

            for (int i = yourArr.Length - 1; i >= 0; i--)
            {
                yourArr[i] = rnd.Next(0, 101);
            }

            Console.Write("Your array: ");
            for (int k = 0; k < yourArr.Length; k++)
            {
                Console.Write("{0} ", yourArr[k]);
            }

            GetInsertionSort(yourArr);

            Console.Write("\nSort array: ");
            for (int l = 0; l < yourArr.Length; l++)
            {
                Console.Write("{0} ", yourArr[l]);
            }

            Console.ReadKey();
        }
    }
}
