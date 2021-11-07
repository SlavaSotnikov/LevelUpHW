using System;
using System.Collections.Generic;

namespace Class22_BinaryTree_2021_11_01
{
    internal class Program
    {
        static void Main()
        {
            IDictionary<int, string> t1 = new Tree<int, string>();

            for (int i = 0; i < 20; i++)
            {
                t1.Add(i, $"Value {i}");
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

            Console.WriteLine(t1.TryGetValue(5, out var data));
            Console.WriteLine(data);

            //t1.Search(59);

            //Console.WriteLine(t1);

            Console.ReadKey();
        }
    }
}
