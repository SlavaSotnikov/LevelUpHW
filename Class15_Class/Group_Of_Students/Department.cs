using System;

namespace Group_Of_Students
{
    class Department
    {
        #region Constants

        private const byte GROUPS_AMOUNT = 5;
        private const int DELETED_GROUP = 1;

        #endregion

        #region Private Data

        private Group[] _groups;
        private int _countOfGroups;

        #endregion

        #region Properties

        public int AmountOfGroups
        {
            get { return _countOfGroups; }
        }

        public OperationStatus LastOperationStatus { get; private set; }

        #endregion

        #region CRUD Operations

        public void AddGroup(Group source)
        {
            if (_countOfGroups >= _groups.Length)
            {
                Array.Resize(ref _groups, _groups.Length + (_groups.Length * 2));
            }

            _groups[_countOfGroups] = new Group(source);
            ++_countOfGroups;
        }

        public void EditGroupByName(Group source, string groupName)
        {
            if (!IsGroup(groupName))
            {
                LastOperationStatus = OperationStatus.Not_Found;

                return;
            }

            for (int i = 0; i < _countOfGroups; i++)
            {
                if (_groups[i].GroupName == groupName)
                {
                    _groups[i] = new Group(source);

                    LastOperationStatus = OperationStatus.Ok;
                }
            }
        }

        public void DeleteGroupByName(string groupName) 
        {
            if (!IsGroup(groupName))
            {
                LastOperationStatus = OperationStatus.Not_Found;

                return;
            }

            for (int i = 0; i < _countOfGroups - 1; i++) 
            {
                if (_groups[i].GroupName == groupName)
                {
                    Array.Copy(_groups, i + 1, _groups, i, _groups.Length - (i + 1));

                    LastOperationStatus = OperationStatus.Ok;
                }
            }

            _countOfGroups -= DELETED_GROUP;
        }

        #endregion

        #region Constructors

        public Department(int capacity = GROUPS_AMOUNT)
        {
            _groups = new Group[capacity];
            _countOfGroups = 0;
        }

        public Department(params Group[] groups)
        {
            _groups = new Group[groups.Length];
            _countOfGroups = groups.Length;

            for (int i = 0; i < _countOfGroups; i++)
            {
                _groups[i] = new Group(groups[i]);
            }
        }

        #endregion

        #region Member Functions

        public GroupGPA[] GetGPA() // Grade Point Average.
        {
            GroupGPA[] departmentGPA = new GroupGPA[_countOfGroups];

            for (int i = 0; i < _countOfGroups; i++)
            {
                departmentGPA[i] = new GroupGPA(_groups[i].GroupName,
                    _groups[i].GetGPA());
            }

            return departmentGPA;    // TODO: Should we return a copy of array?
        }

        public Group GetGroupByPosition(int index)
        {
            return _groups[index];
        }

        public bool IsGroup(string groupName)
        {
            bool result = false;

            for (int i = 0; i < _countOfGroups; i++)
            {
                if (_groups[i].GroupName == groupName)
                {
                    result = true;
                }
            }

            return result;
        }

        #endregion
    }
}
