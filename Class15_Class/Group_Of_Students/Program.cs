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
            Group myGroup = BL.CreateGroup();

            ChooseEnter(UI.ChooseMenu(), myGroup);

            UI.PrintGroup(myGroup);

            Console.ReadKey();
        }
    }
}
