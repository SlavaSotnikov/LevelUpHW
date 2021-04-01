using System;

namespace Min_Max
{
    class Program
    {
        static void Main()
        {
            /*
            // While()

            int number = 0; //Do I have to initialize this variable, or I can declare the variable like this?
          //int number;       Why? Why not?

            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());

            int max = number;
            int min = number;

            while (number != -1) // How can I quit the program avoid numbers?
            {
                if (number > max)
                {
                    max = number;
                }
                if (number < min)
                {
                    min = number;
                }

                Console.Write("Max: {0}  Min: {1}   ", max, min);

                number = int.Parse(Console.ReadLine());
            }
            */

            // Do While()

            /*
            int number = 0;

            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());

            int max = number;
            int min = number;

            do
            {
                if (number > max)
                {
                    max = number;
                }
                if (number < min)
                {
                    min = number;
                }

                Console.Write("Max: {0}  Min: {1}   ", max, min);

                number = int.Parse(Console.ReadLine());

            } while (number != -1);
            */

            // For(;;)

            /*
            int number = 0;

            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());

            int max = number;
            int min = number;

            for ( ; number != -1; )
            {
                if (number > max)
                {
                    max = number;
                }
                if (number < min)
                {
                    min = number;
                }

                Console.Write("Max: {0}  Min: {1}   ", max, min);

                number = int.Parse(Console.ReadLine());
            }
            */

            //It's all for nothing.

            /*
            string number = String.Empty;
            string numberStr = String.Empty;
            int numberInt = 0;

            Console.Write("Enter a number: ");
            numberStr = Console.ReadLine();

            int max = Convert.ToInt32(numberStr);
            int min = Convert.ToInt32(numberStr);

            for (int i = 0; i < numberStr.Length; i++)
            {
                number += Convert.ToString(numberStr[i] - '0');
                numberInt = Convert.ToInt32(number);
            }
           

            for (; numberStr.ToLower() != "q";)
            {
                if (numberInt > max)
                {
                    max = numberInt;
                }
                if (numberInt < min)
                {
                    min = numberInt;
                }

                Console.Write("Max: {0}  Min: {1}   ", max, min);

                numberStr = Console.ReadLine();
                number = String.Empty;
                for (int i = 0; i < numberStr.Length; i++)
                {
                    
                    number += Convert.ToString(numberStr[i] - '0');
                    numberInt = Convert.ToInt32(number);
                }
                
            }
            */
        }
    }
}
