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

            StringBuilder sb = new StringBuilder(String.Empty, 0);

            Console.WriteLine("{0} ", GetNumbersAndString(str, sb));

            Console.ReadKey();
        }

        static string GetNumbersAndString(string str, StringBuilder sb, int i=0)
        {
            if (i >= str.Length)
            {
                return sb.ToString();
            }

            if (char.IsDigit(str[i]))
            {
                sb.Append(str[i]);
            }

            GetNumbersAndString(str, sb, i + 1);

            if (!char.IsDigit(str[i]))
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }
    }
}
