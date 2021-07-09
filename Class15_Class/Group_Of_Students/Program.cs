using System;

namespace GroupOfStudents
{
    class Program
    {
        public static void ChooseEnter(ConsoleKey key, Group myGroup, Department faculty, int count = 0)
        {
            do
            {
                UI.PtintCount(++count);

                switch (key)
                {
                    case ConsoleKey.D1:
                        // Create by hand.
                        myGroup.AddStudent(UI.CreateCustomStudent());
                        break;
                    case ConsoleKey.D2:
                        // Create by random.
                        myGroup.AddStudent(BL.CreateRandomStudent());
                        break;
                    case ConsoleKey.D3:
                        faculty.AddGroup(myGroup);
                        break;
                    default:
                        break;
                }

                key = UI.AskAgain(key);

            } while (key != ConsoleKey.D0);
        }

        static void Main()
        {
            Department faculty = new Department();

            Group myGroup = new Group();
            ChooseEnter(UI.ChooseMenu(), myGroup, faculty);

            Group secondGroup = new Group();
            ChooseEnter(UI.ChooseMenu(), secondGroup, faculty);

            Group thirdGroup = new Group();
            ChooseEnter(UI.ChooseMenu(), thirdGroup, faculty);

            //UI.PrintGroup(myGroup);

            UI.PrintFaculty(faculty);

            Console.ReadKey();
        }
    }
}
