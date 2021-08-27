using System;

namespace Container
{
    class Program
    {
        static void Main()
        {
            Container c3 = new Container();

            c3.Add("one");
            c3.Add("sd");
            c3.Add("f");

            foreach (string item in c3)
            {
                Console.WriteLine("{0} ", item);
            }

            Console.ReadKey();
        }
    }
}
