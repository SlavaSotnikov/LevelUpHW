namespace Game
{
    interface IUi
    {
        SpaceCraft this[int index] { get; }

        int Amount { get; }
    }
}
