using System;

namespace Student_Class
{
    class Program
    {
        public static Student ChooseEnter(ConsoleKey key)
        {
            Student person = null;

            switch (key)
            {
                case ConsoleKey.D1:
                    person = GetCustomStudent();
                    break;
                case ConsoleKey.D2:
                    person = BL.GetRandomStudent();
                    break;
                default:
                    break;
            }

            return person;
        }

        public static Student GetCustomStudent()
        {
            Student person = new Student(UI.GetName(), UI.GetLastName(),
                    UI.GetStudNumber(), UI.GetEnterDate());

            return person;
        }

        public static void GetAlterChoice(Student person)
        {
            Alter alt = Alter.none;

            while (alt != Alter.exit)
            {
                string choiceAlt = UI.AlterDataOfStudent();

                if (Enum.TryParse(choiceAlt, out alt))
                {
                    switch (alt)
                    {
                        case Alter.name:
                            person._name = UI.GetName("New Name: ");
                            break;
                        case Alter.lastname:
                            person._lastName = UI.GetLastName("New Last Name: ");
                            break;
                        case Alter.id:
                            person._studNum = UI.GetStudNumber("New Id: ");
                            break;
                        case Alter.enterdate:
                            person._enterDate = UI.GetEnterDate("Enter date: ");
                            break;
                        case Alter.year:
                            UI.PrintYear(person);
                            break;
                        case Alter.shortname:
                            UI.PrintShortName(person);
                            break;
                        case Alter.exit:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    UI.PrintWarning();
                }

                UI.PrintStudent(person);
            }
        }

        static void Main()
        {
            Student person = ChooseEnter(UI.ChooseMenu());

            UI.PrintStudent(person);

            GetAlterChoice(person);
        }
    }
}
