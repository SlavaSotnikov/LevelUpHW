using System;

namespace ClassDequeImplement
{
    internal class Program
    {
        static void Main()
        {
            /*
             *          DEQUE
             *          
             * Use Position enum for adding/getting data to deque.
             * 
             * Example: 
             *  Add(data, Position.Front);
             *  Get(data, Position.End);
             */

            Deque one = new Deque();

            one.Add(1, Position.Front);
            one.Add(2, Position.End);
            one.Add(3, Position.Front);
            one.Add(4, Position.End);
            one.Add(5, Position.Front);

            one.Get(Position.End);
            one.Get(Position.Front);
            one.Get(Position.End);
            one.Get(Position.Front);
            one.Get(Position.End);

            Console.ReadKey();
        }
    }
}
