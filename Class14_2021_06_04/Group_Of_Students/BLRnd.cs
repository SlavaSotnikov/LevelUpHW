using System;

namespace Group_Of_Students
{
    class BLRnd
    {
        public static Random rnd = new Random();

        public static string GetName(int index) // Ask a question about protection.
        {
            string[] name = new string[20];

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
            name[10] = "Jaxon";
            name[11] = "Harvey";
            name[12] = "Jude";
            name[13] = "Albert";
            name[14] = "Stanley";
            name[15] = "Frankie";
            name[16] = "Gabriel";
            name[17] = "Ryan";
            name[18] = "Tyler";
            name[19] = "Jasper";

            return name[index];
        }

        public static string GetLastName(int index)
        {
            string[] lastName = new string[20];

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
            lastName[10] = "Ferguson";
            lastName[11] = "Goodwin";
            lastName[12] = "Johnson";
            lastName[13] = "Kent";
            lastName[14] = "Miller";
            lastName[15] = "Nolan";
            lastName[16] = "Ortiz";
            lastName[17] = "Oliver";
            lastName[18] = "Rodgers";
            lastName[19] = "Forbes";

            return lastName[index];
        }
    }
}
