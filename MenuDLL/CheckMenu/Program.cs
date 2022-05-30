using System;

using MenuDLL;

namespace CheckMenu
{
    internal class Program
    {
        static void Main()
        {
            Menu menu= new Menu();
            menu.Run();

            Data one = Method(menu);

            Console.WriteLine("{0} {1} {2}", one.Name, one.Country, one.Model);
            Console.ReadKey();
        }

        private static Data Method(IUser source)
        {
            return source.GetUserData();
        }
    }
}
