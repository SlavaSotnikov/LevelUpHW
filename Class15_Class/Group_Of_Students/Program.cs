using Group_Of_Students;
using System;

namespace Group_Of_Students
{
    class Program
    {
        public static void ChooseEnter(ConsoleKey key, Group myGroup, int count = 0)
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
                    default:
                        break;
                }

                key = UI.AskAgain(key);

            } while (key != ConsoleKey.D0);
        }

        static void Main()
        {
            //Department faculty = new Department();

            Group firstGroup = new Group();
            ChooseEnter(UI.ChooseMenu(), firstGroup);
            //faculty.AddGroup(myGroup);

            //Group secondGroup = new Group();
            //ChooseEnter(UI.ChooseMenu(), secondGroup, faculty);
            //faculty.AddGroup(secondGroup);

            //Group thirdGroup = new Group();
            //ChooseEnter(UI.ChooseMenu(), thirdGroup, faculty);
            //faculty.AddGroup(thirdGroup);

            //Department facultTwo = new Department(myGroup, secondGroup, thirdGroup);

            int[] indexes = firstGroup.SearchByLastName("Michael");

            for (int i = 0; i < indexes.Length; i++)
            {
                UI.ShowStudent(firstGroup.GetStudentByPosition(indexes[i]));
            }

            //UI.PrintGroup(firstGroup);

            //UI.PrintFaculty(faculty);

            Console.ReadKey();
        }
    }
}
