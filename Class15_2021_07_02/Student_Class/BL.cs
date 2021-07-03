using System;
using System.Text;

namespace Student_Class
{
    class BL
    {
        public static string GetRandomName()
        {
            string rndName = BL_Random.GetName(BL_Random.rnd.Next(0, 10));

            return rndName;
        }

        public static string GetRandomLastName()
        {
            string rndLastName = BL_Random.GetLastName(BL_Random.rnd.Next(0, 10));

            return rndLastName;
        }

        public static uint GetRandomStudNumber()
        {
            uint rndStudNum = (uint)BL_Random.rnd.Next(1024, 2049);

            return rndStudNum;
        }

        public static DateTime GetRandomEnterDate()
        {
            DateTime start = new DateTime(2016, 1, 9);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(BL_Random.rnd.Next(range));
        }

        public static Student GetRandomStudent()
        {
            Student person = new Student(GetRandomName(), GetRandomLastName(),
                    GetRandomStudNumber(), GetRandomEnterDate());

            return person;
        }

        public static int GetYear(Student person)
        {
            return DateTime.Today.Year - person._enterDate.Year + 1;
        }

        public static string GetShortName(Student person)
        {
            StringBuilder shortName = new StringBuilder(person._lastName + " ");
            shortName.Append(person._name[0] + ".");

            return shortName.ToString();
        }
    }
}
