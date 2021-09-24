using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePuzzleGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                for (int i = 0; i < _buttons.GetLength(0); i++)
                {
                    for (int j = 0; j < _buttons.GetLength(1); j++)
                    {
                        if (_buttons[i, j] != null)
                        {
                            if (_buttons[i, j].TabIndex == button.TabIndex)
                            {
                                CheckAndMove(i, j);

                                i = _buttons.GetLength(0);
                                j = _buttons.GetLength(0);
                            } 
                        }
                    }
                }
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
                _buttons[i, j + 1] = _buttons[i, j];
                _buttons[i, j + 1].Location = new Point(_buttons[i, j].Location.X, _buttons[i, j].Location.Y + SIZE);
                _buttons[i, j] = null;

                return;
            }

            if (IsIndex(j - 1) && (_buttons[i, j - 1] == null))
            {
                _buttons[i, j - 1] = _buttons[i, j];
                _buttons[i, j - 1].Location = new Point(_buttons[i, j].Location.X, _buttons[i, j].Location.Y - SIZE);
                _buttons[i, j] = null;

                return;
            }

            if (IsIndex(i + 1) && (_buttons[i + 1, j] == null))
            {
                _buttons[i + 1, j] = _buttons[i, j];
                _buttons[i + 1, j].Location = new Point(_buttons[i, j].Location.X + SIZE, _buttons[i, j].Location.Y);
                _buttons[i, j] = null;

                return;
            }

            if (IsIndex(i - 1) && (_buttons[i - 1, j] == null))
            {
                _buttons[i - 1, j] = _buttons[i, j];
                _buttons[i - 1, j].Location = new Point(_buttons[i, j].Location.X - SIZE, _buttons[i, j].Location.Y);
                _buttons[i, j] = null;

                return;
            }
        }
    }
}
