using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class GameField
    {
        private SpaceCraft[] _gameObjects;

        public bool IsgameOver()
        {
            return false;
        }

        public void Run()
        {
            do
            {
                for (int i = 0; i < _gameObjects.Length; i++)
                {
                    if (_gameObjects[i] != null)
                    {
                        _gameObjects[i].Step();
                    }
                }
            } while (!IsgameOver());
            
        }
    }
}