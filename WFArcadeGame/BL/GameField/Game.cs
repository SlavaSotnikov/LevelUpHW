using System;
using System.Collections.Generic;

namespace BL
{
    public class Game : IGame
    {
        #region Constants

        private const int BASE = 0;
        private const int USER = 1;
        private const int PLANET1 = 2;
        private const int PLANET2 = 3;
        private const int BASE_Position = 20;
        private const int USERSHIP_Position = 19;
        private const int PLANET1_Position = 5;
        private const int PLANET2_Position = 35;

        #endregion

        #region Private Data

        private readonly Dictionary<Coordinate, LinkedList<GameObject>> _map;
        private ChangeGameStatus _finishGame;
        private readonly GameObject _userShip;
        private readonly List<Coordinate> _keys;
        
        private readonly int _size;

        #endregion

        #region Properties

        public int AmountOfObjects { get; private set; }

        public event ChangeGameStatus FinishedGame
        {
            add
            {
                _finishGame += value;
            }
            remove
            {
                _finishGame -= value;
            }
        }

        #endregion

        #region Constructor

        public Game(int size)
        {
            _map = new Dictionary<Coordinate, LinkedList<GameObject>>(size * size);
            _keys = new List<Coordinate>();

            _userShip = new UserShip(ore: 0, ObjectView.UserShip);
            _size = size;

            InitMap();
        }

        #endregion

        #region Member Functions

        /// <summary>
        /// The cycle of Business Logic.
        /// </summary>
        public void RunBL()
        {
            ObjectsInteraction();

            CheckGameStatus();
        }

        /// <summary>
        /// Checking the game is finished or not, according the describing. 
        /// </summary>
        private void CheckGameStatus()
        {
            bool gameStatus = false;

            if (gameStatus)
            {
                _finishGame?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Check the key, in case amount of objects equals 2,
        /// define objects and carry out an interaction.
        /// </summary>
        private void ObjectsInteraction()
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                if (_map[_keys[i]].Count >= 2)
                {
                    GameObject firstObject = _map[_keys[i]].First.Value;
                    GameObject secondObject = _map[_keys[i]].First.Next.Value;

                    if (firstObject is Planet && secondObject is UserShip)
                    {

                    }

                    if (firstObject is PirateShip && secondObject is UserShip)
                    {

                    }
                }
            }
        }

        /// <summary>
        /// Game field initial formation.
        /// </summary>
        private void InitMap()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _map.Add(new Coordinate(i, j), new LinkedList<GameObject>());
                }
            }

            SetInitialObjectsPosition();
        }

        /// <summary>
        /// Formation keys and set game objects on the map according these keys.
        /// </summary>
        private void SetInitialObjectsPosition()
        {
            _keys.Add(new Coordinate(BASE_Position, BASE_Position));
            _keys.Add(new Coordinate(USERSHIP_Position, BASE_Position));
            _keys.Add(new Coordinate(PLANET1_Position, PLANET1_Position));
            _keys.Add(new Coordinate(PLANET2_Position, PLANET2_Position));

            SetObject(_keys[BASE], new SpaceStation(ore: 1000, ObjectView.SpaceStation));
            SetObject(_keys[USER], _userShip);
            SetObject(_keys[PLANET1], new Planet(ore: 4000, ObjectView.Planet1));
            SetObject(_keys[PLANET2], new Planet(ore: 4000, ObjectView.Planet2));
        }

        /// <summary>
        /// Returns to UI the list of game objects according the key.
        /// </summary>
        /// <param name="key"> A key, and namely game field's coordinate. </param>
        /// <returns> A Linked List of game objects. </returns>
        public IEnumerable<GameObject> GetObjects(Coordinate key)
        {
            _map.TryGetValue(key, out LinkedList<GameObject> gameObjects);

            return gameObjects;
        }

        /// <summary>
        /// Returns to UI a list of keys. Use these keys UI can define and print game objects.
        /// </summary>
        /// <returns> A List of keys. </returns>
        public IEnumerable<Coordinate> GetKeys()
        {
            return _keys;
        }

        /// <summary>
        /// Set a game object on the map according the coordinate.
        /// </summary>
        /// <param name="key"> Game Field's coordinate. </param>
        /// <param name="source"> An object that will setted on Fame Field. </param>
        public void SetObject(Coordinate key, GameObject source)
        {
            LinkedList<GameObject> gameObject = _map[key];

            gameObject.AddLast(source);

            ++AmountOfObjects;
        }

        /// <summary>
        /// Set User Ship on Game Field according UI coordinate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveShip(int x, int y)
        {
            Coordinate newUserKey = new Coordinate(x, y);

            _map.TryGetValue(_keys[USER], out LinkedList<GameObject> gameObjects);

            gameObjects.RemoveLast();

            _map[newUserKey].AddLast(_userShip);

            _keys[USER] = newUserKey;
        }

        #endregion
    }
}
