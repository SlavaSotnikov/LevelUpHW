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

        public Form1(Game source)
        {
            _game = source;
            _game.Run();

            InitializeComponent();

            InitializeDynamicComponents();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is MyButton pressed)
            {
                _game.Click(pressed.I, pressed.J);

                ShowButtons();

                lblMoves.Text = $"Number of movements: {_game.Move}";

                
            }

            if (_game.IsFinish())
            {
                lblMoves.Text = "Congrats! You win!";
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
           _game.Shuffle();
            _game.Move = 0;
            ShowButtons();
            lblMoves.Text = $"Number of movements: {_game.Move}";
        }

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
