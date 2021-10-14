using System;
using System.Text;

namespace MenuDLL
{
    public class Menu : IUser
    {
        private int _selectedIndex;
        private readonly string[] _options;

        public Menu()
        {
            _options = new[] { "1 PLAYER", "2 PLAYERS", "ABOUT", "EXIT" };
            _selectedIndex = 0;
        }

        public void Run()
        {
            Options options = Options.None;

            do
            {
                UI.ShowTitle();

                switch ((Options)SelectOption())
                {
                    case Options.None:
                        break;
                    case Options.OnePlayer:
                        UI.Print(Text.Introduction);
                        UI.PrintDialogue(Text.Dialogue, 30, 10, 0);
                        UI.PickAShip();
                        options = Options.Exit;
                        break;
                    case Options.TwoPlayers:
                        break;
                    case Options.About:
                        UI.ShowAboutInfo(Text.About);
                        break;
                    case Options.Exit:
                        options = Options.Exit;
                        break;
                    default:
                        break;
                }

            } while (options != Options.Exit);
        }

        public void DisplayOptions()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string pointer;

            for (int i = 0; i < _options.Length; i++)
            {
                if (i == _selectedIndex)
                {
                    pointer = "\u2192";
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    pointer = " ";
                    Console.ResetColor();
                }

                Console.SetCursorPosition(50, 8 + i);
                Console.WriteLine($"{pointer} {_options[i]} ");
            }
        }

        public int SelectOption()
        {
            ConsoleKeyInfo keyPressed;

            do
            {
                DisplayOptions();

                keyPressed = Console.ReadKey(true);

                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                    {
                        _selectedIndex = _options.Length - 1;
                    }
                }

                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _options.Length)
                    {
                        _selectedIndex = 0;
                    }
                }

            } while (keyPressed.Key != ConsoleKey.Enter);

            return _selectedIndex;
        }

        public Data GetUserData()
        {
            return new Data(UI.Name, UI.Country, UI.Model);
        }
    }
}
