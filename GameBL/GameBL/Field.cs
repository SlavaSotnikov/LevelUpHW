using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBL
{
    internal struct Field
    {
        private int[,] _gameField;

        public Field(int size)
        {
            _gameField = new int[size, size];
        }

        public void Set(Coord position, int number)
        {
            _gameField[position.X, position.Y] = number;
        }

        public int Get(Coord position)
        {
            return _gameField[position.X, position.Y];
        }
    }
}
