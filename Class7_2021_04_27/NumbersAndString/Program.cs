using System;

namespace NumbersAndString
{
    class Program
    {
        static void Main()
        {
            string str = "My phone number is 000000";
            string numbers = String.Empty;
            string words = String.Empty;
            int i = 0;
            
            GetNumbersAndString(str, ref words, ref numbers, i);

            Console.WriteLine("{0}\t{1}", numbers, words);
            Console.ReadKey();
        }

        static void GetNumbersAndString(string str, ref string words, ref string numbers, int i)
        {
            const int FIRST_DIGIT = 48;
            const int LAST_DIGIT = 57;
            const int FIRST_CHAR = 65;
            const int LAST_CHAR = 122;

            if (i <= str.Length - 1)
            {
                if (FIRST_DIGIT <= str[i] && str[i] <= LAST_DIGIT)
                {
                    numbers += Convert.ToString(str[i]);

                    GetNumbersAndString(str, ref words, ref numbers, i + 1);
                }

                if (FIRST_CHAR <= str[i] && str[i] <= LAST_CHAR)
                {
                    words += Convert.ToString(str[i]);

                    GetNumbersAndString(str, ref words, ref numbers, i + 1);
                }

                if (str[i] == ' ' || str[i] == ',' || str[i] == '.')
                {
                    GetNumbersAndString(str, ref words, ref numbers, i + 1);
                } 
            }                        
        }
    }
}
