using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Menu
{
    class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        public void DisplayOptions()
        {
            OutputEncoding = Encoding.UTF8;

            ConsoleColor prevColor = ForegroundColor;
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine(Prompt);
            ForegroundColor = prevColor;

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {                    
                    prefix = "\u2192";
                    ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    ResetColor();
                    prefix = " ";
                }                
                WriteLine($"\t\t\t\t\t\t{prefix} {currentOption} ");                                
            }
            ResetColor();
           
            WriteLine("\n\t\t\t\t\t\t\xA9 2021 LevelUp\x2122");
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {                    
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }

    }
}
