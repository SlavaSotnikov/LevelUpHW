using System;

namespace Game
{
    class Program
    {
        static void Main()
        {
            UI.SetBufferSize();

            GameField game = new GameField();

            game.AddObject(UI.AskShipModel());

            game.Run();
        }
    }
}
