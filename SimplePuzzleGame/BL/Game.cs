using System;

namespace BL
{
    public class Game
    {
        private static Random rnd = new Random();

        private int _size;
        private Field _map;
        private Coord _empty;

        public int Move { get; set; }

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

            Shuffle();

            Move = 0;
        }

        public void Click(int x, int y)
        {
            Swap(new Coord(x, y));
        }

        public int GetNumber(int x, int y)
        {
            return _map.Get(new Coord(x, y));
        }

        public bool IsFinish()
        {
            int num = 0;
            bool result = true;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    int res = _map.Get(new Coord(x, y));

                    if ((res) != ++num)
                    {
                        result = false;
                        y = _size;
                        x = _size;
                    }
                }
            }

            return result;
        }

        private void Swap(Coord source)
        {
            if (!_empty.Equals(source))
            {
                if (IsField(source.Y + 1) && _empty.Equals(new Coord(source.X, source.Y + 1)))
                {
                    Shift(new Coord(source.X, source.Y));
                    ++Move;
                }
                else if (IsField(source.Y - 1) && _empty.Equals(new Coord(source.X, source.Y - 1)))
                {
                    Shift(new Coord(source.X, source.Y));
                    ++Move;
                }
                else if (IsField(source.X + 1) && _empty.Equals(new Coord(source.X + 1, source.Y)))
                {
                    Shift(new Coord(source.X, source.Y));
                    ++Move;
                }
                else if (IsField(source.X - 1) && _empty.Equals(new Coord(source.X - 1, source.Y)))
                {
                    Shift(new Coord(source.X, source.Y));
                    ++Move;
                }
            }
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

        private bool IsField(int index)
        {
            return (index >= 0) && (index < _size);
        }

        public void Shuffle()
        {
            for (int i = 0; i < 20; i++)
            {
                Click(rnd.Next(_size), rnd.Next(_size));
            }
        }
    }
}
