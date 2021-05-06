using System;

namespace NumbersAndString
{
    class Program
    {
        static void Main()
        {
            string str = "My phone number is 0123456";
            string digits = String.Empty;
            string words = String.Empty;

            Console.WriteLine("{0} ", GetNumbersAndString(str, ref digits, ref words));
            Console.ReadKey();
        }

        static string GetNumbersAndString(string str, ref string digits, ref string words, int i=-1)
        {            
            i++;
            if (i >= str.Length)
            {
                return "";
            }

            if (char.IsDigit(str[i]))
            {

                digits += Convert.ToString(str[i]);
            }
            else
            {
                words += Convert.ToString(str[i]);
            }
            
            GetNumbersAndString(str, ref digits, ref words, i);
                      
            return digits + " " + words;
        }
    }
}
