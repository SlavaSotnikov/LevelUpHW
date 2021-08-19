namespace GeometricShapes
{
    abstract class Figure
    {
        #region Private Data

        protected Coordinate _point;
        protected string _name;
        #endregion

        #region Properties

        public abstract string Name 
        {
            get;
        }

        public int CoordinateX
        {
            get
            {
                return _point.X;
            }
            set
            {
                _point.X = value;
            }
        }

        public int CoordinateY
        {
            get
            {
                return _point.Y;
            }
            set
            {
                _point.Y = value;
            }
        }

        #endregion

        public abstract void Move(int deltaX, int deltaY);

        public abstract void Resize(double mult);

        public abstract Coordinate[] GetPoints(); 
    }
}
