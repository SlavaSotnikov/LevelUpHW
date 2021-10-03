using BL;
using System;
using System.Windows.Forms;

namespace SimplePuzzleGame
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Game puzzle = new Game(4);    // TODO: Ask a question about type of object. Where should I create an object?

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(puzzle));
        }
    }
}
