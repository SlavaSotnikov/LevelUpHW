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

                one.Add(1);
                one.Add(2);
                one.Add(3);
                one.Add(4);
                one.Add(5);

                //one.Resize(6);

                //one.Get();
                //one.Get();

                one.Add(6);

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
