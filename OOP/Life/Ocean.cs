using System;

namespace Life
{
    class Ocean
    {
        public const byte DEFAULT_ROWS = 25;
        public const byte DEFAULT_COLUMNS = 70;
        public const byte DEFAULT_PREY = 150;
        public const byte DEFAULT_PREDATORS = 20;
        public const byte DEFAULT_OBSTACLES = 75;

        private Cell[,] _cells;

        private int _rows;
        private int _columns;
        private int _prey;
        private int _predators;
        private int _obstacles;

        public Ocean(int rows, int columns, int prey, int predators, int obstacles)
        {
            _rows = rows;
            _columns = columns;

            if (IsAppropriateValue(prey))
            {
                _prey = prey; 
            }

            if (IsAppropriateValue(predators))
            {
                _predators = predators; 
            }

            if (IsAppropriateValue(obstacles))
            {
                _obstacles = obstacles; 
            }

            _cells = new Cell[_rows, _columns];

            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i, j] = new Empty(i, j);
                }
            }
        }

        public int Rows
        {
            get 
            {
                return _rows;
            }
            set 
            {
                _rows = value; 
            }
        }

        public int Columns
        {
            get 
            {
                return _columns;
            }
            set 
            {
                _columns = value; 
            }
        }

        public int Prey
        {
            get 
            {
                return _prey; 
            }
            set 
            {
                if (IsAppropriateValue(value))
                {
                    _prey = value; 
                } 
            }
        }

        public int Predators
        {
            get
            {
                return _predators;
            }
            set 
            {
                if (IsAppropriateValue(value))
                {
                    _predators = value; 
                }
            }
        }

        public int Obstacles
        {
            get 
            {
                return _obstacles; 
            }
            set 
            {
                if (IsAppropriateValue(value))
                {
                    _obstacles = value; 
                } 
            }
        }

        public void FillInOcean()
        {
            Add(Type.Prey, _prey);
            Add(Type.Predator, _predators);
            Add(Type.Obstacle, _obstacles);
        }

        private void Add(Type sourceType, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                bool isExist = false;

                do
                {
                    int x = BL_Random.GetRnd(_rows);
                    int y = BL_Random.GetRnd(_columns);

                    if (_cells[x, y].GetType() == Type.Empty)
                    {
                        switch (sourceType)
                        {
                            case Type.Prey:
                                _cells[x, y] = new Prey(x, y, this);
                                break;
                            case Type.Predator:
                                _cells[x, y] = new Predator(x, y, this);
                                break;
                            case Type.Obstacle:
                                _cells[x, y] = new Obstacle(x, y, this);
                                break;
                            default:
                                break;
                        }

                        isExist = true;
                    }

                } while (!isExist);
            }
        }

        private bool IsAppropriateValue(int source)
        {
            bool result = true;

            if (source > DEFAULT_ROWS * DEFAULT_COLUMNS)
            {
                result = false;
            }

            return result;
        }
    }
}
