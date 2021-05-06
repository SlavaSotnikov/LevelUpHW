using System;
using System.Text;

namespace Check_Palindrome
{
    class Program
    {
        static bool CheckPalindrome(string text, ref string first, ref string second, int i=0)
        {
            string textLower = text.ToLower();
            if (i == textLower.Length - 1)
            {
                return false;
            }

            while (textLower[i] == ' ' || textLower[i] == ',' || textLower[i] == '.' || textLower[i] == '!') { i++; }

            first += textLower[i];

            CheckPalindrome(text, ref first, ref second, i + 1);

            second += textLower[i];

            if (first == second)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        static void Main()
        {
            string text = "Never, odd or even!";
            string first = String.Empty;
            string second = String.Empty;

            bool res = CheckPalindrome(text, ref first, ref second);

            switch (res)
            {
                case true:
                    Console.WriteLine("'{0}' \n is a palindrome.", text); break;
                case false:
                    Console.WriteLine("'{0}' \n isn't a palindrome.", text); break;
            }
            
            Console.ReadKey();
        }       
    }
}
