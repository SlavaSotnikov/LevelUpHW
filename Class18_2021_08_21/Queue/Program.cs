using System;

namespace Queue
{
    class Program
    {
        static void Main()
        {
            Queue one = new Queue(3);

            one.Add("one");
            one.Add("two");
            one.Add("three");

            Console.WriteLine(one.Get());
            Console.WriteLine(one.Get());

            one.Add("four");
            one.Add("five");

            Console.ReadKey();
        }
    }
}
