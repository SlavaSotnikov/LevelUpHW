using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameField : Space
    {
        public void DeleteObjects()
        {
            for (int i = _gameObjects.Length - 1; i >= 0; i--)
            {
                if (_gameObjects[i] != null)
                {
                    if (!_gameObjects[i].Active)
                    {
                        Array.Copy(_gameObjects, i + 1, _gameObjects,
                                i, _amountOfObjects - i);
                        --_amountOfObjects;
                    }
                }
            }
        }
    }
}
