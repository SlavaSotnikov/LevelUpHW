using System;

namespace Game
{
    abstract class Ship : SpaceCraft
    {
        public abstract byte HP { get; set; }

        public abstract byte OldHP { get; set; }

        public abstract byte Width { get; set; }
    }
}