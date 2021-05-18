using System;
using System.Text;
using System.Threading;

namespace Menu
{
    class Program
    {
        static string pilotName;
        static string country;


        static void PickAShip()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            Console.SetCursorPosition(35, 1);
            Console.WriteLine("Captain: Pick your bird:");

            Console.SetCursorPosition(35, 4);
            Console.WriteLine("Light Ship: possess higer mobility and fire rate");
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("Special Weapon: Suppressing Fire.");

            Console.SetCursorPosition(45, 7);
            Console.WriteLine("    ▲    ");
            Console.SetCursorPosition(45, 8);
            Console.WriteLine("    Ο    ");
            Console.SetCursorPosition(45, 9);
            Console.WriteLine("  ║ Ο ║  ");
            Console.SetCursorPosition(45, 10);
            Console.WriteLine("╱╲╲╲Λ╱╱╱╲");
            Console.SetCursorPosition(45, 11);
            Console.WriteLine("  <╱╦╲>  ");

            Console.SetCursorPosition(35, 13);
            Console.WriteLine("Heavy Ship: fire power, heavy armor, less mobility");
            Console.SetCursorPosition(35, 14);
            Console.WriteLine("Special Weapon: Armour Piercer.");

            Console.SetCursorPosition(45, 16);
            Console.WriteLine("    ▲    ");
            Console.SetCursorPosition(45, 17);
            Console.WriteLine("   ╱Ο╲   ");
            Console.SetCursorPosition(45, 18);
            Console.WriteLine("∩ ╱UKR╲ ∩");
            Console.SetCursorPosition(45, 19);
            Console.WriteLine("║═══Λ═══║");
            Console.SetCursorPosition(45, 20);
            Console.WriteLine(" <╱*╦*╲> ");


            Console.SetCursorPosition(35, 22);
            string shipModel = Console.ReadLine();

            Console.Clear();
            Console.SetCursorPosition(35, 8);

            string finalDialogue = "Captain: I thank you for join us...\n" +
                "Captain: Before you go, let me remind you again our mission...\n" +
                "Captain: Shoot every invator in sight...\n" +
                "Captain: Don't let them get throught you...";


            for (int i = 0; i < finalDialogue.Length; i++)
            {
                if (finalDialogue[i] == '\n')
                {
                    Console.SetCursorPosition(35, 10);
                    if ()
                    {
                        Console.SetCursorPosition(35, 10);
                    }
                    else if ()
                    {
                        country = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write(finalDialogue[i]);
                    Thread.Sleep(50);
                }
            }
        }
        static void ShowDialogue()
        {
            string dialogue = "Captain: Greetings, fly lieutenant. Report! What is your name? \n" +
                "Captain: Where are you come from? \n" +
                "Captain: Pick your ship.";

            Console.Clear();
            Console.SetCursorPosition(35, 10);

            int count = 0;

            for (int i = 0; i < dialogue.Length; i++)
            {
                if (dialogue[i] == '\n')
                {
                    count++;
                    Console.SetCursorPosition(35, 10 + count);
                    if (count == 1)
                    {
                        pilotName = Console.ReadLine();
                        Console.SetCursorPosition(35, 10 + count + 1);
                    }
                    else if (count == 2)
                    {
                        Console.SetCursorPosition(35, 10 + count + 1);
                        country = Console.ReadLine();
                        Console.SetCursorPosition(35, 10 + count + 2);
                    }
                }
                else
                {
                    Console.Write(dialogue[i]);
                    Thread.Sleep(50);
                }
            }

            Thread.Sleep(1000);
            PickAShip();

        }

        static void Main()
        {
            //ShowDialogue();

            PickAShip();

            Console.ReadKey();

        }
    }
}
