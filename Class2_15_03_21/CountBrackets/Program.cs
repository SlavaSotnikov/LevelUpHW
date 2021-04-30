using System;

namespace CountBrackets
{
    class Program
    {
        static void Main()
        {
            char a = '(';
            char b = ')';
            char c = ')';
            char d = ']';
            char e = '[';
            char f = '}';

            int count = 0;
            int count1 = 0;
            int count2 = 0;
            int index = 0;
            int index2 = 0;

            string str = a.ToString() + b.ToString() + c.ToString() + 
                d.ToString() + e.ToString() + f.ToString();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    count++;
                }
                if (str[i] == ')')
                {                    
                    count--;
                }
                if (str[i] == '{')
                {
                    count1++;
                }
                if (str[i] == '}')
                {
                    count1--;
                }
                if (str[i] == '[')
                {
                    count2++;
                }
                if (str[i] == ']')
                {
                    count2--;
                }
            }
            if (count == 0 && count1 == 0 && count2 == 0)
            {
                Console.WriteLine("Congrats! Your sentence is complete.");
            }
            if (count != 0)
            {
                Console.WriteLine($"You have to close {count} '(' brackets.");
            }
            if (count1 != 0)
            {
                Console.WriteLine("You have to close {0} '{' brackets.", count1);
            }
            if (count2 != 0)
            {
                Console.WriteLine($"You have to close {count2} '[' brackets.");
            }
            Console.ReadLine();


            Console.ReadKey();
        }
    }
}
