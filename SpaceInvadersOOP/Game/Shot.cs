using System;

namespace Game
{
    class Shot : SpaceCraft
    {
        private string[] _bullet = { "│" };

        public override void Step()
        {
            _coordY -= STEP;
        }
    }
}