using System;

namespace Student_Structure
{
    class Program
    {
        // Depends on your choice, enter student's data by hand or by Random.
        public static Student ChooseEnter(ConsoleKey key)
        {
            Student person = new Student();

            switch (key)
            {
                case ConsoleKey.D1:
                    person = GetCustomStudent(person);
                    break;
                case ConsoleKey.D2:
                    person = BL.GetRandomStudent(person);
                    break;
                default:
                    break;
            }

            return person;
        }

        public static Student GetCustomStudent(Student person)
        {
            person = new Student()
            {
                name      = UI.GetName(),
                lastName  = UI.GetLastName(),
                studNum   = UI.GetId(),
                enterDate = UI.GetDateOfEnter()
            };

            return person;
        }

        public static void GetAlterChoice(Student person)
        {
            Alter alt = Alter.none;

            string choiceAlt = UI.AlterDataOfStudent();

            while (alt != Alter.exit)
            {
                if (Enum.TryParse(choiceAlt, out alt))
                {
                    switch (alt)
                    {
                        case Alter.name:
                            person.name = UI.GetName("New Name: ");
                            break;
                        case Alter.lastname:
                            person.lastName = UI.GetLastName("New Last Name: ");
                            break;
                        case Alter.id:
                            person.studNum = UI.GetId("New Id: ");
                            break;
                        case Alter.enterdate:
                            person.enterDate = UI.GetDateOfEnter("Enter date: ");
                            break;
                        case Alter.year:
                            person.course = BL.GetYear(person);
                            break;
                        case Alter.shortname:
                            person.shortName = BL.GetShortName(person);
                            break;
                        //case Alter.exit:
                        //    Environment.Exit(0);
                        //    break;
                        default:
                            break;
                    }

                    UI.PrintStudent(person);
                }
                else
                {
                    UI.GetWarning();
                }

                choiceAlt = UI.AskAgain();
            }
        }

        static void Main()
        {
            Student person = ChooseEnter(UI.ChooseMenu());

            UI.PrintStudent(person);

            GetAlterChoice(person);

            

            Console.ReadKey();
        }
    }
}
