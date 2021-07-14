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

        public void EditGroup(Group source, int index)
        {
            index -= 1; // Adjust index.
            if (index < 0 || index > _groups.Length)
            {
                return; // Enum error.
            }

            _groups[index] = new Group(source);
        }

        public void DeleteGroup(int index) //TODO: Delete by Id. Return Enum error.
        {
            index -= 1; //Adjust index.
            if (index < 0 || index > _groups.Length)
            {
                return; // Enum error.
            }

            for (int i = index; i < _countOfGroups - 1; i++) // TODO: Use Array.Copy() by index.
            {
                _groups[i] = _groups[i + 1];
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

        #region Utilits

        public GroupGPA[] GetGPA() // Grade Point Average.
        {
            GroupGPA[] departmentGPA = new GroupGPA[_countOfGroups];

            for (int i = 0; i < _countOfGroups; i++)
            {
                departmentGPA[i] = GetGroupGPA(_groups[i].GroupName,
                    _groups[i].GetGPA());
            }

            return departmentGPA;
        }

        public GroupGPA GetGroupGPA(string letter, double gpa)
        {
            return new GroupGPA(letter, gpa);
        }

        public Group GetGroupByPosition(int index)
        {
            return _groups[index];
        }

        #endregion
    }
}
