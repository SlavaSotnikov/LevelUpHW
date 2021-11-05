using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class22_BinaryTree_2021_11_01
{
    internal class Program
    {
        static void Main()
        {
            Tree<int> t1 = new Tree<int>();

            for (int i = 10; i < 20; i++)
            {
                t1.Add(i);
            }

            t1.Delete(15);

            //t1.Search(59);

            Console.WriteLine(t1);

            Console.ReadKey();
        }
    }
}
