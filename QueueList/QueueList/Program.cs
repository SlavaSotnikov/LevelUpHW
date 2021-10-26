using System;

namespace QueueList
{
    internal class Program
    {
        static void Main()
        {
            Queue<string> one = new Queue<string>();

            try
            {
                uint i = 0;
                while (!one.IsFool)
                {
                    one.Enqueue($"{++i}");
                }
            }
            catch (NoObjectException ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}
