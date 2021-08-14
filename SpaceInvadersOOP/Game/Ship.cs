using System;

namespace Game
{
    abstract class Ship : SpaceCraft
    {
        protected byte _hitPoints;
        protected byte _oldHitPoints;

        public abstract byte HitPoints { get; set; }
        public abstract byte OldHitPoints { get; set; }
    }
}