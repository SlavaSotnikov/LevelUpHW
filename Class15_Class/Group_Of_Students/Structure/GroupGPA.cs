namespace Group_Of_Students
{
    struct GroupGPA
    {
        #region Private Data

        private string _groupName;
        private float _gpa;

        #endregion

        #region Properties

        public string GroupName
        {
            get
            {
                return _groupName;
            }
        }

        public float GPA
        {
            get
            {
                return _gpa;
            }
        }

        #endregion

        #region Constructor

        public GroupGPA(string groupName, float gpa)
        {
            _groupName = groupName;
            _gpa = gpa;
        }

        #endregion
    }
}
