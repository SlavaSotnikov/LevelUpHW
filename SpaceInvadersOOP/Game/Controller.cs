namespace Game
{
    class Controller
    {
        public static GameAction GetEvent()
        {
            return UI.AskConsole();
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

                //source[i].OldX = source[i].X;    // TODO: Move to UserShip.
                //source[i].OldY = source[i].Y;
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

                    one.OldLife = one.Life;    // TODO: Move to Ship.
                    one.OldHP = one.HP;

                    break;
                } 
            }
        }
    }
}
