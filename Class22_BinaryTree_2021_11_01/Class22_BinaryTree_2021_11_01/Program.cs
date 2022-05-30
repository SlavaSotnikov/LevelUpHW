using System;
using System.Collections.Generic;

namespace Class22_BinaryTree_2021_11_01
{
    internal class Program
    {
        static void Main()
        {
            IDictionary<int, string> t1 = new Tree<int, string>();

            for (int i = 0; i < 10; i++)
            {
                t1.Add(i, $"Value {i}");
            }

            //t1.Add(new KeyValuePair<int, string>(5, "Value"));
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

            foreach (KeyValuePair<int, string> i in t1)
            {
                Console.WriteLine("{0} {1}", i.Key, i.Value);
            }

            //Console.WriteLine(t1.Count);

            //t1.Search(59);

            //string[] keys = new string[10];
            //t1.Values.CopyTo(keys, 0);

            //for (int i = 0; i < keys.Length; i++)
            //{
            //    //keys[i] = "100";
            //    Console.WriteLine(keys[i]);
            //}

            //List<int> keys = (List<int>)t1.Keys;

            //Console.WriteLine(t1.Keys);

            Console.WriteLine(t1);

            Console.ReadKey();
        }
    }
}
