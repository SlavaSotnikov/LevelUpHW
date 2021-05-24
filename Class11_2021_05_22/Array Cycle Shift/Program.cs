using System;

namespace Array_Cycle_Shift
{
    class Program
    {
        private static void GetLeftShift(int[] source, ref int[] dest, int shift )
        {
            int ind = source.Length - shift;

            Array.Copy(source, 0, dest, ind, shift);
            Array.Copy(source, dest.Length - ind, dest, 0, ind);
        }

        private static void GetRightShift(int[] source, ref int[] dest, int shift)
        {
            int ind = source.Length - shift;

            Array.Copy(source, ind, dest, 0, shift);          
            Array.Copy(source, 0, dest, shift, ind);
        }
       
        static void Main()
        {
            int[] source = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };    //Source array

            int[] dest = new int [10];                          //Destination array

            Console.WriteLine("Left or Right shift? <<  >> Press Left, Right");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            Console.WriteLine();

            Console.Write("How many shifts: ? ");               //The amount of shifts
            int shift = int.Parse(Console.ReadLine());

            while (shift > source.Length)                       //Any shifts
            {
                shift -= source.Length;
            }

            switch (keyInfo.Key)                                //Pick shift
            {
                case ConsoleKey.LeftArrow:
                    GetLeftShift(source, ref dest, shift);
                    break;
                case ConsoleKey.RightArrow:
                    GetRightShift(source, ref dest, shift);
                    break;
                default:
                    break;
            }

            for (int i = 0; i < dest.Length; i++)               //Show dest array numbers
            {
                Console.Write("{0} ", dest[i]);
            }

            Console.ReadKey();
        }
    }
}
