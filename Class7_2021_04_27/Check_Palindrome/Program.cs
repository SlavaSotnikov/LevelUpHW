using System;
using System.Text;

namespace Check_Palindrome
{
    class Program
    {
        static bool IsPalindrome(string text, int back, int ahead=0)
        {
            if (ahead >= back)
            {
                return true;
            }

            else
            {
                while (char.IsPunctuation(text[ahead]) || char.IsWhiteSpace(text[ahead]))
                {
                    ++ahead;
                }

                while (char.IsPunctuation(text[back]) || char.IsWhiteSpace(text[back]))
                {
                    --back;
                }


                if (text[ahead] == text[back])
                {
                    IsPalindrome(text, back - 1, ahead + 1);
                }
                else
                {
                    return false;
                }
            }

            return true; 
        }
        
        static void Main()
        {
            string text = "Never, odd or even!";

            bool res = IsPalindrome(text.ToLower(), text.Length - 1);

            switch (res)
            {
                case true:
                    Console.WriteLine("'{0}' \n is a palindrome.", text); 
                    break;
                case false:
                    Console.WriteLine("'{0}' \n isn't a palindrome.", text); 
                    break;
            }
            
            Console.ReadKey();
        }       
    }
}
