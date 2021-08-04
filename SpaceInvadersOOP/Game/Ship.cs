using System;

namespace Game
{
    abstract class Ship : SpaceCraft
    {
        private Cartridge _cartridge;
        protected byte _hitPoints;
    }
}