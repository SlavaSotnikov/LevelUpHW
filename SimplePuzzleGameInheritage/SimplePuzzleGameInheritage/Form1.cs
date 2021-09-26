﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePuzzleGameInheritage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += 0.2;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is MyButton pressed)
            {
                CheckAndMove(pressed.I, pressed.J);
            }
        }

        private bool IsIndex(int index)
        {
            return (index >= 0) && (index < _buttons.GetLength(0));
        }

        private void CheckAndMove(int i, int j)
        {
            if (IsIndex(j + 1) && (_buttons[i, j + 1] == null))
            {
                Shift(i, j, 0, 1, 0, SIZE);
            }
            else if (IsIndex(j - 1) && (_buttons[i, j - 1] == null))
            {
                Shift(i, j, 0, -1, 0,-SIZE);
            }
            else if(IsIndex(i + 1) && (_buttons[i + 1, j] == null))
            {
                Shift(i, j, 1, 0, SIZE, 0);
            }
            else if(IsIndex(i - 1) && (_buttons[i - 1, j] == null))
            {
                Shift(i, j, -1, 0, -SIZE, 0);
            }

            return;
        }

        private void Shift(int i, int j, int factorI, int factorJ, int sizeX, int sizeY)
        {
            _buttons[i + factorI, j + factorJ] = _buttons[i, j];
            _buttons[i + factorI, j + factorJ].Location = new Point(_buttons[i, j].Location.X + sizeX,
                    _buttons[i, j].Location.Y + sizeY);
            _buttons[i + factorI, j + factorJ].J += factorJ;
            _buttons[i + factorI, j + factorJ].I += factorI;
            _buttons[i, j] = null;
        }
    }
}
