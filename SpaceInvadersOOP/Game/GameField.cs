using System;

namespace Game
{
    class GameField : IGame
    {
        #region Private Data

        protected const int CONST_Y = 1;
        protected const int RESET = 0;

        protected int _leftBorder = 30;
        protected int _rightBorder = 83;
        protected int _topBorder = 0;
        protected int _bottomBorder = 33;

        protected int _initialX = 53;      // Initial X position of Spaceship.
        protected int _initialY = 28;      // Initial Y position of Spaceship.
        protected byte _lifes = 3;
        protected uint _shipSpeed = 1;
        protected bool _active = true;
        protected uint _counter = 0;
        protected byte _hitpoints = 10;
        protected byte _leftShift = 2;     // This shift tunes the Left bullet. 
        protected byte _rightShift = 6;    // This shift tunes the Right bullet.
        protected byte _shotEnemyShift = 3;

        protected SpaceCraft[] _gameObjects;
        protected int _amountOfObjects;

        #endregion

        #region IGame implementation

        ISpaceCraft IGame.this[int index]    // TODO: Ask a question about Quick Link, and namely Agregation to Whole, Agregation to Part. 
        {
            get
            {
                return _gameObjects[index];
            }
        }

        int IGame.Amount
        {
            get
            {
                return _amountOfObjects;
            }
        }

        #endregion

        #region Member Functions

        public bool IsGameOver()
        {
            bool gameOn = true;

            for (int i = 0; i < _amountOfObjects; i++)
            {
                if ((_gameObjects[i] is UserShip user) && !user.Active)
                {
                    gameOn = false;
                    break;
                }
            }

            return gameOn;
        }

        public void StepObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                ++_gameObjects[i].Counter;

                if ((_gameObjects[i].Counter % _gameObjects[i].Speed == 0)
                        && _gameObjects[i].Active)
                {
                    _gameObjects[i].Counter = RESET;

                    _gameObjects[i].Step();
                }
            }
        }

        public void Is()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                for (int j = 0; j < _amountOfObjects; j++)
                {
                    if (i != j)
                    {
                        if (_gameObjects[i] is UserShip user && _gameObjects[j] is EnemyShip enemy)
                        {
                            if (IsClash(user, enemy))
                            {
                                int x = user.X;
                                int y = user.Y;

                                user.Y += 2;
                                enemy.Y -= 2;

                                throw new ClashException("BOOM!!!", x, y);
                            }
                        }

                        if (_gameObjects[i] is Shot bullet && _gameObjects[j] is Ship ship)
                        {
                            if (bullet.Active && ship.Active)
                            {
                                if (IsHit(bullet, ship))
                                {
                                    bullet.Active = false;
                                    --ship.HitPoints;

                                    if (ship.HitPoints <= 0)
                                    {
                                        ship.Active = false;
                                        ship.Step();
                                    }
                                }
                            }
                        }

                        if (_gameObjects[i] is EnemyShip one)
                        {
                            if (one.Y == _bottomBorder)
                            {
                                one.Active = false;
                            }
                        }

                        if (_gameObjects[i] is Shot two)
                        {
                            if (two.Y == _topBorder || two.Y == _bottomBorder)
                            {
                                two.Active = false;
                            }
                        }
                    }
                }
            }
        }

        private bool IsClash(UserShip user, EnemyShip enemy)
        {
            return user.Y - 1 == enemy.Y && enemy.X >= user.X
                    && enemy.X + enemy.Width <= user.X + user.Width;
        }

        private bool IsHit(Shot bullet, Ship user)
        {
            return bullet.Y == user.Y && user.X < bullet.X
                    && bullet.X < user.X + user.Width;
        }

        #endregion

    }
}
