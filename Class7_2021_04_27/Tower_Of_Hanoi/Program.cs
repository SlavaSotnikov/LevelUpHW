using System;
using static System.Console;

namespace Tower_Of_Hanoi
{
    class Program
    {
        static void towerOfHanoi(int amount, char from, char to, char aux)
        {
            if (amount == 1)
            {
                WriteLine($"Move disc 1 from {from} to {to}");
                return;
            }

            towerOfHanoi(amount - 1, from, aux, to);

            WriteLine($"Move disk {amount} form {from} to {to}");

            towerOfHanoi(amount - 1, aux, to, from);
        }
        static void Main()
        {
            towerOfHanoi(5, 'A', 'C', 'B');
            ReadKey();
        }
    }
}
