using System;

namespace Student_Class
{
    class BL_Random
    {
        public static Random rnd = new Random();

        public static string GetName(int index)
        {
            string[] name = new string[10];

            name[0] = "Oliver";
            name[1] = "William";
            name[2] = "James";
            name[3] = "Henry";
            name[4] = "Michael";
            name[5] = "Jacob";
            name[6] = "Jack";
            name[7] = "John";
            name[8] = "David";
            name[9] = "Thomas";

            return name[index];
        }

        public static string GetLastName(int index)
        {
            string[] lastName = new string[10];

            lastName[0] = "Adams";
            lastName[1] = "Armstrong";
            lastName[2] = "Baker";
            lastName[3] = "Brown";
            lastName[4] = "Cole";
            lastName[5] = "Edwards";
            lastName[6] = "Evans";
            lastName[7] = "Fox";
            lastName[8] = "Gibson";
            lastName[9] = "Gray";

            return lastName[index];
        }
    }
}
