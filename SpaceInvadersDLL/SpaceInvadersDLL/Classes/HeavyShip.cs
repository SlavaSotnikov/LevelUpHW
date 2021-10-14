namespace SpaceInvadersDLL
{
    internal class HeavyShip : LightShip
    {
        public HeavyShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes, int oldCoordX = 0, int oldCoordY = 0)
            : base(game, coordX, coordY, active, speed, counter, hitpoints, lifes, oldCoordX, oldCoordY)
        {
        }
    }
}
