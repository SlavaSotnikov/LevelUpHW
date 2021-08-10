using System;

namespace Life
{
    class Empty : Cell
    {
        public override char View
        {
            get
            {
                return _image = '-';
            }
        }

        public override ConsoleColor Color
        {
            get
            {
                return _color = ConsoleColor.Black;
            }
        }

        public Empty(int x, int y)
        {
            _coord = new Coordinate(x, y);
        }

        public override Type GetType()
        {
            return Type.Empty;
        }
    }
}
