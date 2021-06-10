using System;

namespace Student_Structure
{
    class Program
    {
        // Depends on your choice, enter student's data by hand or by Random.
        public static void ChooseEnter(ConsoleKey key, ref Student source)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    GetCustomStudent(ref source);
                    break;
                case ConsoleKey.D2:
                    BL.GetRandomStudent(ref source);
                    break;
                default:
                    break;
            }
        }

        public static void GetCustomStudent(ref Student person)
        {
            {
                person.name = UI.GetName();
                person.lastName = UI.GetLastName();
                person.studNum = UI.GetId();
                person.enterDate = UI.GetDateOfEnter();
            };
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
            Student person = new Student();

            ChooseEnter(UI.ChooseMenu(), ref person);

            UI.PrintStudent(person);

            GetAlterChoice(person);

            Console.ReadKey();
        }
    }
}
