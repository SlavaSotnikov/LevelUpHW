namespace BL
{
    internal class UserShip : Ship
    {
        internal UserShip(int ore, ObjectView view, params ShipModule[] module)
            : base(ore, view)
        {
        }
    }
}
