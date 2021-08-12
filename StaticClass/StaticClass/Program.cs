using System;

namespace StaticClass
{
    class Program
    {
        static void Main()
        {
            //TestSingletone2();

            Singletone3 s2 = Singletone3.GetInstanse();
            Singletone3 s3 = Singletone3.GetInstanse();
            Singletone3 s4 = Singletone3.GetInstanse();

            Console.ReadKey();
        }

        private static void TestSingletone2()
        {
            Singletone2 s2 = Singletone2.GetInstanse();
            Singletone2 s3 = Singletone2.GetInstanse();
            Singletone2 s4 = Singletone2.GetInstanse();
        }
    }
}
