using System;

namespace Game
{
    abstract class UserShip : Ship
    {
        private static int _shipAmount = 0;
        private static int _oldShipAmount = 0;

        private byte _life;

        public static int ShipAmount
        {
            get
            {
                return _shipAmount;
            }
            set
            {
                _shipAmount = value;
            }
        }
        public static int OldShipAmount
        {
            get
            {
                return _oldShipAmount;
            }
            set
            {
                _oldShipAmount = value;
            }
        }

        public UserShip(Space game, int coordX, int coordY, bool active, 
                uint speed, byte width, uint counter, byte hitpoints, byte lifes, int oldCoordX=0, int oldCoordY=0)
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
            _width = width;
            ++_shipAmount;
        }
    }
}