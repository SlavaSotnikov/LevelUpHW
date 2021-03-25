using System;

namespace Task2
{
    class Program
    {        
        static void Main()
        {
            char[] charArr = new char[6];
            int count = 1;
            string sign = String.Empty;
            string index = String.Empty;
            string index1 = String.Empty;

            charArr[0] = '{';
            charArr[1] = '}';
            charArr[2] = '[';
            charArr[3] = '[';
            charArr[4] = ']';
            charArr[5] = ']';

            for (int i = 0; i < charArr.Length; i++)
            {
                for (int j = i + 1; j < charArr.Length; j++)
                {
                    if (charArr[i] == charArr[j])
                    {
                        count++;
                        sign += charArr[i];
                        //index += j;
                        //index1 += i;
                    }
                }                
            }
            Console.WriteLine("You have {0} similar signs {1}, index {2} {3}", count, sign, index, index1);

            Console.ReadLine();
        }
    }
}
