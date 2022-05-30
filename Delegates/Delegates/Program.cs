using System;

namespace Delegates
{
    public delegate void Show();

    internal class Program
    {
        static void Main()
        {
            Show show = Print1;
            Show show2 = Print2;
            Show show3 = Print3;

            show += show2;
            show += show3;
            show.Invoke();

            Console.ReadKey();
        }

        public static void Print1()
        {
            Console.WriteLine("Print1");
        }

        public static void Print2()
        {
            Console.WriteLine("Print2");
        }

        public static void Print3()
        {
            Console.WriteLine("Print3");
        }
    }
}
