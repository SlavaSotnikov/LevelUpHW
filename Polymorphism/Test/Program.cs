using System;

namespace Test
{
    class Program
    {
        static void Main()
        {
            object obj = new C();

            ((C)obj).F();






            Console.ReadKey();
        }
    }
}
