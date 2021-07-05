using System;

namespace Group_Of_Students
{
    class UI
    {
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
            for (int i = 0; i < group.GetCountOfStudents(); i++)
            {
                ShowStudent(group.GetStudent()[i]);
            }
        }

        private static void ShowStudent(Student person)
        {
            Console.Write($"\nStudent: {person.GetName()} {person.GetLastName()} \nId: {person.GetStudNumber()}" +
                    $"\nStudent since: {person.GetEnterDate().ToShortDateString()} \nMarks: ");
            PrintMarks(person);
            Console.WriteLine();
            Console.WriteLine(("").PadRight(26, '-'));
        }

        private static void PrintMarks(Student person)
        {
            for (int i = 0; i < person.GetMarks().Length; i++)
            {
                Console.Write("{0} ", person.GetMarks()[i]);
            }
        }
    }
}
