namespace BL
{
    internal struct Coord
    {
        #region Properties

        public int X { get; set; }

        public int Y { get; set; }

        #endregion

        #region Constructor

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion
    }
}
