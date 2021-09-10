using System;

namespace ShevaKirTest
{
    class Program
    {
        static void Main()
        {
            QueueObject queue = new QueueObject(5);

            queue.Put(1);
            queue.Put(2);
            queue.Put(3);
            queue.Put(4);
            queue.Put(5);

            queue.GetData();

            queue.Put(6);

            foreach (object item in queue)
            {
                Console.Write("{0} ", item);
            }

            Console.ReadKey();
        }
    }
}
