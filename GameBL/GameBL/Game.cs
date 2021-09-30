using System;

namespace GameBL
{
    internal class Game
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

        public int Click(int x, int y)
        {
            return 0;
        }

        public int GetNumber(int x, int y)
        {
            return 0;
        }

        public bool IsFinish()
        {
            return false;
        }
    }
}
