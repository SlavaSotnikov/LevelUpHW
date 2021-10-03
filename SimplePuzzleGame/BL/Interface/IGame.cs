namespace BL
{
    public interface IGame
    {
        void Run();

        void Click(int x, int y);

        int GetNumber(int x, int y);

        void Shuffle();

        void IsFinish();

        int StepsCount { get; }

        event Finish FinishGame;
    }
}