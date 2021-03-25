using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the quantity of columns: ");
            ushort column = ushort.Parse(Console.ReadLine());

            Console.Write("Enter the quantity of srtings: ");
            ushort str = ushort.Parse(Console.ReadLine());

            Console.Write("Enter first symbol's code: ");
            ushort symbolFirst = ushort.Parse(Console.ReadLine());

            Console.Write("Enter last symbol's code: ");
            ushort symbolLast = ushort.Parse(Console.ReadLine());

            Console.WriteLine();
           
            for (ushort i = 0; i < str; i++)
            {
                for (ushort j = 0; j < column; j++)
                {
                    if (symbolLast > symbolFirst)
                        Console.Write($"{(char)symbolFirst++} "); 
                    else
                        Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
