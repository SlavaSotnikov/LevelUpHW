using System;
using MenuLibrary;

namespace GameMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu gameMenu = new Menu();
            gameMenu.Run();

            Data one = Meth(gameMenu);

            Console.WriteLine();
        }

        public static Data Meth(IMenu source)
        {
            return source.GetUserData();
        }
    }
}
