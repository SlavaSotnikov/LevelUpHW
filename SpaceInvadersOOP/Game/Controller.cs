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

                source[i].OldX = source[i].X;
                source[i].OldY = source[i].Y;
            }
        }
    }
}
