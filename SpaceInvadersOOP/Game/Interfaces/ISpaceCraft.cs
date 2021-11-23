using System.Collections.Generic;

namespace Game
{
    interface ISpaceCraft
    {
        //int X { get; }

        //int Y { get; }

        //int OldX { get; set; }

        //int OldY { get; set; }

        bool Active {  get; }

        HashSet<Coordinate> Position { get; }

        HashSet<Coordinate> OldPosition { get; }
    }
}
