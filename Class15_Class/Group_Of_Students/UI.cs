using System;

namespace GroupOfStudents
{
    class UI
    {
        public static string GetConsoleData(string statement)
        {
            Console.Write(statement);
            string userData = Console.ReadLine();

            return userData;
        }

        public static string CheckText(string input)
        {
            string validText = string.Empty;

            if (Validator.IsValidText(input))
            {
                validText = input;
            }
            else
            {
                input = GetConsoleData("Inappropriate Data!Try again.");

                validText = CheckText(input);
            }

            return validText;
        }

        public static string CheckNumber(string input)
        {
            string validNumber = string.Empty;

            if (Validator.IsValidNumber(input))
            {
                validNumber = input;
            }
            else
            {
                input = GetConsoleData("Inappropriate Data!Try again.");

                validNumber = CheckNumber(input);
            }

            return validNumber;
        }

        public static string CheckCountry(string input)
        {
            string validCountry = string.Empty;

            if (Student.IsValidateCountry(input))
            {
                validCountry = input;
            }
            else
            {
                input = GetConsoleData("Ukrainian only! Try again.");

                validCountry = CheckCountry(input);
            }

            return validCountry;
        }

        public static Student CreateCustomStudent()
        {
            string name      = CheckText(GetConsoleData("Enter student's name: "));
            string lastName  = CheckText(GetConsoleData("Last Name: "));
            string country   = CheckCountry(GetConsoleData("Enter Country: "));

            string studentId = CheckNumber(GetConsoleData("Id: "));
            uint.TryParse(studentId, out uint Id);

            string enterDate = CheckNumber(GetConsoleData("Date of entering: "));
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
                result = CheckNumber(Console.ReadLine());
                byte.TryParse(result, out mark);

                if (mark > 0)
                {
                    person.AddMark(index, mark);
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
            for (int i = 0; i < group.AmountOfStudents; i++)
            {
                ShowStudent(group.GetStudentByPosition(i));
            }
        }

        private static void ShowStudent(Student person)
        {
            Console.Write($"\nStudent: {person.Name} {person.LastName} \nId: {person.StudNumber}" +
                    $"\nStudent since: {person.EnterDate.ToShortDateString()} \nCountry: {person.Country}\nMarks: ");
            PrintMarks(person);
            Console.WriteLine();
            Console.WriteLine(("").PadRight(26, '-'));
        }

        private static void PrintMarks(Student person)
        {
            for (int i = 0; i < person.AmountOfMarks; i++)
            {
                Console.Write("{0} ", person.GetMarkByPosition(i));
            }
        }
    }
}
