using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Arcade_Game
{
    internal struct Cell
    {
        private GameObject[] _gameObjects;
        private int _amountOfObjects;

        public int Count { get => _amountOfObjects; }
        public int Capacity { get => _gameObjects.Length; }

        public GameObject this[int index]
        {
            get => _gameObjects[index];
            set 
            { 
                _gameObjects[index] = value;
                ++_amountOfObjects;
            }
        }

        public Cell(int capacity = 2)
        {
            _gameObjects = new GameObject[capacity];
            _amountOfObjects = 0;
        }
    }
}
