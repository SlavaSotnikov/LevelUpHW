using System;
using System.Text;

namespace Menu
{
    class Menu
    {
        private int _selectedIndex;
        private string[] _options;
        private string _title;

        public Menu(string title, string[] options)
        {
            _title = title;
            _options = options;
            _selectedIndex = 0;
        }

        public void DisplayOptions()
        {
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_title);
            Console.ForegroundColor = prevColor;

            int count = 0;

            for (int i = 0; i < _options.Length; i++)
            {
                ++count;
                string currentOption = _options[i];
                string pointer;

                if (i == _selectedIndex)
                {                    
                    pointer = "\u2192";
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.ResetColor();
                    pointer = " ";
                }
                Console.SetCursorPosition(50, 8 + count);
                Console.WriteLine($"{pointer} {currentOption} ");                                
            }
            Console.ResetColor();

            Console.SetCursorPosition(47, 25);
            Console.WriteLine("\xA9 2021 LevelUp\x2122");
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {                    
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                    {
                        _selectedIndex = _options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _options.Length)
                    {
                        _selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return _selectedIndex;
        }

    }
}
