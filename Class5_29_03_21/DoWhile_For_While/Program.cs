using System;

namespace DoWhile_For_While
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string output = String.Empty;




            // For using While
            /*
            for (int i = 0; i < input.Length; i++)
            {
                 output += input[i];
            }

            int i = 0;
            while (i < input.Length)
            {
                output += input[i];
                i++;
            }
            */

            //While using For

            /*
            while (input != "0")
            {
                 Console.WriteLine("while");
            }

            input = Console.ReadLine();
            for (; input != "0"; )
            {
                Console.WriteLine("for");
            }
            */

            //DoWhile using For


            /*
            for (int i = 0; i <= 0; i++)
            {
                Console.WriteLine("for");
            }
            */

            //For using DoWhile 

            
            int i = 0;
            do
            {
                output += input[i];
                i++;
            } while (i < input.Length);
            

            //DoWhile using While

            // We can use <= or >= with While cycle. In these cases we have a one cycle, then false and quite.

            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
