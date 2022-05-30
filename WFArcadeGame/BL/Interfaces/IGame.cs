using System.Collections.Generic;

namespace BL
{
    public interface IGame
    {
        void MoveShip(int x, int y);

        void RunBL();

        IEnumerable<Coordinate> GetKeys();

        IEnumerable<GameObject> GetObjects(Coordinate key);

        int AmountOfObjects { get; }

        event ChangeGameStatus FinishedGame;
    }
}
