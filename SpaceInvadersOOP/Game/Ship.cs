using System;

namespace Game
{
    internal abstract class Ship : SpaceCraft
    {
        public abstract byte HP { get; set; }

        public abstract byte OldHP { get; set; }

        //public abstract byte Width { get; set; }

        internal Ship(SpaceObject source)
        : base(source)
        {
        }
    }
}