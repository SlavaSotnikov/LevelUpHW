using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            char yourChar = '\0';            
            string str = String.Empty;

            Console.WriteLine("Press q and quite.");
            Console.WriteLine("Enter a sequence of brackets: ");            

            while (yourChar != 'q')
            {
                yourChar = Console.ReadKey().KeyChar;
                str += yourChar.ToString();
            }

            string bracket = String.Empty;
            string bracket1 = String.Empty;
            string bracket2 = String.Empty;

            int close = 0;
            int open = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == ')')
                {
                    bracket += str[i].ToString();
                }
                if (str[i] == '{' || str[i] == '}')
                {
                    bracket1 += str[i].ToString();
                }
                if (str[i] == '[' || str[i] == ']')
                {
                    bracket2 += str[i].ToString();
                }
            }

            int l = 0;
            for (; l < bracket.Length - 1; l++)
            {
                if (bracket[l] < bracket[l + 1])
                {
                    close++;
                    l++;                  
                }
                else
                {
                    open++;                    
                }
                if (l == bracket.Length - 1)
                {
                    break;
                }
            }
            if (bracket[l - 1] == bracket[bracket.Length - 1] || bracket[l - 1] > bracket[bracket.Length - 1])
            {
                open++;
            }

            Console.WriteLine();
            Console.WriteLine("The sequence has {0} close and {1} open brackets.", close, open);
            Console.ReadKey();
        }
    }
}
