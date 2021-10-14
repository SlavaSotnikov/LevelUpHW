using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersDLL
{
    public interface IGame
    {
        ISpaceCraft this[int index] { get; }

        int Amount { get; }
    }
}
