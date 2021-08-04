using System;

namespace Game
{
    class HeavyShip : LightShip
    {
        private string[] _heavyShip = new string[5]
        { "    ▲    ",
          "   ╱Ο╲   ",
          "∩ ╱UKR╲ ∩",
          "╠═══Λ═══╣",
          " <╱*╦*╲> "
        };

        public HeavyShip()
            : base()
        {
        }
    }
}
