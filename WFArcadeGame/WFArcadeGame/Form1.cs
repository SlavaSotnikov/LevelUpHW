using System;
using BL;
using System.Drawing;
using System.Windows.Forms;
using WFArcadeGame.Properties;

namespace WFArcadeGame
{
    public partial class Form1 : Form
    {
        #region Private Data

        private readonly IGame _game;
        private PictureBox[] _images;

        #endregion

        #region Constants

        private const int IMAGE_SIZE = 20;
        private const int HALFIMAGE_SIZE = 10;
        private const int BASE = 0;
        private const int USER = 1;
        private const int PLANET1 = 2;
        private const int PLANET2 = 3;


        #endregion

        #region Constructor

        public Form1(IGame source)
        {
            _game = source;

            _game.FinishedGame += Finish;

            InitializeComponent();

            InitializeDynamicComponents();

            ShowObjects();

            GameMainTimer.Start();
        }

        #endregion

        #region Member Functions

        /// <summary>
        /// This method is the main cycle. It refereces on GameMainTimer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunGame(object sender, EventArgs e)
        {
            _game.RunBL();
        }

        /// <summary>
        /// Provides coordinates from UI. After user has clicked a mouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            ConvertPositionForBL(ref x, ref y);

            _game.MoveShip(x, y);

            ShowObjects();
        }

        /// <summary>
        /// Preparing coordinates from UI before sending to Business Logic. 
        /// We have to correct coordinates from UI, because one cell on Game Field is
        /// height 20 pixels and width 20 pixels.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ConvertPositionForBL(ref int x, ref int y)
        {
            x /= IMAGE_SIZE;
            y /= IMAGE_SIZE;
        }

        /// <summary>
        /// Informs the user of victory or defeat.
        /// UI is a subscribed to Business Logic in order to informing user about a game status.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finish(object sender, EventArgs e)
        {
            MessageBox.Show("Congrats! You've won or lost!");
        }

        /// <summary>
        /// Obtains game objects from Business Logic in order to print them out.
        /// </summary>
        private void ShowObjects()
        {
            foreach (var key in _game.GetKeys())
            {
                foreach (var item in _game.GetObjects(key))
                {
                    Print(key.X * IMAGE_SIZE, key.Y * IMAGE_SIZE, item);
                }
            }
        }

        /// <summary>
        /// Obtains game objects, interface IView provides a property,
        /// UI can identify the type of object.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="source"></param>
        private void Print(int x, int y, IView source)
        {
            Point newPoint = new Point(0, 0)
            {
                X = x,
                Y = y
            };

            switch (source.View)
            {
                case ObjectView.SpaceStation:
                    MovePictureBox(BASE, newPoint, Resources.Base);
                    break;
                case ObjectView.UserShip:
                    MovePictureBox(USER, newPoint, Resources.UserShip);
                    break;
                case ObjectView.Planet1:
                    MovePictureBox(PLANET1, newPoint, Resources.Planet1);
                    break;
                case ObjectView.Planet2:
                    MovePictureBox(PLANET2, newPoint, Resources.Planet2);
                    break;
                case ObjectView.Asteroid:
                    break;
                case ObjectView.PirateShip:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Set Picture Box on specific Game Field position.
        /// Assings an image according a type of object.
        /// </summary>
        /// <param name="itemPosition"></param>
        /// <param name="newPoint"></param>
        /// <param name="picture"></param>
        private void MovePictureBox(int itemPosition, Point newPoint, Image picture)
        {
            _images[itemPosition].Location = newPoint;
            _images[itemPosition].Image = picture;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        #endregion
    }
}
