using System;

namespace Shift_and_Addition
{
    class Program
    {
        static ushort GetPowerOfTwo(ushort multiplier1, ref ushort shift)
        {
            shift = 0;
            ushort rate = 0x01;
            while (rate <= multiplier1)
            {
                rate = (ushort)(rate << 1);
                shift++;
            }
            shift--;
            return (ushort)(rate >> 1);
        }
        static void Main()
        {
            ushort multiplier1 = 5;
            int multiplier2 = 2;
            int result = 0;
            ushort shift = 0;
            ushort balance = 0;

            balance = (ushort)(multiplier1 - GetPowerOfTwo(multiplier1, ref shift));
            result = multiplier2 << shift;

            while (balance > 0)
            {
                balance -= GetPowerOfTwo(balance, ref shift);
                result += multiplier2 << shift;
            }          

            Console.WriteLine("Shift and Addition: {0}", result);
            Console.WriteLine("Multiplication:     {0}", multiplier1 * multiplier2);
            Console.ReadKey();
        }
    }
}
