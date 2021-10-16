using System;
using System.Windows.Forms;

using SpaceInvadersDLL;

namespace SpaceInvadersWF
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Space game = new Space();
            //game.Run();    // TODO: do while().

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(game));
        }
    }
}
