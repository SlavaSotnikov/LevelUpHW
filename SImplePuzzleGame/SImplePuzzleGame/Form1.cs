using System;
using System.Drawing;
using System.Windows.Forms;
using BL;

namespace SimplePuzzleGame
{
    public partial class Form1 : Form
    {
        private readonly IGame _game;

        private MyButton[,] _buttons;
        private const int FIELD_SIZE = 4;
        private const int SIZE = 75;
        private const int GAP = 10;
        private Button btnNewGame;
        private Label lblMoves;
        private bool _gameSatus = false;

        public Form1(IGame source)
        {
            _game = source;
            _game.InitializeBL();

            _game.FinishGame += Finish;

            InitializeComponent();

            InitializeDynamicComponents();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is MyButton pressed)
            {
                _game.ClickCell(pressed.I, pressed.J);

                ShowButtons();

                lblMoves.Text = $"Number of movements: {_game.StepsCount}";

                if (_gameSatus)
                {
                    MessageBox.Show("Congrats! You win!");
                    _gameSatus = false;
                }
            }
        }

        private void Finish(object sender, EventArgs e)
        {
            _gameSatus = true;
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
           _game.Shuffle();

            ShowButtons();

            lblMoves.Text = $"Number of movements: {_game.StepsCount}";
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

        private void btnNewGame_Click_1(object sender, EventArgs e)
        {

        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
