using System;

namespace Check_Palindrome
{
    class Program
    {
        static bool CheckPalindrome(string str, int i, ref string back)
        {
            if (i >= str.Length)
            {
                return false;
            }

            CheckPalindrome(str, i + 1, ref back);

            back += Convert.ToString(str[i]);

            if (str == back)
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
            string str = "level";
            string back = String.Empty;
            int i = 0;
            bool res;

            res = CheckPalindrome(str, i, ref back);

            switch (res)
            {
                case true:
                    {
                        Console.WriteLine($"The word '{str}' is a palindrome.");
                        break;
                    }

                case false:
                    {
                        Console.WriteLine($"The word '{str}' isn't a palindrome.");
                        break;
                    }
            }

            Console.ReadKey();
        }       
    }
}
