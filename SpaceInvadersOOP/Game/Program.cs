using System;

namespace Game
{
    class Program
    {
        static void Main()
        {
            UI.SetBufferSize();

            Space game = new Space();
            
            game.Run();
        }
    }
}
