using System;

namespace Queue
{
    class Program
    {
        static void Main()
        {
            try
            {
                Queue one = new Queue(5);

                Console.WriteLine($"The Queue is empty? :{one.IsEmpty()}");
                Console.ReadKey();

                //one.Get();

                Console.ForegroundColor = ConsoleColor.Red;
                foreach (object item in one)
                {
                    Console.Write("{0} ", item);
                }
            }
            catch(QueueException ex)
            {
                Console.WriteLine($"{ex.Message} \n{ex.StackTrace}");
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine($"{ex.Message} \n{ex.StackTrace}");
            }
            Console.ReadKey();
        }
    }
}
