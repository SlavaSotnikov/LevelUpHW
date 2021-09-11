using System;

namespace Game
{
    class Controller
    {
        public static GameAction GetEvent()
        {
            return UI.AskConsole();
        }

        public static void Hide(SpaceCraft[] source, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                UI.Hide(source[i]);
            }
        }

        public static void Show(SpaceCraft[] source, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                UI.Show(source[i]);
            }
        }
    }
}
