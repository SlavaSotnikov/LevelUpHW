using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersDLL
{
    public interface ISpaceCraft
    {
        int X { get; }

        int Y { get; }

        int OldX { get; set; }

        int OldY { get; set; }

        bool Active { get; }
    }
}
