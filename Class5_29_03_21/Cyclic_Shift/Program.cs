using System;

namespace Cyclic_Shift
{
    class Program
    {
        static byte GetRightCycleShift(byte number, byte MASKRIGHT)
        {
            byte resultRight = 0;
            if ((number & 1) == 0)
            {
                resultRight = (byte)(number >> 1);
            }
            else
            {
                resultRight = (byte)((number >> 1) ^ MASKRIGHT);
            }
            return resultRight;
        }

        static byte GetLeftCycleShift(byte number, byte MASKLEFT, byte MASKRIGHT)
        {
            byte resultLeft = 0;
            if (number >= MASKRIGHT)
            {
                resultLeft = (byte)((number << 1) ^ MASKLEFT);
            }
            else
            {
                resultLeft = (byte)(number << 1);
            }
            return resultLeft;
        }
        static void Main()
        {
            byte number = byte.Parse(Console.ReadLine());
            
            const byte MASKRIGHT = 0x80;
            const byte MASKLEFT = 0x01;
           
            Console.WriteLine($"Figure {number}" + "\n" 
                +$"Right Shift: {GetRightCycleShift(number, MASKRIGHT)} Left Shift: {GetLeftCycleShift(number, MASKLEFT, MASKRIGHT)}");
            Console.ReadKey();
        }
    }
}
