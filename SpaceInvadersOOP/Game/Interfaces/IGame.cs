using System.Collections.Generic;

namespace Game
{
    interface IGame
    {
        ISpaceCraft this[int index] { get; }

        int Amount { get; }

        HashSet<Coord> Borders { get; }
    }
}
