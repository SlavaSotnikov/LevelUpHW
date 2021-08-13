using System;

namespace Game
{
    abstract class Ship : SpaceCraft
    {
        protected byte _hitPoints;

        public abstract byte HitPoints { get; set; }
    }
}