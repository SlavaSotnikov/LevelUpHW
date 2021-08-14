using System;

namespace Interface
{
    class Program
    {
        static void Main()
        {
            double[] src = new double[] { 1.0, -2.4, 7.21, -90.2 };
            double[] src2 = new double[] { -1.0, 2.4, -7.21, 90.2 };

            Z c1 = new Z(src);

            Print(c1);

            V c2 = new V(src2);

            Print(c2);

            Console.ReadKey();
        }

        public static void Print(IContainer c)
        {
            if (c == null)
            {
                return;
            }

            for (int i = 0; i < c.Size; i++)
            {
                Console.Write("{0} ", c[i]);
            }
            Console.WriteLine(); 
        }
    }
}
