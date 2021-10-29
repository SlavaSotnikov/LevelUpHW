using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class21_DoublyLinkedList
{
    internal class Program
    {
        static void Main()
        {
            /*
             * 
             */

            DoublyLinkedList one = new DoublyLinkedList();

            one.Add(4, Position.Back);
            one.Add(3, Position.Back);
            one.Add(2, Position.Back);
            one.Add(1, Position.Back);

            for (int i = 0; i < 4; i++)
            {
                one.Sort();
            }
            //one.Sort();

            Console.ReadKey();
        }
    }
}
