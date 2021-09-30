using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Game
    {
        private static Random rnd = new Random();

        private int _size;
        private Field _map;
        private Coord _empty;

        public Game(int size)
        {
            _size = size;
            _map = new Field(size);
        }

        public void Run(int seed = 0)
        {
            int number = 0;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    _map.Set(new Coord(x, y), ++number);
                }
            }

            _empty = new Coord(_size - 1, _size - 1);
        }

        public void Click(int x, int y)
        {
            Click(new Coord(x, y));
        }

        private int Click(Coord source)
        {
            if (!_empty.Equals(source))
            {
                if (IsField(source.Y + 1) && _empty.Equals(new Coord(source.X, source.Y + 1)))
                {
                    Shift(new Coord(source.X, source.Y));
                }
                else if (IsField(source.Y - 1) && _empty.Equals(new Coord(source.X, source.Y - 1)))
                {
                    Shift(new Coord(source.X, source.Y));
                }
                else if (IsField(source.X + 1) && _empty.Equals(new Coord(source.X + 1, source.Y)))
                {
                    Shift(new Coord(source.X, source.Y));
                }
                else if (IsField(source.X - 1) && _empty.Equals(new Coord(source.X - 1, source.Y)))
                {
                    Shift(new Coord(source.X, source.Y));
                }
            }

            return 0;

        }

        private void Shift(Coord source)
        {
            int tempEmpt = _map.Get(_empty);
            int tempSour = _map.Get(source);
            Coord tempSource = source;
            Coord tempEmpty = _empty; 
            _map.Set(tempEmpty, tempSour);
            _map.Set(tempSource, tempEmpt);
            _empty = tempSource;
        }

        //private void Shift(/*int i, int j*/Coord source, int factorI, int factorJ, int sizeX, int sizeY)
        //{
        //    MyButton temp = _buttons[i + factorI, j + factorJ];

        //    _buttons[i + factorI, j + factorJ] = _buttons[i, j];
        //    _buttons[i, j] = temp;
        //    temp.Location = new Point(_buttons[i + factorI, j + factorJ].Location.X,
        //            _buttons[i + factorI, j + factorJ].Location.Y);
        //    _buttons[i + factorI, j + factorJ].Location = new Point(_buttons[i, j].Location.X + sizeX,
        //            _buttons[i, j].Location.Y + sizeY);
        //    _buttons[i + factorI, j + factorJ].J += factorJ;
        //    _buttons[i + factorI, j + factorJ].I += factorI;
        //}


        private bool IsField(int index)
        {
            return (index >= 0) && (index < _size);
        }


        public int GetNumber(int x, int y)
        {
            return _map.Get(new Coord(x, y));
        }

        public bool IsFinish()
        {
            return false;
        }
    }
}
