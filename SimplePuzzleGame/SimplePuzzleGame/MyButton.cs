using System.Windows.Forms;

namespace SimplePuzzleGame
{
    internal class MyButton : Button
    {
        public int I { get; set; }
        public int J { get; set; }

        public MyButton(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}
