﻿using System;
using System.Drawing;
using System.Windows.Forms;

using SpaceInvadersDLL;

namespace SpaceInvadersWF
{
    public partial class Form1 : Form
    {
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
            _game.PressKey(e.KeyData);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            _game.PressKey(Keys.None);
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
                if (_game[i] is UserShip)    // TODO: All types of BL's classes are public.???
                {
                    _pictures[i].Location = new Point(_game[i].X, _game[i].Y);
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
                if (_game[i] is UserShip && _game[i].Active)
                {
                    InitPicture(i, Properties.Resources.UserShip, new Size(75, 82));
                }

                if (_game[i] is Shot && _game[i].Active)    // TODO: All types of BL's classes are public.???
                {
                    InitPicture(i, Properties.Resources.Bullet, new Size(15, 50));
                }

                Controls.Add(_pictures[i]);
            }
        }

        private void InitPicture(int i, Image picture, Size source)
        {
            if (_pictures[i] == null)
            {
                _pictures[i] = new PictureBox()
                {
                    Image = picture,
                    Location = new Point(_game[i].X, _game[i].Y),
                    Size = source,
                    SizeMode = PictureBoxSizeMode.Zoom,
                };
            }
        }
    }
}
