using System;

namespace Student_Structure
{
    class UI
    {
        public static void PrintYear(Student person)
        {
            Console.Write("Year: {0}\n", BL.GetYear(person));
        }

        public static void PrintShortName(Student person)
        {
            Console.Write("Short name: {0}\n", BL.GetShortName(person));
        }

        public static string GetName(string text="Enter student's name: ")
        {
            Console.Write(text);
            string name = Console.ReadLine();

            return name;
        }

        public static string GetLastName(string text="Last Name: ")
        {
            Console.Write(text);
            string lastName = Console.ReadLine();

            return lastName;
        }

        public static int GetId(string text="Id: ")
        {
            Console.Write(text);
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        public static DateTime GetDateOfEnter(string text= "Date of entering: ")
        {
            Console.Write(text);
            DateTime.TryParse(Console.ReadLine(), out DateTime result);

            return result;
        }

        public static void PrintStudent(Student person)
        {
            Console.Write($"\nStudent: {person.name} {person.lastName} \nId: {person.studNum}" +
                    $"\nStudent since: {person.enterDate.ToShortDateString()}");
        }

        public static ConsoleKey ChooseMenu()
        {
            Console.WriteLine("Would you like to enter a new student's data by hand or use a random one?");
            Console.WriteLine("Press 1 or 2");

            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();

            return key;
        }

        public static string AlterDataOfStudent()
        {
            Console.WriteLine("\n\nWhat kind of student's data do you want to alter?");
            Console.WriteLine("Commands: name, lastname, id, date, year, shortname, exit.");
            string yourAlter = Console.ReadLine().ToLower();

            return yourAlter;
        }

        public static string AskAgain()
        {
            Console.WriteLine();
            string yourAlter = Console.ReadLine().ToLower();

            return yourAlter;
        }

        public static void PrintWarning()
        {
            Console.WriteLine("Try again!");
        }
    }
}
