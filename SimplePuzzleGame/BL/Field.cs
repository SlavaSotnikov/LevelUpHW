namespace BL
{
    internal class Field
    {
        private readonly int[,] _gameField;

        public Field(int size)
        {
            _gameField = new int[size, size];
        }

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
    }
}
