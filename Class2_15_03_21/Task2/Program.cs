using System;

namespace Task2
{
    class Program
    {        
        static void Main()
        {
            char[] charArr = new char[6];
            int count = 0;
            int count1 = 0;
            int count2 = 0;

            string sign = String.Empty;
            string index = String.Empty;
            string index1 = String.Empty;

            charArr[0] = '{';
            charArr[1] = '}';
            charArr[2] = '[';
            charArr[3] = '[';
            charArr[4] = '(';
            charArr[5] = ']';

            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] == '(')
                {
                    count++;
                }
                if (charArr[i] == ')')
                {
                    count--;
                }
                if (charArr[i] == '{')
                {
                    count1++;
                }
                if (charArr[i] == '}')
                {
                    count1--;
                }
                if (charArr[i] == '[')
                {
                    count2++;
                }
                if (charArr[i] == ']')
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
        }
    }
}
