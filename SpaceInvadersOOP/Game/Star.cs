using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Star : SpaceCraft
    {
        internal Star(int x, int y, sbyte step, uint speed)
        :base(SpaceObject.Star)
        {
            //X = x;
            //Y = y;
            //_step = step;
            //Speed = speed;
            //OldX = 0;
            //OldY = 0;
            //Counter = 0;
            //Active = true;
        }

        public override void Step()
        {
            //Y += _step;
        }
    }
}
