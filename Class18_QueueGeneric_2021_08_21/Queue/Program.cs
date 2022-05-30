using System;

namespace Queue
{
    class Program
    {
        static void Main()
        {
            Queue<string> one = new Queue<string>();

            try
            {
                one.Add("1");
                one.Add("2");
                one.Add("3");
                one.Add("4");
                one.Add("5");

                one.Remove("1");

                one.Add("6");

                one.Resize(6);

                //one.Get();
                //one.Get();

                one.Add("7");
            }
            catch(QueueException ex)
            {
                Console.WriteLine($"{ex.Message} \n{ex.StackTrace}");
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine($"{ex.Message} \n{ex.StackTrace}");
            }

            foreach (string item in one)
            {
                Console.Write("{0} ", item);
            }

            Console.ReadKey();
        }
    }
}
