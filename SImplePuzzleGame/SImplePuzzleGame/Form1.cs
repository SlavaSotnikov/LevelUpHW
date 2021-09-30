using System;
using System.Drawing;
using System.Windows.Forms;
using BL;

namespace SimplePuzzleGame
{
    public partial class Form1 : Form
    {
        private Game _game;
        private const int FIELD_SIZE = 4;

        private static Random _rnd = new Random();

        private MyButton[,] _buttons;
        private const int SIZE = 75;
        private const int GAP = 10;

        public Form1()
        {
            InitializeComponent();

            _game = new Game(FIELD_SIZE);
            _game.Run();

            InitializeDynamicComponents();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is MyButton pressed)
            {
                _game.Click(pressed.I, pressed.J);

                ShowButtons();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            
            ShowButtons();
        }

        //private bool IsFinish()
        //{
        //    bool result = true;

        //    for (int i = 0; i < _buttons.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < _buttons.GetLength(1); j++)
        //        {
        //            if ((_buttons[i, j].I != _buttons[i, j].InitI)
        //                    && (_buttons[i, j].J != _buttons[i, j].InitJ))
        //            {
        //                result = false;

        //                i = _buttons.GetLength(0);
        //                j = _buttons.GetLength(1);
        //            }
        //        }
        //    }

        //    return result;
        //}

        //private bool IsIndex(int index)
        //{
        //    return (index >= 0) && (index < _buttons.GetLength(0));
        //}

        //private void Swap(int i, int j)
        //{
        //    if (IsIndex(j + 1) && (_buttons[i, j + 1].TabIndex == 16))
        //    {
        //        Shift(i, j, 0, 1, 0, SIZE);
        //    }
        //    else if (IsIndex(j - 1) && (_buttons[i, j - 1].TabIndex == 16))
        //    {
        //        Shift(i, j, 0, -1, 0, -SIZE);
        //    }
        //    else if (IsIndex(i + 1) && (_buttons[i + 1, j].TabIndex == 16))
        //    {
        //        Shift(i, j, 1, 0, SIZE, 0);
        //    }
        //    else if (IsIndex(i - 1) && (_buttons[i - 1, j].TabIndex == 16))
        //    {
        //        Shift(i, j, -1, 0, -SIZE, 0);
        //    }

        //    return;
        //}

        //private void Shift(int i, int j, int factorI, int factorJ, int sizeX, int sizeY)
        //{
        //    MyButton temp = _buttons[i + factorI, j + factorJ];

        //    _buttons[i + factorI, j + factorJ] = _buttons[i, j];
        //    _buttons[i, j] = temp;
        //    temp.Location = new Point(_buttons[i + factorI, j + factorJ].Location.X ,
        //            _buttons[i + factorI, j + factorJ].Location.Y);
        //    _buttons[i + factorI, j + factorJ].Location = new Point(_buttons[i, j].Location.X + sizeX, 
        //            _buttons[i, j].Location.Y + sizeY);
        //    _buttons[i + factorI, j + factorJ].J += factorJ;
        //    _buttons[i + factorI, j + factorJ].I += factorI;
        //}

        //private void Shuffle()
        //{
        //    int amountOfSwaps = 0;

        //    while (amountOfSwaps < _buttons.Length / 2)
        //    {
        //        int i = _rnd.Next(4);
        //        int j = _rnd.Next(4);

        //        int k = _rnd.Next(4);
        //        int l = _rnd.Next(4);

        //        if ((i != k) || (j != l))
        //        {
        //            if (IsInitial(i, j) && IsInitial(k, l))
        //            {
        //                MyButton temp = _buttons[i, j];

        //                _buttons[i, j] = _buttons[k, l];
        //                _buttons[i, j].Location = new Point(_buttons[k, l].Location.X, _buttons[k, l].Location.Y);
        //                _buttons[k, l] = temp;
        //                _buttons[k, l].Location = new Point(temp.Location.X, temp.Location.Y);

        //                ++amountOfSwaps;
        //            } 
        //        }
        //    }
        //}

        //private bool IsInitial(int i, int j)
        //{
        //    return (_buttons[i, j].I == _buttons[i, j].InitI) && (_buttons[i, j].J == _buttons[i, j].InitJ);
        //}

        private void ShowButtons()
        {
            for (int x = 0; x < FIELD_SIZE; x++)
            {
                for (int y = 0; y < FIELD_SIZE; y++)
                {
                    ShowText(_game.GetNumber(x, y), x, y);
                }
            }
        }

        private void ShowText(int source, int x, int y)
        {
            _buttons[x, y].Text = source.ToString();
            _buttons[x, y].BackColor = Color.PeachPuff;

            InitializeEmpty(y, x);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
