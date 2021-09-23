using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePuzzleGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAndMove(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            CheckAndMove(3, 2);
        }

        private void CheckAndMove(int i, int j)
        {
            if (j + 1 <= _buttons.GetLength(0))
            {
                if (_buttons[i, j + 1] == null)
                {
                    _buttons[i, j + 1] = _buttons[i, j];
                    _buttons[i, j] = null;

                    _buttons[i, j + 1].Location = new Point(160 + Size, 235);
                    return;
                }
            }

            if (j - 1 <= _buttons.GetLength(0))
            {
                if (_buttons[i, j - 1] == null)
                {
                    _buttons[i, j - 1] = _buttons[i, j];
                    _buttons[i, j] = null;
                    return;
                }
            }

            if (i + 1 <= _buttons.GetLength(0))
            {
                if (_buttons[i + 1, j] == null)
                {
                    _buttons[i + 1, j] = _buttons[i, j];
                    _buttons[i, j] = null;
                    return;
                }
            }

            if (i - 1 <= _buttons.GetLength(1))
            {
                if (_buttons[i - 1, j] == null)
                {
                    _buttons[i - 1, j] = _buttons[i, j];
                    _buttons[i, j] = null;
                    return;
                }
            }
        }
    }
}
