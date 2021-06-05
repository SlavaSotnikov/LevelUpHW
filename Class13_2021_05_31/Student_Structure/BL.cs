using System;
using System.Text;

namespace Student_Structure
{
    class BL
    {
        public static string GetRandomName()
        {
            string rndName = BLRnd.GetName(BLRnd.rnd.Next(0, 10));

            return rndName;
        }

        public static string GetRandomLastName()
        {
            string rndLastName = BLRnd.GetLastName(BLRnd.rnd.Next(0, 10));

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

        public static Student GetRandomStudent(Student person)
        {
            person = new Student()
            {
                name      = GetRandomName(),
                lastName  = GetRandomLastName(),
                studNum   = GetRandomStudNumber(),
                enterDate = GetRandomEnterDate()
            };

            return person;
        }

        public static int GetYear(Student person)
        {
            return (DateTime.Today.Year - person.enterDate.Year) + 1;
        }

        public static string GetShortName(Student person)
        {
            StringBuilder shortName = new StringBuilder(person.lastName + " ");
            shortName.Append(person.name[0] + ".");

            return shortName.ToString();
        }
    }
}
