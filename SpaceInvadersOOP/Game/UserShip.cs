using System;

namespace Game
{
    abstract class UserShip : Ship
    {
        protected byte _life;

        public UserShip()
        {
            _coordX = INITIAL_X;
            _coordY = INITIAL_Y;
            _oldCoordX = INITIAL_X + 1;
            _oldCoordY = INITIAL_Y - 1;
            _active = true;
            _speed = 1;
            _counter = 0;
            _hitPoints = HITPOINTS;
            _life = LIFES;
        }
    }
}