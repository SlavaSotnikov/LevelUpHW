using System.Windows.Forms;

namespace SpaceInvadersDLL
{
    public interface IGame
    {
        ISpaceCraft this[int index] { get; }

        int Amount { get; }

        void PressKey(GameAction source);

        void Run();
    }
}
