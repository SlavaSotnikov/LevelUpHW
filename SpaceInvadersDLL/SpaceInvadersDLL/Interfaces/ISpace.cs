namespace SpaceInvadersDLL
{
    public interface ISpace
    {
        int TopBorder { get; }

        int BottomBorder { get; }

        int LeftBorder { get; }

        int RightBorder { get; }

        void AddObject(SpaceObject source);
    }
}
