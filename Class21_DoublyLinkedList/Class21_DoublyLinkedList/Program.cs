using System;

namespace Class21_DoublyLinkedList
{
    internal class Program
    {
        static void Main()
        {
            /*
             *            Doubly Linked List
             *            
             * Use Position enum for adding data to list.
             * 
             * Example: 
             *  Add(data, Position.Front);
             *  Add(data, Position.Back);
             *  
             *  Insert(Data of previos item, Data);
             */

            DoublyLinkedList<int> one = new DoublyLinkedList<int>();

            one.Add(6);
            one.Add(5);
            one.Add(4);
            one.Add(3);
            one.Add(2);
            one.Add(1);
            one.Add(7);
            one.Add(8);
            one.Add(9);

            one.Insert(9, 0);

            one.Sort();

            foreach (int item in one)
            {
                Console.Write("{0} ", item);
            }

            Console.ReadKey();
        }
    }
}
