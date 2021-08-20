using System;
using System.Collections;

namespace Group_Of_Students
{
    class Program
    {
        public static Student GetCustomStudent()
        {
            Student person = new Student()
            {
                name = UI.GetName(),
                lastName = UI.GetLastName(),
                studNum = UI.GetId(),
                enterDate = UI.GetDateOfEnter(),
                marks = UI.GetMarks()
            };

            return person;
        }

        public static void ChooseEnter(ConsoleKey key, ref Group group, int count = 0)
        {
            Student person = new Student()
            {
                marks = new byte[10]
            };

            do
            {
                UI.PtintCount(++count);

                switch (key)
                {
                    case ConsoleKey.D1:
                        BL.AddStudent(ref group, GetCustomStudent());
                        break;
                    case ConsoleKey.D2:
                        BL.InitRandomStudent(ref person);
                        BL.AddStudent(ref group, person);
                        break;
                    default:
                        break;
                }

                key = UI.AskAgain(key);

            } while (key != ConsoleKey.D0);
        }

        static void Main()
        {
            Department faculty = BL.CreateDepartment(3);

            Group first = BL.CreateGroup(10);
            //Student person = new Student();

            ChooseEnter(UI.ChooseMenu(), ref first);

            //UI.PrintStudent(first);

            //Console.ReadKey();

            //Group nextLevel = BL.GoToNextLevel(first);


            //BL.AddStudent(ref first, st);
            //BL.AddStudent(ref first, st2);
            //UI.PrintStudent(nextLevel);

            //Console.ReadKey();
            //Student person = GetCustomStudent();
            //BL.EditStudent(first, person, 2);
            //UI.PrintStudent(first);

            //BL.DeleteStudent(ref first, 1);
            //UI.PrintStudent(first);

            //BL.AddGroup(ref faculty, first);


            //Group second = BL.CreateGroup(10);

            //ChooseEnter(UI.ChooseMenu(), ref second);
            //BL.AddGroup(ref faculty, second);


            //Group third = BL.CreateGroup(10);

            //ChooseEnter(UI.ChooseMenu(), ref third);
            //BL.AddGroup(ref faculty, third);

            //UI.PrintGroup(faculty);

            IStudentIterator iter = first.CreateNumerator();
            while (iter.HasNext())
            {
                Student st = iter.Next();
                Console.WriteLine("{0} {1}",st.Name, st.LastName);
            }



            Console.ReadKey();
        }
    }
}

