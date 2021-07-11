using Group_Of_Students;
using System;

namespace Group_Of_Students
{
    class UI
    {
        public static string GetConsoleData(string statement)
        {
            Console.Write(statement);
            string userData = Console.ReadLine();

            return userData;
        }

        public static string GetRightText(string input) // Try cycle, rename.
        {
            string validText = string.Empty;

            while (!Validator.IsValidText(input))
            {
                input = GetConsoleData("Inappropriate Data!Try again.");
            }

            validText = input;

            return validText;
        }

        public static string GetRightNumber(string input)
        {
            string validNumber = string.Empty;

            if (!Validator.IsValidNumber(input))
            {
                input = GetConsoleData("Inappropriate Data!Try again.");
            }

            validNumber = input;

            return validNumber;
        }

        public static string CheckCountry(string input)
        {
            string validCountry = string.Empty;

            if (Validator.IsValidateCountry(input))
            {
                input = GetConsoleData("Ukrainian only! Try again.");
            }

            validCountry = input;

            return validCountry;
        }

        public static Student CreateCustomStudent()
        {
            string name      = GetRightText(GetConsoleData("Enter student's name: "));
            string lastName  = GetRightText(GetConsoleData("Last Name: "));
            string country   = CheckCountry(GetConsoleData("Enter Country: "));

            string studentId = GetRightNumber(GetConsoleData("Id: "));
            uint.TryParse(studentId, out uint Id);

            string enterDate = GetRightNumber(GetConsoleData("Date of entering: "));
            DateTime.TryParse(enterDate, out DateTime date);

            Student person = new Student(name, lastName, Id, country, date);

            InitCustomMarks(person);

            return person;
        }

        public static void InitCustomMarks(Student person)
        {
            byte index = 0;
            byte mark;
            string result = string.Empty;

            Console.Write("Enter marks: ");

            do
            {
                result = GetRightNumber(Console.ReadLine());
                byte.TryParse(result, out mark);

                if (mark > 0)
                {
                    //person.AddMark(mark); // TODO: Develop AddMark.
                    ++index; 
                }

            } while (mark != 0);
        }

        public static ConsoleKey ChooseMenu()
        {
            Console.WriteLine("Would you like to enter a new student's data by hand or use a random one?");
            Console.WriteLine("Press 1 or 2. Exit: 0");

            ConsoleKey key = Console.ReadKey(true).Key;

            return key;
        }

        public static void PtintCount(int count)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write("{0}", count);
        }

        public static ConsoleKey AskAgain(ConsoleKey key)
        {
            key = Console.ReadKey(true).Key;

            return key;
        }

        public static void PrintFaculty(Department source)
        {
            Console.Clear();

            byte count = 0;
            for (int i = 0; i < source.AmountOfGroups; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Group {0}", ++count);
                Console.ResetColor();

                PrintGroup(source.GetGroupByPosition(i));
            }
        }

        public static void PrintGroup(Group group)
        {
            if (group.LastOperationStatus != OperationStatus.Ok)
            {
                Console.WriteLine("\n{0}", group.LastOperationStatus.ToString());
            }
            else
            {
                for (int i = 0; i < group.AmountOfStudents; i++)
                {
                    ShowStudent(group.GetStudentByPosition(i));
                }
            }
        }

        public static void ShowStudent(Student person)
        {
            Console.Write($"\nStudent: {person.Name} {person.LastName} \nId: {person.StudNumber}" +
                    $"\nStudent since: {person.EnterDate.ToShortDateString()} \nCountry: {person.Country}\n\nMarks: \n");
            PrintMarks(person);
            Console.WriteLine(("").PadRight(26, '-'));
        }

        private static void PrintMarks(Student person)
        {
            for (int i = 0; i < person.AmountOfMarks; i++)
            {
                PrintMark(person[i]);
            }
        }

        private static void PrintMark(Mark source)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write("{0, -12}", source.Date.ToShortDateString());
            Console.Write("{0, -14} ", source.Subject);
            Console.WriteLine("{0}", source.Value);
            Console.WriteLine();

            Console.ResetColor();
        }
    }
}
