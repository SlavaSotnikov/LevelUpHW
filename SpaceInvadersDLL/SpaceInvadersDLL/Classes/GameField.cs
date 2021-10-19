using System;
using System.Windows.Forms;

namespace SpaceInvadersDLL
{
    public class GameField
    {
        #region Private Data

        protected const int CONST_Y = 1;

        protected int _leftBorder = 0;
        protected int _rightBorder = 684;
        protected int _topBorder = 0;
        protected int _bottomBorder = 561;

        protected int _initialX = 300;      // Initial X position of Spaceship.
        protected int _initialY = 469;      // Initial Y position of Spaceship.
        protected byte _lifes = 3;
        protected uint _shipSpeed = 1;
        protected bool _active = true;
        protected uint _counter = 0;
        protected byte _hitpoints = 10;
        protected byte _leftShift = 7;     // This shift tunes the Left bullet. 
        protected byte _rightShift = 52;    // This shift tunes the Right bullet.
        protected byte _shotEnemyShift = 3;

        protected Action Action { get; private set; }

        protected SpaceCraft[] _gameObjects;
        protected int _amountOfObjects;

        protected GameStatus _finishGame;

        #endregion

        #region IGame implementation

        public ISpaceCraft this[int index]
        {
            get
            {
                return _gameObjects[index];
            }
        }

        public int Amount
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
                if ((_gameObjects[i] is UserShip user) && user.Active)
                {
                    break;
                }

                _finishGame?.Invoke(this, EventArgs.Empty);
                gameOn = false;
                break;
            }

            return gameOn;
        }

        public void ProcessObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                _gameObjects[i].MoveState();

                if (_gameObjects[i].IsNeedStep())
                {
                    _gameObjects[i].Do(Action);
                    Action = Action.NoAction;
                }
            }
        }

        public void PressKey(Keys source)    // TODO: Enum Keys here. Is it ok?
        {
            Action = Action.NoAction;

            switch (source)
            {
                case Keys.Up:
                    Action = Action.UpMove;
                    break;
                case Keys.Down:
                    Action = Action.DownMove;
                    break;
                case Keys.Left:
                    Action = Action.LeftMove;
                    break;
                case Keys.Right:
                    Action = Action.RightMove;
                    break;
                case Keys.Space:
                    Action = Action.Shooting;
                    break;
                case Keys.Escape:
                    Action = Action.Exit;
                    break;
                default:
                    Action = Action.NoAction;
                    break;
            }
        }

        //private Action GetAction()
        //{
        //    return _action;
        //}

        public void CheckObjects()
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
                                    --ship.HP;

                                    if (ship.HP <= 0)
                                    {
                                        ship.Active = false;
                                        ship.Do(Action);
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
