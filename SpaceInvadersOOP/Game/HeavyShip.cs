using System;

namespace Game
{
    class HeavyShip : LightShip
    {
        public new SpaceObject View => SpaceObject.HeavyShip;

        public HeavyShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes)
            : base(game, coordX, coordY, active, speed, counter, hitpoints, lifes, SpaceObject.HeavyShip)
        {
        }
    }
}
