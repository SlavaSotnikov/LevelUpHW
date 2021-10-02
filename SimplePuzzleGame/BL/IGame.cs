namespace BL
{
    public interface IGame
    {
        void Run();

        void Click(int x, int y);

        int GetNumber(int x, int y);

        bool IsFinish();

        void Shuffle();

        int StepsCount { get; }
    }
}