using System;

namespace Game
{
    class EnemyShip : Ship
    {
        public EnemyShip()
        {
            _coordX = BL_Random.GetCoordinateX();
            _coordY = 1;
            _oldCoordX = 2;
            _oldCoordY = 2;
            _active = true;
            _counter = 0;
            _view = UI.GetFly();
            _speed = BL_Random.GetFlySpeed();
        }
        public override void Step()
        {
            _coordY += STEP;
        }
    }
}