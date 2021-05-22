using System;
using System.Linq;
using System.Text;

namespace NumbersAndString
{
    class Program
    {
        static void Main()
        {
            string source = "My phone number is 123456";

            GetNumbersAndString(source);

            Console.ReadKey();
        }

        public static void GetNumbersAndString(string source)
        {
            StringBuilder sb = new StringBuilder(source.Length);

            GetNumbersAndString(source, sb);

            Console.WriteLine("{0} ", sb.ToString());
        }

        private static void GetNumbersAndString(string source, StringBuilder destination, int i=0)
        {
            if (i >= source.Length)
            {
                return;
            }

            if (char.IsDigit(source[i]))
            {
                destination.Append(source[i]);
            }

            GetNumbersAndString(source, destination, i + 1);

            if (!char.IsDigit(source[i]))
            {
                destination.Append(source[i]);
            }
        }
    }
}
