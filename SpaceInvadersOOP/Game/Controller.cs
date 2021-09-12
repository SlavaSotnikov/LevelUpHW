namespace Game
{
    class Controller
    {
        public static GameAction GetEvent()
        {
            return UI.AskConsole();
        }

        public static void Hide(Space source)
        {
            for (int i = 0; i < source.Amount; i++)
            {
                UI.Hide(source[i]);
            }
        }

        public static void Show(Space source)
        {
            for (int i = 0; i < source.Amount; i++)
            {
                UI.Show(source[i]);
            }
        }
    }
}
