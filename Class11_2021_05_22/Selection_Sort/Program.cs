using System;

namespace Selection_Sort
{
    class Program
    {
        private static Random rnd = new Random();
        static void GetSelectionSort(int[] yourArr, int index = 0)
        {
            for (int j = 1; j < yourArr.Length; j++)
            {
                for (int i = j; i < yourArr.Length; i++)
                {
                    if (yourArr[index] > yourArr[i])
                    {
                        int tmp = yourArr[index];
                        yourArr[index] = yourArr[i];
                        yourArr[i] = tmp;
                    }
                }
                index++;
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


            GetSelectionSort(yourArr);

            Console.WriteLine();

            Console.Write("Sort array: ");
            for (int k = 0; k < yourArr.Length; k++)
            {
                Console.Write("{0} ", yourArr[k]);
            }

            Console.ReadKey();
        }
    }
}
