using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Arcade_Game
{
    internal class Map
    {
        private readonly Cell[,] _gameObjects;
        private readonly GameObject _userShip;
        private Coordinate _userPosition;
        private Coordinate _planet1Position;
        private Coordinate _planet2Position;

        public Map(int size)
        {
            _gameObjects = new Cell[size, size];
            _userShip = new UserShip(10);

            InitMap();
        }

        private void InitMap()
        {
            for (int i = 0; i < _gameObjects.GetLength(0); i++)
            {
                for (int j = 0; j < _gameObjects.GetLength(1); j++)
                {
                    _gameObjects[i, j] = new Cell();
                }
            }

            _userPosition = new Coordinate(0, 0);
            _planet1Position = new Coordinate(1, 1);
            _planet2Position = new Coordinate(2, 2);

            Set(_userPosition, new SpaceStation(100));
            Set(_planet1Position, new Planet1(10));
            Set(_planet2Position, new Planet2(10));
            Set(_userPosition, new UserShip(10));
        }

        public Cell GetCell(Coordinate point)
        {
            return _gameObjects[point.X, point.Y];
        }

        public bool Set(Coordinate point, GameObject source)
        {
            bool result = false;
            Cell cell = _gameObjects[point.X, point.Y];

            for (int i = 0; i < cell.Capacity; i++)
            {
                if (cell[i] is null)
                {
                    cell[i] = source;
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void MoveShip()
        {
            //switch (Controller.AskUI().ToLower())
            //{
            //    case "planet1":
            //        _
            //        break;
            //    default:
            //}
        }
    }
}
