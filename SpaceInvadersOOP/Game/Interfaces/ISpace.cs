using System;
using System.Collections.Generic;

namespace Game
{
    interface ISpace
    {
        //int TopBorder { get; }

        //int BottomBorder { get; }

        //int LeftBorder { get; }

        //int RightBorder { get; }

        void AddObject(SpaceObject source);

        HashSet<Coord> Borders { get; }
    }
}
