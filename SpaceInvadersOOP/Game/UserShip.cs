using System;

namespace Game
{
    abstract class UserShip : Ship, IDisplay
    {
        private byte _life;
        private byte _oldLife;

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

        byte IDisplay.OldLife
        {
            get
            {
                return _oldLife;
            }
            set
            {
                _oldLife = value;
            }
        }
        byte IDisplay.OldHP 
        { 
            get
            {
                return _oldHitPoints;
            }
            set
            {
                _oldHitPoints = value;
            }

        }

        byte IDisplay.Life
        {
            get
            {
                return _life;
            }
            set
            {
                _life = value;  
            }
        }
        byte IDisplay.HP
        {
            get
            {
                return _hitPoints;
            }
            set
            {
                _hitPoints = value;
            }
        }
    }
}