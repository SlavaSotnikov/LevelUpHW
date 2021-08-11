using System;

namespace Game
{
    class EnemyShip : Ship
    {
        public EnemyShip(GameField game, int coordX, int coordY, bool active, uint speed, uint counter=0, int oldCoordX=0, int oldCoordY=0)
        {
            _game = game;
            _coordX = coordX;
            _coordY = coordY;
            _oldCoordX = oldCoordX;
            _oldCoordY = oldCoordY;
            _active = true;
            _counter = 0;
            _speed = speed;
        }
        public override void Step()
        {
            _coordY += STEP;
        }
    }
}