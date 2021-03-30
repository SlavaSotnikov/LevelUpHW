using System;

namespace Weekdays
{
    class Program
    {
        static void Main()
        {
            string weekday = String.Empty;

            do
            {               
                Console.ResetColor();
                Console.Write("Enter a day of week: ? ");
                weekday = Console.ReadLine().ToLower();

                switch (weekday)
                {
                    case "monday":
                    case "понеділок":
                    case "понедельник":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("1");
                        break;
                    case "tuesday":
                    case "вівторок":
                    case "вторник":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("2");
                        break;
                    case "wednesday":
                    case "середа":
                    case "среда":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("3");
                        break;
                    case "thursday":
                    case "четвер":
                    case "четверг":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("4");
                        break;
                    case "friday":
                    case "пятниця":
                    case "пятница":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("5");
                        break;
                    case "saturday":
                    case "субота":
                    case "суббота":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("6");
                        break;
                    case "sunday":
                    case "неділя":
                    case "воскресенье":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("7");
                        break;
                    default:
                        Console.WriteLine("\n" + $"Sorry, but '{weekday}' is not a weekday." + "\n");
                        break;                        
                }
            } while (weekday != "0");

            Console.ReadKey();
        }
    }
}
