using System;

namespace Game
{
    class Controller
    {
        public static void HideSpaceCrafts(SpaceCraft[] source, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                UI.Hide(source[i]);
            }
        }

        public static void ShowSpaceCrafts(SpaceCraft[] source, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                UI.Show(source[i]);
            }
        }
    }
}
