using System;

namespace Game
{
    class Controller
    {
        //public static GameAction GetEvent()
        //{
        //    return UI.AskConsole();
        //}

        public static void ShowBorders(IGame source)
        {
            foreach (var item in source.Borders)
            {
                Coordinate res = new Coordinate(item); 
                UI.Print(res, ConsoleColor.White, '|');
            }
        }

        public static void Hide(IGame source)
        {
            for (int i = 0; i < source.Amount; i++)
            {
                UI.Hide(source[i]);
            }
        }

        public static void Show(IGame source)
        {
            for (int i = 0; i < source.Amount; i++)
            {
                UI.Show(source[i]);
            }
        }

        public static void ShowExplosion(ClashException ex)
        {
            UI.ShowExplosion(ex);
        }

        public static void ShowDisplay(IGame source)
        {
            for (int i = 0; i < source.Amount; i++)
            {
                if (source[i] is IUserShip one)
                {
                    if (one.Life != one.OldLife || one.HP != one.OldHP)
                    {
                        UI.ShowDisplay(one);
                    }

                    break;
                } 
            }
        }
    }
}
