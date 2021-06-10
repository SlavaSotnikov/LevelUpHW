using System;
using System.Text;

namespace Group_Of_Students
{
    class BL
    {
        public static Group CreateGroup(int capacity)
        {
            Group first = new Group();

            first.person = new Student[capacity];
            first.countOfStudents = 0;

            return first;
        }

        public static void AddStudent(ref Group group, Student person)
        {
            if (group.countOfStudents >= group.person.Length)
            {
                Array.Resize(ref group.person, group.person.Length + 1);
            }

            group.person[group.countOfStudents] = GetFullCopy(person);
            ++group.countOfStudents;
        }

        public static Student GetFullCopy(Student source)
        {
            Student destination = new Student()
            {
                name = source.name,
                lastName = source.lastName,
                studNum = source.studNum,
                enterDate = source.enterDate,
                marks = (byte[])source.marks.Clone()
            };

            return destination;
        }

        public static Department CreateDepartment(int capacity)
        {
            Department destination = new Department();

            destination.groups = new Group[capacity];
            destination.countOfGroups = 0;

            return destination;
        }

        public static void AddGroup(ref Department department, Group group)
        {
            if (department.countOfGroups >= department.groups.Length)
            {
                Array.Resize(ref department.groups, department.groups.Length + 1);
            }

            department.groups[department.countOfGroups] = GetFullCopy(group);
            ++department.countOfGroups;
        }

        public static Group GetFullCopy(Group source)
        {
            Group destination = new Group()
            {
                countOfStudents = source.countOfStudents,
                person = source.person
            };

            return destination;
        }

        public static void EditStudent(Group group, Student person, int index)
        {
            if (index >= group.countOfStudents || index < 0)
            {
                return; // TODO Enum error.
            }

            group.person[index] = person;
        }

        public static Student DeleteStudent(ref Group group, int index)
        {
            Student deletedStudent = group.person[index];

            index -= 1; // Adjust index
            if (index >= group.countOfStudents || index < 0)
            {
                return deletedStudent; // return Error;
            }

            for (int i = index; i < group.countOfStudents - 1; i++)
            {
                group.person[i] = group.person[i + 1];
            }

            // Just alter the countOfStudents
            const byte DELETED_STUDENT = 1;
            group.countOfStudents -= DELETED_STUDENT;

            return deletedStudent;
        }

        public static string GetRandomName()
        {
            string rndName = BLRnd.GetName(BLRnd.rnd.Next(0, 20));

            return rndName;
        }

        public static string GetRandomLastName()
        {
            string rndLastName = BLRnd.GetLastName(BLRnd.rnd.Next(0, 20));

            return rndLastName;
        }

        public static int GetRandomStudNumber()
        {
            int rndStudNum = BLRnd.rnd.Next(1024, 2049);

            return rndStudNum;
        }

        public static DateTime GetRandomEnterDate()
        {
            DateTime start = new DateTime(2016, 1, 9);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(BLRnd.rnd.Next(range));
        }

        public static void InitRandomMarks(byte[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = (byte)BLRnd.rnd.Next(2, 6);
            }
        }

        public static void InitRandomStudent(ref Student person)
        {
            person.name = GetRandomName();
            person.lastName = GetRandomLastName();
            person.studNum = GetRandomStudNumber();
            person.enterDate = GetRandomEnterDate();

            InitRandomMarks(person.marks);
        }

        public static int GetYear(Student person)
        {
            return DateTime.Today.Year - person.enterDate.Year + 1;
        }

        public static string GetShortName(Student person)
        {
            StringBuilder shortName = new StringBuilder(person.lastName + " ");
            shortName.Append(person.name[0] + ".");

            return shortName.ToString();
        }

        public static Group GoToNextLevel(Group source)
        {
            Group destination = new Group()
            {
                countOfStudents = source.countOfStudents,
                person = source.person
            };

            for (int i = 0; i < destination.countOfStudents; i++)
            {
                destination.person[i] = ZeroingCopy(destination.person[i]);
            }

            return destination;
        }

        public static Student ZeroingCopy(Student source)
        {
            Student destination = new Student()
            {
                name = source.name,
                lastName = source.lastName,
                studNum = source.studNum,
                enterDate = source.enterDate,
                marks = new byte[10]
            };

            return destination;
        }
    }
}
