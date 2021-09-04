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
                        myGroup.Add(UI.CreateCustomStudent());
                        break;
                    case ConsoleKey.D2:
                        // Create by random.
                        myGroup.Add(BL.CreateRandomStudent());
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

            //int id = firstGroup.SearchById(190);

            //if (true)
            //{

            //}

            Group nextLevel = firstGroup.GoToNextLevel();

            //Group secondGroup = new Group();
            //ChooseEnter(UI.ChooseMenu(), secondGroup, faculty);
            //faculty.AddGroup(secondGroup);

            //Group thirdGroup = new Group();
            //ChooseEnter(UI.ChooseMenu(), thirdGroup, faculty);
            //faculty.AddGroup(thirdGroup);

            //Department facultTwo = new Department(myGroup, secondGroup, thirdGroup);

            //int[] indexes = firstGroup.SearchByLastName("Michael");

            //for (int i = 0; i < indexes.Length; i++)
            //{
            //    UI.ShowStudent(firstGroup.GetStudentByPosition(indexes[i]));
            //}

            UI.PrintGroup(nextLevel);

            //UI.PrintFaculty(faculty);

            Console.ReadKey();
        }
    }
}
