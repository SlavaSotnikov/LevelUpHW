using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter first name: ");
            string firstString = Console.ReadLine();

            Console.Write("Enter second name: ");
            string secondString = Console.ReadLine();

            int firstStringChar = 0;
            int secondStringChar = 0;
            int i = -1;
            int j = -1;
            int countChars = 0;
            int firstCount = 0;
            int secondCount = 0;

            Console.WriteLine();

            do
            {
                firstStringChar = 0;
                for (i++; i < firstString.Length;)
                {
                    
                    firstStringChar = firstString[i]; // Ask a question about this cast.
                    firstCount++;
                    break;
                }

                secondStringChar = 0;
                for (j++; j < secondString.Length;)
                {
                   
                    secondStringChar = secondString[j];
                    secondCount++;
                    break;
                }
                
                if (firstStringChar < secondStringChar)
                {
                    Console.WriteLine($"The word '{firstString}' is first in word order.");
                    break;
                }
                if (firstStringChar > secondStringChar)
                {
                    Console.WriteLine($"The word '{secondString}' is first in word order.");
                    break;
                }
                
                if (countChars == firstString.Length && countChars == secondString.Length)
                {
                    Console.WriteLine($"The words '{firstString}' and '{secondString}' are completely the same.");
                    break;
                }
                else
                {
                    if (firstString.Length > secondString.Length && firstCount != secondCount)
                    {
                        Console.WriteLine($"The word '{secondString}' is first in word order.");
                        break;
                    }
                    if (firstString.Length < secondString.Length && firstCount != secondCount)
                    {
                        Console.WriteLine($"The word '{firstString}' is first in word order.");
                        break;
                    }
                }
                countChars++;
            } while (firstStringChar == secondStringChar);            

            Console.ReadLine();
        }
    }
}
