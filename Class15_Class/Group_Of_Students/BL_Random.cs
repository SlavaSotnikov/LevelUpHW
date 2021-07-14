using System;

namespace Group_Of_Students
{
    class BL_Random
    {
        private const byte AMOUNT_OF_LETTERS = 26;

        public static Random rnd = new Random();

        public static string GetName(int index)
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
            name[14] = "Michael";//Stanley
            name[15] = "Michael";//Frankie
            name[16] = "Michael";//Gabriel
            name[17] = "Michael";//Ryan
            name[18] = "Michael";//Tyler
            name[19] = "Michael";//Jasper

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

        public static string GetSubject(int index)
        {
            string[] subject = new string[10];

            subject[0] = "Algebra";
            subject[1] = "Geometry";
            subject[2] = "Statistics";
            subject[3] = "Trigonometry";
            subject[4] = "Economics";
            subject[5] = "Geography";
            subject[6] = "World History";
            subject[7] = "Biology";
            subject[8] = "Chemistry";
            subject[9] = "Physics";

            return subject[index];
        }

        public static char GetLetter(int index)
        {
            char[] alphabet = new char[AMOUNT_OF_LETTERS];

            alphabet[0] = 'A';
            alphabet[1] = 'B';
            alphabet[2] = 'C';
            alphabet[3] = 'D';
            alphabet[4] = 'E';
            alphabet[5] = 'F';
            alphabet[6] = 'G';
            alphabet[7] = 'H';
            alphabet[8] = 'I';
            alphabet[9] = 'J';
            alphabet[10] = 'K';
            alphabet[11] = 'L';
            alphabet[12] = 'M';
            alphabet[13] = 'N';
            alphabet[14] = 'O';
            alphabet[15] = 'P';
            alphabet[16] = 'Q';
            alphabet[17] = 'R';
            alphabet[18] = 'S';
            alphabet[19] = 'T';
            alphabet[20] = 'U';

            return alphabet[index];
        }
    }
}
