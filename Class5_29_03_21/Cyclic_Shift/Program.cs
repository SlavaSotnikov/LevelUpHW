using System;

namespace Cyclic_Shift
{
    class Program
    {
        static void Main()
        {
            // Right Cycle Shift

            byte number = 6;
            byte resultRight = 0;
            byte resultLeft = 0;
            const byte MASKRIGHT = 0x80;
            const byte MASKLEFT = 0x01;

            if ((number & 1) == 0)
            {
                resultRight = (byte)(number >> 1);
            }
            else
            {
                resultRight = (byte)((number >> 1) ^ MASKRIGHT);
            }

            // Left Cycle Shift

            if (number >= MASKRIGHT)
            {
                resultLeft = (byte)((number << 1) ^ MASKLEFT);
            }
            else
            {
                resultLeft = (byte)(number << 1);
            }

            Console.WriteLine($"Figure {number}" + "\n" 
                +$"Right Shift: {resultRight} Left Shift: {resultLeft}");
            Console.ReadKey();
        }
    }
}
