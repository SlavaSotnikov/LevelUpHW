namespace Group_Of_Students
{
    struct GroupGPA
    {
        private string _groupName;
        private float _gpa;

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

        public GroupGPA(string groupName, float gpa)
        {
            _groupName = groupName;
            _gpa = gpa;
        }
    }
}
