using System;

namespace Life
{
    class Predator : Prey
    {
        public override char View
        {
            get 
            {
                return _image = 'S'; 
            }
        }

        public override ConsoleColor Color
        {
            get 
            {
                return _color = ConsoleColor.DarkBlue;
            }
        }

        public Predator(int x, int y, Ocean source)
            : base(x, y, source)
        {
        }
         
        public override void Move()
        {
            base.Move();
        }

        public override Type GetType()
        {
            return Type.Predator;
        }

    }
}
