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
            int[] source = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };    // Source array

            int[] dest = new int [10];                          // Destination array

            Console.WriteLine("How many shifts? \n<<   >> Press Left, Right");
            ConsoleKeyInfo keyInfo;

            int shift = 0;

            keyInfo = Console.ReadKey();

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                ++shift;
                Console.SetCursorPosition(3, 2);
                Console.Write("{0}", shift);
                keyInfo = Console.ReadKey();
            }

            Console.WriteLine();

            Console.Write("Pick the shift: ");

            keyInfo = Console.ReadKey();

            Console.WriteLine();

            Console.Write(keyInfo.KeyChar);

            Console.WriteLine();

            while (shift > source.Length)                       // Any shifts
            {
                shift -= source.Length;
            }

            switch (keyInfo.Key)                                // Pick shift
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

            for (int i = 0; i < dest.Length; i++)               // Show dest array numbers
            {
                Console.Write("{0} ", dest[i]);
            }

            Console.ReadKey();
        }
    }
}
