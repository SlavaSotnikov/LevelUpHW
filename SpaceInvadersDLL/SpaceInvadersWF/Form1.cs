using System;
using System.Drawing;
using System.Windows.Forms;

using SpaceInvadersDLL;

namespace SpaceInvadersWF
{
    public partial class Form1 : Form
    {
        private IGame _game;
        private PictureBox[] _pictures;

        public Form1(IGame source)
        {
            InitializeComponent();

            _pictures = new PictureBox[13];

            _game = source;

            MainTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            GameAction userAction;    // TODO: Should we leave the enum?

            switch (e.KeyCode)
            {
                case Keys.Up:
                    userAction = GameAction.UpMove;
                    break;
                case Keys.Down:
                    userAction = GameAction.DownMove;
                    break;
                case Keys.Left:
                    userAction = GameAction.LeftMove;
                    break;
                case Keys.Right:
                    userAction = GameAction.RightMove;
                    break;
                case Keys.Space:
                    userAction = GameAction.Shooting;
                    break;
                case Keys.Escape:
                    userAction = GameAction.Exit;
                    break;
                default:
                    userAction = GameAction.NoAction;
                    break;
            }

            _game.PressKey(userAction);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            _game.PressKey(GameAction.NoAction);
        }

        private void RunGame(object sender, EventArgs e)    // TODO: Check the timer.
        {
            _game.Run();    // TODO: Move to Controller RunGame method. Timer for Console.

            InitPictures();

            ShowPictures();
        }

        private void ShowPictures()
        {
            Point one = new Point(0, 0);

            for (int i = 0; i < _game.Amount; i++)
            {
                if (!_game[i].Active)
                {
                    _pictures[i].Visible = false;
                }

                if (_game[i] is UserShip && _pictures[i].Visible)
                {
                    if (_game[i].X != _game[i].OldX || _game[i].Y != _game[i].OldY)
                    {
                        one.X = _game[i].X*2;
                        one.Y = _game[i].Y*2;

                        _pictures[i].Location = one;
                    }
                }

                if (_game[i] is Shot && _pictures[i].Visible)
                {
                    if (_game[i].X != _game[i].OldX || _game[i].Y != _game[i].OldY)
                    {
                        _pictures[i].Location = new Point(_game[i].X*2, _game[i].Y*2);
                    }
                } 
            }
        }

        private void InitPictures()
        {
            for (int i = 0; i < _game.Amount; i++)
            {
                if (_game[i] is UserShip && _pictures[i] == null)
                {
                    InitPicture(i, Properties.Resources.UserShip, new Size(75, 82));
                }

                if (_game[i] is Shot two && two.Active)
                {
                    InitPicture(i, Properties.Resources.Bullet, new Size(15, 50));
                }

                if (_game[i] is EnemyShip three && three.Active)
                {
                }
            }
        }

        private void InitPicture(int i, Image picture, Size source)
        {
            if (_pictures[i] == null)
            {
                AddPictureBox(i, picture, source);
            }

            if (!_pictures[i].Visible)
            {
                AddPictureBox(i, picture, source);
            }
        }

        private void AddPictureBox(int i, Image picture, Size source)
        {
            _pictures[i] = new PictureBox()
            {
                Image = picture,
                Location = new Point(_game[i].X * 2, _game[i].Y * 2),
                Size = source,
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = true
            };

            Controls.Add(_pictures[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
