using System;

namespace GeometricShapes
{
    struct Coordinate
    {
        private int _x;
        private int _y;
        private char _symbol;
        private ConsoleColor _color;
        private int _radius;
        private int _secondRadius;

        public int X
        {
            get 
            { 
                return _x; 
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get 
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public int Radius
        {
            get 
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public int SecondRadius
        {
            get 
            {
                return _secondRadius; 
            }
            set
            {
                _secondRadius = value;
            }
        }


        public char Symbol
        {
            get 
            { 
                return _symbol; 
            }
        }

        public ConsoleColor Color
        {
            get 
            { 
                return _color; 
            }
        }

        public Coordinate(int x, int y, int radius=0, int secondRadius=0, char symbol = '*',
                ConsoleColor color = ConsoleColor.White)
        {
            _x = x;
            _y = y;
            _radius = radius;
            _secondRadius = secondRadius;
            _symbol = symbol;
            _color = color;
        }
    }
}
