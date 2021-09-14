namespace Game
{
    interface IGame
    {
        ISpaceCraft this[int index] { get; }

        int Amount { get; }
    }
}
