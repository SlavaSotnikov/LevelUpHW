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

            Deque<int> one = new Deque<int>();

            one.Add(1, Position.Front);
            one.Add(2);
            one.Add(3, Position.Front);
            one.Add(4);
            one.Add(5, Position.Front);

            try
            {
                one.Get();
                one.Get(Position.Front);
                one.Get();
                one.Get(Position.Front);
                one.Get();
            }
            catch (NoObjectException ex)
            {
                Console.WriteLine("{0}", ex);
            }

            Console.ReadKey();
        }
    }
}
