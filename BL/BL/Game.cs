using System;

namespace BL
{
    internal class Game
    {
        private static Random rnd = new Random();

        private int _size;
        private Field _map;
        private Coord _space;

        public int Moves { get; private set; }

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

            _space = new Coord(_size - 1, _size - 1);
        }

        public bool Click(int x, int y)
        {
            return false;
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
