namespace BL
{
    public interface IGame
    {
        void InitializeBL();

        void ClickCell(int x, int y);

        int GetNumber(int x, int y);

        void Shuffle();

        int StepsCount { get; }

        event ChangeGameStatus FinishGame;
    }
}