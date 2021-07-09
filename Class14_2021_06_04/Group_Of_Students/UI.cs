using System;

namespace Group_Of_Students
{
    class UI
    {
        public static void PtintCount(int count)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write("{0}", count);
        }

        public static ConsoleKey ChooseMenu()
        {
            Console.WriteLine("Would you like to enter a new student's data by hand or use a random one?");
            Console.WriteLine("Press 1 or 2. Exit: 0");

            ConsoleKey key = Console.ReadKey(true).Key;

            return key;
        }

        public static ConsoleKey AskAgain(ConsoleKey key)
        {
            key = Console.ReadKey(true).Key;

            return key;
        }

        public static void PrintStudent(Group group)
        {
            for (int i = 0; i < group.countOfStudents; i++)
            {
                ShowStudent(group.persons[i]);
            }
        }

        public static void PrintGroup(Department source)
        {
            Console.Clear();

            byte count = 0;
            for (int i = 0; i < source.countOfGroups; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Group {0}", ++count);
                Console.ResetColor();

                PrintStudent(source.groups[i]);
            }
        }

        private static void ShowStudent(Student person)
        {
            Console.Write($"\nStudent: {person.name} {person.lastName} \nId: {person.studNum}" +
                    $"\nStudent since: {person.enterDate.ToShortDateString()} \nMarks: ");
            PrintMarks(person);
            Console.WriteLine();
            Console.WriteLine(("").PadRight(26, '-'));
        }

        private static void PrintMarks(Student person)
        {
            for (int i = 0; i < person.marks.Length; i++)
            {
                Console.Write("{0} ", person.marks[i]);
            }
        }

        public static string GetName(string text = "\nEnter student's name: ")
        {
            Console.Write(text);
            string name = Console.ReadLine();

            return name;
        }

        public static string GetLastName(string text = "Last Name: ")
        {
            Console.Write(text);
            string lastName = Console.ReadLine();

            return lastName;
        }

        public static int GetId(string text = "Id: ")
        {
            Console.Write(text);
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        public static DateTime GetDateOfEnter(string text = "Date of entering: ")
        {
            Console.Write(text);
            DateTime.TryParse(Console.ReadLine(), out DateTime result);

            return result;
        }

        public static byte[] GetMarks()
        {
            byte[] marks = new byte[10];

            Console.WriteLine("Type marks: ");
            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = byte.Parse(Console.ReadLine());
            }

            return marks;
        }
    }
}
