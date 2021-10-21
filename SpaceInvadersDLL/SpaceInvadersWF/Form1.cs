using System;
using System.Drawing;
using System.Windows.Forms;

using SpaceInvadersDLL;

namespace SpaceInvadersWF
{
    public partial class Form1 : Form
    {
        private const byte FACTOR = 1;
        private IGame _game;

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
            GameAction userAction;

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

        private void RunGame(object sender, EventArgs e)
        {
            _game.Run();

            InitPictures();

            ShowPictures();
        }

        private void ShowPictures()
        {
            for (int i = 0; i < _game.Amount; i++)
            {
                if (!_game[i].Active)
                {
                    _pictures[i].Visible = false;
                }

                if (_game[i] is UserShip)    // TODO: All types of BL's classes are public.???
                {
                    if (_game[i].X != _game[i].OldX || _game[i].Y != _game[i].OldY)
                    {
                        _pictures[i].Location = new Point(_game[i].X, _game[i].Y); 
                    }
                }

                if (_game[i] is Shot)
                {
                    _pictures[i].Location = new Point(_game[i].X, _game[i].Y);
                }
            }
        }

        private void InitPictures()
        {
            for (int i = 0; i < _game.Amount; i++)
            {
                if (_game[i] is UserShip)
                {
                    InitPicture(i, Properties.Resources.UserShip, new Size(75, 82));
                }

                if (_game[i] is Shot)    // TODO: All types of BL's classes are public.???
                {
                    InitPicture(i, Properties.Resources.Bullet, new Size(15, 50));
                }

                if (_game[i] is EnemyShip)    // TODO: All types of BL's classes are public.???
                {
                }
            }
        }

        private void InitPicture(int i, Image picture, Size source)
        {
            if ((_pictures[i] == null) || (!_pictures[i].Visible))
            {
                _pictures[i] = new PictureBox()    // TODO: Make factors.
                {
                    Image = picture,
                    Location = new Point(_game[i].X, _game[i].Y),
                    Size = source,
                    SizeMode = PictureBoxSizeMode.Zoom,
                };

                Controls.Add(_pictures[i]);
            }
        }
    }
}
