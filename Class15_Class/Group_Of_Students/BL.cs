using System;

namespace GroupOfStudents
{
    class BL
    {
        public static Student CreateRandomStudent()
        {
            string name     = GetRandomName();
            string lastName = GetRandomLastName();
            uint Id         = GetRandomStudNumber();
            string country  = GetCountry();
            DateTime date   = GetRandomEnterDate();

            Student person = new Student(name, lastName, Id, country, date);

            person.InitRandomMarks();

            return person;
        }

        public static string GetRandomName()
        {
            string rndName = BL_Random.GetName(BL_Random.rnd.Next(0, 20));

            return rndName;
        }

        public static string GetRandomLastName()
        {
            string rndLastName = BL_Random.GetLastName(BL_Random.rnd.Next(0, 20));

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

        public static string GetCountry()
        {
            return "Ukraine";
        }
    }
}
