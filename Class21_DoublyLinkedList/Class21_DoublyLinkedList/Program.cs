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
             */

            DoublyLinkedList one = new DoublyLinkedList();

            one.Add(6, Position.Back);
            one.Add(5, Position.Back);
            one.Add(4, Position.Back);
            one.Add(3, Position.Back);
            one.Add(2, Position.Back);
            one.Add(1, Position.Back);
            one.Add(7, Position.Back);
            one.Add(8, Position.Back);
            one.Add(9, Position.Back);

            one.Insert(9, 0);

            //one.Sort();

            Console.ReadKey();
        }
    }
}
