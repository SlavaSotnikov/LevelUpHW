using System;

namespace Life
{
    class Prey : Cell
    {
        public override char View
        {
            get 
            {
                return _image = 'f';
            }
        }

        public override ConsoleColor Color
        {
            get 
            {
                return _color = ConsoleColor.DarkGreen;
            }
        }

        public Prey(int x, int y, Ocean source)
        {
            _coord = new Coordinate(x, y);
            _game = source;
        }

        public virtual void Move()
        {

        }

        public override Type GetType()
        {
            return Type.Prey;
        }
    }
}
