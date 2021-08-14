using System;

namespace Game
{
    class EnemyShot : Shot
    {
        public EnemyShot(int x, int y, int oldX = 0, int oldY = 0,
                uint speed = 10000, uint counter = 0)
            :base(x, y, oldX, oldY, speed)
        {

        }

        public override void Step()
        {
            _coordY += _step;
        }
    }
}
