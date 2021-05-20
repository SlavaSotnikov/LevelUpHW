using System;

namespace Enum_Flags_
{
    
    class Program
    {
        
        static void ShowSchedule(DayOfWeek schedule)
        {            
            string dayOfWeek = Convert.ToString(schedule).ToUpper();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}  " + "\t", dayOfWeek);
        }

        static void ShowDay(DayOfWeek schedule)
        {
            Console.ResetColor();
            Console.Write("{0}  " + "\t", schedule);
        }

        static void ShowWrongNumberOfDay(int er)
        {
            Console.SetCursorPosition(20, er+=2);
            Console.WriteLine("You should use only 1-7 keys. Try again, please.");
            Console.WriteLine();
        }

        static void Main()
        {
            Console.SetCursorPosition(30, 2);
            Console.WriteLine("Set up your gym schedule: ");
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("1-Mon  2-Tue  3-Wed  4-Thu  5-Fri  6-Sat  7-Sun");

            int count = 0;
            int top = 6;
            int er = 5;
            DayOfWeek schedule = DayOfWeek.Emptyday;

            Console.SetCursorPosition(40, 5);
            ConsoleKeyInfo keyInfo = Console.ReadKey(); ;
            
            while (keyInfo.Key != ConsoleKey.Enter)
            {               
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        schedule |= DayOfWeek.Monday;
                        break;
                    case ConsoleKey.D2:
                        schedule |= DayOfWeek.Tuesday;
                        break;
                    case ConsoleKey.D3:
                        schedule |= DayOfWeek.Wednesday;
                        break;
                    case ConsoleKey.D4:
                        schedule |= DayOfWeek.Thursday;
                        break;
                    case ConsoleKey.D5:
                        schedule |= DayOfWeek.Friday;
                        break;
                    case ConsoleKey.D6:
                        schedule |= DayOfWeek.Saturday;
                        break;
                    case ConsoleKey.D7:
                        schedule |= DayOfWeek.Sunday;
                        break;
                    default:
                        ShowWrongNumberOfDay(er);
                        break;
                }

                if ((count >= 0) && (keyInfo.Key != ConsoleKey.Enter))
                {
                    er += 2;
                    Console.SetCursorPosition(30, ++er);
                    Console.Write("Next day: ");
                    Console.SetCursorPosition(40, er);
                    keyInfo = Console.ReadKey();
                    count++;
                    ++top;
                }
            }

            Console.Clear();

            Console.WriteLine();

            if (schedule.HasFlag(DayOfWeek.Monday))
            {
                ShowSchedule(DayOfWeek.Monday);
            }
            else
            {
                ShowDay(DayOfWeek.Monday);
            }
            if (schedule.HasFlag(DayOfWeek.Tuesday))
            {
                ShowSchedule(DayOfWeek.Tuesday);
            }
            else
            {
                ShowDay(DayOfWeek.Tuesday);
            }
            if (schedule.HasFlag(DayOfWeek.Wednesday))
            {
                ShowSchedule(DayOfWeek.Wednesday);
            }
            else
            {
                ShowDay(DayOfWeek.Wednesday);
            }
            if (schedule.HasFlag(DayOfWeek.Thursday))
            {
                ShowSchedule(DayOfWeek.Thursday);
            }
            else
            {
                ShowDay(DayOfWeek.Thursday);
            }
            if (schedule.HasFlag(DayOfWeek.Friday))
            {
                ShowSchedule(DayOfWeek.Friday);
            }
            else
            {
                ShowDay(DayOfWeek.Friday);
            }
            if (schedule.HasFlag(DayOfWeek.Saturday))
            {
                ShowSchedule(DayOfWeek.Saturday);
            }
            else
            {
                ShowDay(DayOfWeek.Saturday);
            }
            if (schedule.HasFlag(DayOfWeek.Sunday))
            {
                ShowSchedule(DayOfWeek.Sunday);
            }
            else
            {
                ShowDay(DayOfWeek.Sunday);
            }



            Console.ReadKey();
        }
    }
}
