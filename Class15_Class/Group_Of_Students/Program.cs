using Group_Of_Students;
using System;

namespace GroupOfStudents
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

            int index = firstGroup.SearchByName("Michael");

            Student our = firstGroup.GetStudentByPosition(index);

            if (firstGroup.LastOperationStatus != OperationStatus.Ok)
            {
                Console.WriteLine("\n{0}", firstGroup.LastOperationStatus.ToString());
            }
            else
            {
                UI.ShowStudent(our);
            }

            

            

            //UI.PrintGroup(myGroup);

            //UI.PrintFaculty(faculty);

            Console.ReadKey();
        }
    }
}
