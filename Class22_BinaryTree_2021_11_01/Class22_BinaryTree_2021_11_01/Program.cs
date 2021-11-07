using System;

namespace Class22_BinaryTree_2021_11_01
{
    internal class Program
    {
        static void Main()
        {
            Tree<int> t1 = new Tree<int>();

            for (int i = 0; i < 20; i++)
            {
                t1.Add(i);
            }

            //t1.Add(1);
            //t1.Add(2);
            //t1.Add(3);
            //t1.Add(4);
            //t1.Add(5);
            //t1.Add(6);
            //t1.Add(7);
            //t1.Add(9);
            //t1.Add(13);
            //t1.Add(20);
            //t1.Add(14);

            // t1.Delete(15);

            //t1.Search(59);

            Console.WriteLine(t1);

            Console.ReadKey();
        }
    }
}
