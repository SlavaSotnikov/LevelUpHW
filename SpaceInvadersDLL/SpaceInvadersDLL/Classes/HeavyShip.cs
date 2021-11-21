namespace SpaceInvadersDLL
{
    public class HeavyShip : LightShip
    {
        internal HeavyShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes)
            : base(game, coordX, coordY, active, speed, counter, hitpoints, lifes)
        {
        }
    }
}
