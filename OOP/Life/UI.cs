using System;

namespace Life
{
    class UI
    {
        public static int GetValue(string text, int def)
        {
            int value = def;

            do
            {
                Console.Write(text);
                string temp = Console.ReadLine();

                if (temp != "")
                {
                    int.TryParse(temp, out value);
                } 

            } while (value < 1);

            if (value == def)
            {
                Console.Write("By default: {0}\n", def); 
            }

            return value;
        }
    }
}
