using System;

namespace QueueList
{
    internal class Program
    {
        static void Main()
        {
            Queue<string> one = new Queue<string>();

            for (int i = 0; i < 5; i++)
            {
                one.Enqueue($"Word - {i}");
            }

            Console.WriteLine("Amount {0}", one.Amount);

            while (!one.IsEmpty)
            {
                Console.WriteLine(one.Dequeue().Data);
            }

            Console.WriteLine("Amount {0}", one.Amount);

            Console.ReadKey();
        }
    }
}
