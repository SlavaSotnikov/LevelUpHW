using System;

namespace Life
{
    class Obstacle : Empty
    {
        public override char View
        {
            get 
            {
                return _image = '#'; 
            }
        }

        public override ConsoleColor Color
        {
            get
            {
                return _color = ConsoleColor.Gray;
            }
        }

        public Obstacle(int x, int y, Ocean source)
            : base(x,y)
        {
            _game = source;
        }

        public override Type GetType()
        {
            return Type.Obstacle;
        }
    }
}
