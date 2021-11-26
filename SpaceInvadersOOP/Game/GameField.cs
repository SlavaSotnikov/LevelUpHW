using System;
using System.Collections.Generic;

namespace Game
{
    class GameField : IGame
    {
        #region Private Data

        protected const int CONST_Y = 1;

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

        //protected SpaceCraft[] _gameObjects;
        protected List<SpaceCraft> _gameObjects;
        protected int _amountOfObjects;

        protected GameStatus _finishGame;
        public HashSet<Coordinate> _borders;

        public HashSet<Coordinate> Borders => _borders;

        protected void InitBorders()
        {
            _borders = new HashSet<Coordinate>(180/*new CoordinateEqualityComparer()*/);

            int y = _topBorder;
            int x = _leftBorder;

            for (; x <= _rightBorder; x++)
            {
                _borders.Add(new Coordinate(x, y));
            }

            y = _bottomBorder + 4;
            x = _leftBorder;

            for (; x <= _rightBorder; x++)
            {
                _borders.Add(new Coordinate(x, y));
            }
            
            y = _topBorder + 1;
            x = _leftBorder;

            for (; y < _bottomBorder + 4; y++)
            {
                _borders.Add(new Coordinate(x, y));
            }
            
            y = _topBorder + 1;
            x = _rightBorder;

            for (; y < _bottomBorder + 4; y++)
            {
                _borders.Add(new Coordinate(x, y));
            }
        }

        #endregion

        #region IGame implementation

        ISpaceCraft IGame.this[int index]
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
                    _finishGame?.Invoke(this, EventArgs.Empty);
                    break;
                }
            }

            return gameOn;
        }

        public void StepObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                _gameObjects[i].MoveState();

                if (_gameObjects[i].IsNeedStep())
                {
                    _gameObjects[i].Step();
                }
            }
        }

        public void CheckObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                for (int j = 0; j < _amountOfObjects; j++)
                {
                    if (i != j)
                    {
                        //if (_gameObjects[i] is Star star && star.Y == _bottomBorder + 4)
                        //{
                        //    star.X = BL_Random.GetX();
                        //    star.Y = BL_Random.GetY();
                        //    star.Active = true;
                        //    continue;
                        //}

                        //if (_gameObjects[i] is UserShip user && _gameObjects[j] is EnemyShip enemy)
                        //{
                        //    if (IsClash(user, enemy))
                        //    {
                        //        int x = user.X;
                        //        int y = user.Y;

                        //        user.Y += 2;
                        //        enemy.Y -= 2;

                        //        throw new ClashException("BOOM!!!", x, y);
                        //    }
                        //}

                        if (_gameObjects[i] is UserShip usr
                                && _gameObjects[j] is Star str)
                        {
                            //if (IsNear(usr, str))
                            //{
                            //    //str.Y += 5;
                            //}
                        }

                        if (_gameObjects[i] is EnemyShip usr1
                                && _gameObjects[j] is Star str1)
                        {
                            //if (IsNear(usr1, str1))
                            //{
                            //    //str1.Y += 3;
                            //}
                        }

                        if (_gameObjects[i] is Shot bullet && _gameObjects[j] is Ship ship)
                        {
                            if (bullet.Active && ship.Active)
                            {
                                if (ship.Position.Overlaps(bullet.Position))
                                {
                                    bullet.Active = false;
                                    --ship.HP;

                                    if (ship.HP <= 0)
                                    {
                                        ship.Active = false;
                                        //ship.Step();
                                        continue;
                                    }
                                }

                                //if (IsHit(bullet, ship))
                                //{
                                //    bullet.Active = false;
                                //    --ship.HP;

                                //    if (ship.HP <= 0)
                                //    {
                                //        ship.Active = false;
                                //        ship.Step();
                                //        continue;
                                //    }
                                //}
                            }
                        }

                        if (_gameObjects[i] is EnemyShip one)
                        {
                            if (one.Position.Overlaps(Borders))
                            {
                                one.Active = false;
                                continue;
                            }

                            //if (one.Y == _bottomBorder)
                            //{
                            //    one.Active = false;
                            //    continue;
                            //}
                        }

                        if (_gameObjects[i] is Shot two)
                        {
                            if (two.Position.Overlaps(Borders))
                            {
                                two.Active = false;
                                continue;
                            }

                            //if (two.Y == _topBorder || two.Y == _bottomBorder)
                            //{
                            //    two.Active = false;
                            //    continue;
                            //}
                        }
                    }
                }
            }
        }

        //private bool IsNear(Ship user, Star star)
        //{
        //    return user.Y == star.Y && star.X >= user.X
        //            && star.X <= user.X + user.Width;
        //}

        //private bool IsClash(UserShip user, EnemyShip enemy)
        //{
        //    return user.Y - 1 == enemy.Y && enemy.X >= user.X
        //            && enemy.X + enemy.Width <= user.X + user.Width;
        //}

        //private bool IsHit(Shot bullet, Ship user)
        //{
        //    return bullet.Y == user.Y && user.X < bullet.X
        //            && bullet.X < user.X + user.Width;
        //}

        #endregion
    }
}
