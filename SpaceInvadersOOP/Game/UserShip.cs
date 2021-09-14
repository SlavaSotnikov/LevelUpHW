using System;

namespace Game
{
    abstract class UserShip : Ship
    {
        private byte _life;

        public UserShip(ISpace game, int coordX, int coordY, bool active, 
                uint speed, uint counter, byte hitpoints, byte lifes, int oldCoordX=0, int oldCoordY=0)
        {
            _game = game;
            _coordX = coordX;
            _coordY = coordY;
            _oldCoordX = oldCoordX;
            _oldCoordY = oldCoordY;
            _active = active;
            _speed = speed;
            _counter = counter;
            _hitPoints = hitpoints;
            _life = lifes;
            _width = 9;
        }
    }
}