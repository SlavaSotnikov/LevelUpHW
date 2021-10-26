using System;

namespace QueueList
{
    internal class Program
    {
        static void Main()
        {
            Queue one = new Queue();

            one.Enqueue(1); 
            one.Enqueue(2);
            one.Enqueue(3);
            one.Enqueue(4);
            one.Enqueue(5);

            foreach (Entry item in one)
            {
                Console.WriteLine("{0}", item.Data);
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
