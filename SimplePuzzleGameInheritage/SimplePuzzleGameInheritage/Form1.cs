using System;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private bool IsIndex(int index)
        {
            return (index >= 0) && (index < _buttons.GetLength(0));
        }

        private void Move(int index, int size)
        {

        }

        private void CheckAndMove(int i, int j)
        {
            if (IsIndex(j + 1) && (_buttons[i, j + 1] == null))
            {
                _buttons[i, j + 1] = _buttons[i, j];
                _buttons[i, j + 1].Location = new Point(_buttons[i, j].Location.X, _buttons[i, j].Location.Y + SIZE);
                _buttons[i, j + 1].J += 1;
                _buttons[i, j] = null;

                return;
            }

            if (IsIndex(j - 1) && (_buttons[i, j - 1] == null))
            {
                _buttons[i, j - 1] = _buttons[i, j];
                _buttons[i, j - 1].Location = new Point(_buttons[i, j].Location.X, _buttons[i, j].Location.Y - SIZE);
                _buttons[i, j - 1].J -= 1;
                _buttons[i, j] = null;

                return;
            }

            if (IsIndex(i + 1) && (_buttons[i + 1, j] == null))
            {
                _buttons[i + 1, j] = _buttons[i, j];
                _buttons[i + 1, j].Location = new Point(_buttons[i, j].Location.X + SIZE, _buttons[i, j].Location.Y);
                _buttons[i + 1, j].I++;
                _buttons[i, j] = null;

                return;
            }

            if (IsIndex(i - 1) && (_buttons[i - 1, j] == null))
            {
                _buttons[i - 1, j] = _buttons[i, j];
                _buttons[i - 1, j].Location = new Point(_buttons[i, j].Location.X - SIZE, _buttons[i, j].Location.Y);
                _buttons[i - 1, j].I--;
                _buttons[i, j] = null;

                return;
            }
        }
    }
}
