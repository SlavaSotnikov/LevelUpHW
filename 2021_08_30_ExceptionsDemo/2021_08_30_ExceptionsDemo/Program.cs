using System;

using DividerLib;

namespace _2021_08_30_ExceptionsDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                Divider d = new Divider(10, 0);
                int res = d.Run();

                Console.WriteLine("{0} ", res);
            }
            catch (DividerException ex)
            {
                Console.WriteLine(ex);
            }

            

            Console.ReadKey();
        }
    }
}
