using System;

namespace Queue
{
    class Program
    {
        static void Main()
        {
            Queue one = new Queue(5);

            one.Add("one");
            one.Add("two");
            one.Add("three");
            one.Add("four");
            one.Add("five");

            one.Get();
            one.Get();
            
            one.Add("six");
            one.Add("seven");
            one.Add("eight");


            foreach (object item in one)
            {
                Console.WriteLine("{0} ", item);
            }

            Console.ReadKey();
        }
    }
}
