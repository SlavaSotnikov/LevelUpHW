using System.Windows.Forms;

namespace SimplePuzzleGame
{
    internal class MyButton : Button
    {
        public int InitI { get; private set ; }
        public int InitJ { get; private set; }

        public int I { get; set; }
        public int J { get; set; }

        public MyButton(int i, int j)
        {
            InitI = i;
            InitJ = j;
            I = i;
            J = j;
        }
    }
}
