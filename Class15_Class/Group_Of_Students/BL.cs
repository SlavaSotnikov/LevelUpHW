using System;

namespace Group_Of_Students
{
    class BL
    {
        public static Group CreateGroup(int students)
        {
            Group one = new Group(students);

            return one;
        }

        public static Student CreateRandomStudent()
        {
           int capacity = 10;

            Student person = new Student(GetRandomName(), GetRandomLastName(),
                    GetRandomStudNumber(), GetRandomEnterDate(), capacity);

            person.SetMarks(InitRandomMarks(person.GetMarks()));

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

        public static byte[] InitRandomMarks(byte[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (byte)BL_Random.rnd.Next(2, 6);
            }

            return input;
        }
    }
}
