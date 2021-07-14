using Group_Of_Students;
using System;

namespace Group_Of_Students
{
    class UI
    {
        public static string GetRightText(string statement)
        {
            string validText = string.Empty;
            string userData = string.Empty;

            while (!Validator.IsValidText(userData))
            {
                Console.Write(statement);
                userData = Console.ReadLine();
            }

            validText = userData;

            return validText;
        }

        public static string GetRightNumber(string statement)
        {
            string validNumber = string.Empty;
            string userData = string.Empty;

            while (!Validator.IsValidNumber(userData))
            {
                Console.Write(statement);
                userData = Console.ReadLine();
            }

            validNumber = userData;

            return validNumber;
        }

        public static string GetRightCountry(string statement)
        {
            string validCountry = string.Empty;
            string userData = string.Empty;

            while (!Validator.IsValidateCountry(userData))
            {
                Console.Write(statement);
                userData = Console.ReadLine();
            }

            validCountry = userData;

            return validCountry;
        }

        public static string GetSubject(string statement = "Enter a subject: ")
        {
            Console.WriteLine(statement);

            return Console.ReadLine();
        }

        public static DateTime GetDate(string statement = "Enter a date: ")
        {
            Console.WriteLine(statement);
            string newDate = Console.ReadLine();
            DateTime.TryParse(newDate, out DateTime date);

            return date;
        }

        public static byte GetMark(string statement = "Enter a value: ")
        {
            Console.WriteLine(statement);
            string newValue = Console.ReadLine();
            byte.TryParse(newValue, out byte mark);

            return mark;
        }

        public static Mark GetCustomMark()
        {
            byte mark = GetMark();
            string subject = GetSubject();
            DateTime date = GetDate();

            Mark newMark = new Mark(subject, date, mark);

            return newMark;
        }

        public static Student CreateCustomStudent()
        {
            string name      = GetRightText("Enter student's name: ");
            string lastName  = GetRightText("Last Name: ");
            string country   = GetRightCountry("Enter Country: ");

            string studentId = GetRightNumber("Id: ");
            uint.TryParse(studentId, out uint Id);

            string enterDate = GetRightNumber("Date of entering: ");
            DateTime.TryParse(enterDate, out DateTime date);

            Student person = new Student(name, lastName, Id, country, date);

            InitCustomMarks(person);

            return person;
        }

        public static void InitCustomMarks(Student person)
        {
            Mark newMark;

            Console.Write("Enter marks: ");

            do
            {
                newMark = GetCustomMark();

                person.AddMark(newMark);

            } while (newMark.Value != 0);
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
