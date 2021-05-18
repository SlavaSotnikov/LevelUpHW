using System;
using System.Linq;
using System.Text;

namespace NumbersAndString
{
    class Program
    {
        static void Main()
        {
            string str = "My phone number is 123456";

            StringBuilder sb = new StringBuilder(str);

            Console.WriteLine("{0} ", GetNumbersAndString(sb));
            Console.ReadKey();
        }

        static string GetNumbersAndString(StringBuilder str, int i=0)
        {
            if (i >= str.Length)
            {
                return "";
            }

            if (char.IsDigit(str[i]))
            {                
                str.Insert(0, str[i]);

                str.Remove(i + 1, 1);
            }

            GetNumbersAndString(str, i + 1);

            return str.ToString();
        }
    }
}
