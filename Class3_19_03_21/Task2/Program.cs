using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            string sentence = "It's not a piece ()of cake.";
            int count  = 0;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            string index  = String.Empty;
            string index1 = String.Empty;
            string index2 = String.Empty;
            string index3 = String.Empty;
            string index4 = String.Empty;
            string index5 = String.Empty;
            string empty = " ";
            char symbol = '(';
            char symbol1 = ')';
            char symbol2 = '{';
            char symbol3 = '}';
            char symbol4 = '[';
            char symbol5 = ']';


            for (int i = 0; i < sentence.Length; i++)
            {
                switch (sentence[i])
                {
                    case '(':
                        symbol = sentence[i];
                        count++;
                        index += i + empty;
                        break;
                    case ')':
                        symbol1 = sentence[i];
                        count1++;
                        index1 += i + empty;
                        break;
                    case '{':
                        count2++;
                        index2 += i + empty;
                        break;
                    case '}':
                        count3++;
                        index3 += i + empty;
                        break;
                    case '[':
                        count4++;
                        index4 += i + empty;
                        break;
                    case ']':
                        count5++;
                        index5 += i + empty;
                        break;

                    default:
                        break;
                }
            }

            if (count != count1)
            {
                if (count > count1)
                {
                    Console.WriteLine($"You have to add {count - count1} '{symbol1}' symbol.");
                }
                if (count1 > count)
                {
                    Console.WriteLine($"You have to add {count1 - count} '{symbol}' symbol.");
                }
            }
            
            if (count2 != count3)
            {
                if (count2 > count3)
                {
                    Console.WriteLine($"You have to add {count2 - count3} '{symbol3}' symbol.");
                }
                if (count3 > count2)
                {
                    Console.WriteLine($"You have to add {count3 - count2} '{symbol2}' symbol.");
                }
            }

            if (count4 != count5)
            {
                if (count4 > count5)
                {
                    Console.WriteLine($"You have to add {count4 - count5} '{symbol5}' symbol.");
                }
                if (count5 > count4)
                {
                    Console.WriteLine($"You have to add {count5 - count4} '{symbol4}' symbol.");
                }
            }
            if (count == count1 && count2 == count3 && count4 == count5)
            {
                Console.WriteLine("All your brackets are even.");
            }

            
            Console.ReadLine();
        }
    }
}
