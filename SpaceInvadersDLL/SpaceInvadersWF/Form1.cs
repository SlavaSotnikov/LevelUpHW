using System.Windows.Forms;

using SpaceInvadersDLL;

namespace SpaceInvadersWF
{
    public partial class Form1 : Form
    {
        event UIListener UserEvent;
        IGame _game;

        public Form1(IGame source)
        {
            InitializeComponent();
            _game = source;
            //source.
            //UserEvent += KeyIsDown;
        }

        private void PressKeys()
        {

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Equals(Keys.Up))
            {
                // TODO: Is Event here?
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {

        }
    }
}
