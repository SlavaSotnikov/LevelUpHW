using System;

namespace QueueList
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> one = new Queue<int>();

            one.Enqueue(1); 
            one.Enqueue(2);
            one.Enqueue(3);
            one.Enqueue(4);
            one.Enqueue(5);
            one.Enqueue(6);
            one.Enqueue(7);

            //one.Reverse();

            foreach (int item in one)
            {
                Console.WriteLine(item);    // TODO: Search OutOfMemoryException.
            }

            //try
            //{
            //    uint i = 0;
            //    while (!one.IsFool)
            //    {
            //        one.Enqueue(++i);
            //    }
            //}
            //catch (NoObjectException ex)
            //{
            //    Console.WriteLine(ex);
            //}

            Console.ReadKey();
        }
    }
}
