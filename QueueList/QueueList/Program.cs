using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Console.WriteLine(one.Amount);

            one.Dequeue();
            one.Dequeue();
            one.Dequeue();
            one.Dequeue();
            one.Dequeue();

            Console.WriteLine(one.Amount);

            Console.ReadKey();
        }
    }
}
