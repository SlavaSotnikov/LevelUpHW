//using System;

//namespace Game
//{
//    class God
//    {
//        private GameField _game;

//        private int _initialX = 53;      // Initial X position of Spaceship.
//        private int _initialY = 33;      // Initial Y position of Spaceship.
//        private byte _lifes = 3;
//        private byte _hitpoints = 100;
//        private byte _leftShift = 2;     // This shift tunes the Left bullet. 
//        private byte _rightShift = 6;    // This shift tunes the Right bullet.
//        private uint _shipSpeed = 1;
//        private bool _active = true;
//        private uint _counter = 0;

//        public God(GameField source)
//        {
//            _game = source;
//        }

//        public SpaceCraft Create(SpaceObject source)
//        {
//            SpaceCraft creature = null;

//            switch (source)
//            {
//                case SpaceObject.None:
//                    break;
//                case SpaceObject.Shot:
//                    //creature = new Shot();
//                    break;
//                case SpaceObject.LightShip:
//                    creature = new LightShip(_game, _initialX, _game.InitialY, _game.Active, _game.ShipSpeed, _game.Counter, _game.Hitpoints, _game.Lifes);
//                    break;
//                case SpaceObject.HeavyShip:
//                    break;
//                case SpaceObject.EnemyShip:
//                    break;
//                default:
//                    break;
//            }

//            return creature;
//        }
//    }
//}
