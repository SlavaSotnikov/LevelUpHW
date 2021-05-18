using System;

namespace Tower_Of_Hanoi
{
    class Program
    {
        static void SolveTowerOfHanoi(int amount, char fromA, char toC, char auxB)
        {
            if (amount == 1)
            {
                Console.WriteLine($"Move disc 1 from {fromA} to {toC}");

                return;
            }

            SolveTowerOfHanoi(amount - 1, fromA, auxB, toC);

            Console.WriteLine($"Move disk {amount} form {fromA} to {toC}");

            SolveTowerOfHanoi(amount - 1, auxB, toC, fromA);
        }
        static void Main()
        {
            SolveTowerOfHanoi(5, 'A', 'C', 'B');
            Console.ReadKey();
        }
    }
}
