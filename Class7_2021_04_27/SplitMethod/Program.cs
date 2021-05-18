using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMethod
{
    class Program
    {
        static void Main()
        {
            string text = "И поэтому, все так произошло.";

            string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' });

            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i]);
            }

            Console.ReadKey();
        }
    }
}
