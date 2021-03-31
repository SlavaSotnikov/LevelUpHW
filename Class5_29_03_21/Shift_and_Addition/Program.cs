using System;

namespace Shift_and_Addition
{
    class Program
    {       
        static void Main()
        {
            int multiplier1 = 125;
            int multiplier2 = 17;
            int product = 0;

            if (64 <= multiplier1 && multiplier1 < 128)
            {
                multiplier1 -= 64;
                product += multiplier2 << 6;
            }
            if (32 <= multiplier1 && multiplier1 < 64)
            {
                multiplier1 -= 32;
                product += multiplier2 << 5;
            }
            if (16 <= multiplier1 && multiplier1 < 32)
            {
                multiplier1 -= 16;
                product += multiplier2 << 4;
            }
            if (8 <= multiplier1 && multiplier1 < 16)
            {
                multiplier1 -= 8;
                product += multiplier2 << 3;
            }
            if (4 <= multiplier1 && multiplier1 < 8)
            {
                multiplier1 -= 4;
                product += multiplier2 << 2;
            }
            if (2 <= multiplier1 && multiplier1 < 4)
            {
                multiplier1 -= 2;
                product += multiplier2 << 1;
            }
            if (0 <= multiplier1 && multiplier1 < 2)
            {
                multiplier1 -= 0;
                product += multiplier2 << 0;
            }

            Console.WriteLine(product);
            Console.ReadKey();
        }
    }
}
