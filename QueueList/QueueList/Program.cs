using System;

namespace QueueList
{
    internal class Program
    {
        static void Main()
        {
            Queue<string> one = new Queue<string>();

            Console.WriteLine(one.IsFool);

            uint i = 0;
            while (!one.IsFool)
            {
                one.Enqueue($"{++i}");
            }

            //for (int i = 0; i < 5; i++)
            //{
            //    try
            //    {
            //        one.Enqueue($"Word - {i}");
            //    }
            //    catch (NoObjectException ex)
            //    {
            //        Console.WriteLine(ex.Message, ex.StackTrace);
            //    }
            //}

            //Console.WriteLine("Amount {0}", one.Amount);

            //while (!one.IsEmpty)
            //{
            //    Console.WriteLine(one.Dequeue().Data);
            //}

            //Console.WriteLine("Amount {0}", one.Amount);

            Console.ReadKey();
        }
    }
}
