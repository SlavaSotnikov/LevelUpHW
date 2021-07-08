using System;

namespace Group_Of_Students
{
    class UI
    {
        public static string GetText(string statement)
        {
            Console.Write(statement);
            string userText = Console.ReadLine();
            string validText = string.Empty;

            if (!Validator.IsValidateText(userText))
            {
                Console.WriteLine("Inappropriate Text! Try again.");
                GetText(statement);
            }
            else
            {
                validText = userText;
            }

            return validText;
        }

        public static string GetNumber(string statement)
        {
            Console.Write(statement);
            string userText = Console.ReadLine();
            string validText = string.Empty;

            if (!Validator.IsValidateNumber(userText))
            {
                Console.WriteLine("Inappropriate Text! Try again.");
                GetText(statement);
            }
            else
            {
                validText = userText;
            }

            return validText;
        }

        public static string ValidatorCountry(string text)
        {
            if (!Student.IsValidateCountry(text))
            {
                Console.WriteLine("Ukrainian only! Try again.");
            }

            return text;
        }

        public static Student CreateCustomStudent()
        {
            string name     = GetText("Enter student's name: ");
            string lastName = GetText("Last Name: ");
            uint.TryParse(GetNumber("Id: "), out uint Id);
            string country  = ValidatorCountry(GetText("Enter country: "));
            DateTime.TryParse(GetNumber("Date of entering: "), out DateTime date);

            Student person = new Student(name, lastName, Id, country, date);

            InitCustomMarks(person);

            return person;
        }

        public static void InitCustomMarks(Student person)
        {
            byte index = 0;
            byte result = 1;

            Console.Write("Enter marks: ");

            do
            {
                result = byte.Parse(Console.ReadLine());

                if (result > 0)
                {
                    person.AddMark(index, result);
                    ++index; 
                }

            } while (result != 0);
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

        public static void PrintGroup(Group group)
        {
            Console.Clear();

            for (int i = 0; i < group.GetCountOfStudents(); i++)
            {
                ShowStudent(group.GetStudentByPosition(i));
            }
        }

        private static void ShowStudent(Student person)
        {
            Console.Write($"\nStudent: {person.GetName()} {person.GetLastName()} \nId: {person.GetStudNumber()}" +
                    $"\nStudent since: {person.GetEnterDate().ToShortDateString()} \nCountry: {person.Country}\nMarks: ");
            PrintMarks(person);
            Console.WriteLine();
            Console.WriteLine(("").PadRight(26, '-'));
        }

        private static void PrintMarks(Student person)
        {
            for (int i = 0; i < person.GetAmountOfMarks(); i++)
            {
                Console.Write("{0} ", person.GetMarkByPosition(i));
            }
        }
    }
}
