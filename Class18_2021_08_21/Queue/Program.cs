using System;

namespace Queue
{
    class Program
    {
        static void Main()
        {
            Queue one = new Queue(3);

            one.Add(1);
            one.Add(2);
            one.Add(3);

            one.Get();

            one.Add(4);
            one.Add(5);

            Console.ReadKey();
        }
    }
}
