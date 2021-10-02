namespace BL
{
    internal class Field
    {
        #region Private Data

        private readonly int[,] _gameField;

        #endregion

        #region Constructor

        public Field(int size)
        {
            _gameField = new int[size, size];
        }

        #endregion

        #region Indexer

        public int this[Coord position]
        {
            get
            {
                return _gameField[position.X, position.Y];
            }
            set
            {
                _gameField[position.X, position.Y] = value;
            }
        }

        #endregion
    }
}
