using System;

namespace Game
{
    class HeavyShip : LightShip
    {
        private string[] _image = new string[5]
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
