using System;

namespace Enum_Flags_
{
    
    class Program
    {
        private static void GetHasFlag(DayOfWeek schedule)
        {
            if (schedule.HasFlag(DayOfWeek.Monday_Gym))
            {
                ShowGymSchedule(DayOfWeek.Monday_Gym);
            }
            if (schedule.HasFlag(DayOfWeek.Monday_Jogging))
            {
                ShowJoggingSchedule(DayOfWeek.Monday_Jogging);
            }
            else
            {
                ShowDay("Monday");
            }

            if (schedule.HasFlag(DayOfWeek.Tuesday_Gym))
            {
                ShowGymSchedule(DayOfWeek.Tuesday_Gym);
            }
            if (schedule.HasFlag(DayOfWeek.Tuesday_Jogging))
            {
                ShowJoggingSchedule(DayOfWeek.Tuesday_Jogging);
            }
            else
            {
                ShowDay("Tuesday");
            }

            if (schedule.HasFlag(DayOfWeek.Wednesday_Gym))
            {
                ShowGymSchedule(DayOfWeek.Wednesday_Gym);
            }
            if (schedule.HasFlag(DayOfWeek.Wednesday_Jogging))
            {
                ShowJoggingSchedule(DayOfWeek.Wednesday_Jogging);
            }
            else
            {
                ShowDay("Wednesday");
            }

            if (schedule.HasFlag(DayOfWeek.Thursday_Gym))
            {
                ShowGymSchedule(DayOfWeek.Thursday_Gym);
            }
            if (schedule.HasFlag(DayOfWeek.Thursday_Jogging))
            {
                ShowJoggingSchedule(DayOfWeek.Thursday_Jogging);
            }
            else
            {
                ShowDay("Thursday");
            }

            if (schedule.HasFlag(DayOfWeek.Friday_Gym))
            {
                ShowGymSchedule(DayOfWeek.Friday_Gym);
            }
            if (schedule.HasFlag(DayOfWeek.Friday_Jogging))
            {
                ShowJoggingSchedule(DayOfWeek.Friday_Jogging);
            }
            else
            {
                ShowDay("Friday");
            }

            if (schedule.HasFlag(DayOfWeek.Saturday_Gym))
            {
                ShowGymSchedule(DayOfWeek.Saturday_Gym);
            }
            if (schedule.HasFlag(DayOfWeek.Saturday_Jogging))
            {
                ShowJoggingSchedule(DayOfWeek.Saturday_Jogging);
            }
            else
            {
                ShowDay("Saturday");
            }

            if (schedule.HasFlag(DayOfWeek.Sunday_Gym))
            {
                ShowGymSchedule(DayOfWeek.Sunday_Gym);
            }
            if (schedule.HasFlag(DayOfWeek.Sunday_Jogging))
            {
                ShowJoggingSchedule(DayOfWeek.Sunday_Jogging);
            }
            else
            {
                ShowDay("Sunday");
            }
        }

        static void ShowGymSchedule(DayOfWeek schedule)
        {            
            string dayOfWeek = Convert.ToString(schedule).ToUpper();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("{0} |", dayOfWeek);
        }

        static void ShowJoggingSchedule(DayOfWeek schedule)
        {
            string dayOfWeek = Convert.ToString(schedule).ToUpper();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0} |", dayOfWeek);
        }

        static void ShowDay(string day)
        {
            Console.ResetColor();
            Console.Write("{0}| ", day);
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
            Console.WriteLine("Set up your Gym schedule: ");
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("1-Mon  2-Tue  3-Wed  4-Thu  5-Fri  6-Sat  7-Sun");

            int count = 0;
            int top = 6;
            int er = 5;
            DayOfWeek schedule = DayOfWeek.Emptyday;

            Console.SetCursorPosition(40, 5);
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            schedule = SetGymSchedule(ref count, ref top, ref er, ref schedule, ref keyInfo);

            Console.Clear();
            Console.SetCursorPosition(20, 6);
            Console.WriteLine("Set up your Jogging schedule: ");

            schedule = SetJoggingSchedule(ref count, ref top, ref er, ref schedule, ref keyInfo);

            Console.Clear();

            Console.WriteLine();

            Console.SetCursorPosition(25, 7);
            GetHasFlag(schedule);

            Console.ReadKey();
        }

        private static DayOfWeek SetGymSchedule(ref int count, ref int top, ref int er, ref DayOfWeek schedule, ref ConsoleKeyInfo keyInfo)
        {
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D0:
                        schedule |= DayOfWeek.Emptyday;
                        break;
                    case ConsoleKey.D1:
                        schedule |= DayOfWeek.Monday_Gym;
                        break;
                    case ConsoleKey.D2:
                        schedule |= DayOfWeek.Tuesday_Gym;
                        break;
                    case ConsoleKey.D3:
                        schedule |= DayOfWeek.Wednesday_Gym;
                        break;
                    case ConsoleKey.D4:
                        schedule |= DayOfWeek.Thursday_Gym;
                        break;
                    case ConsoleKey.D5:
                        schedule |= DayOfWeek.Friday_Gym;
                        break;
                    case ConsoleKey.D6:
                        schedule |= DayOfWeek.Saturday_Gym;
                        break;
                    case ConsoleKey.D7:
                        schedule |= DayOfWeek.Sunday_Gym;
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

            return schedule;
        }

        private static DayOfWeek SetJoggingSchedule(ref int count, ref int top, ref int er, ref DayOfWeek schedule, ref ConsoleKeyInfo keyInfo)
        {
            keyInfo = Console.ReadKey();

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D0:
                        schedule |= DayOfWeek.Emptyday;
                        break;
                    case ConsoleKey.D1:
                        schedule |= DayOfWeek.Monday_Jogging;
                        break;
                    case ConsoleKey.D2:
                        schedule |= DayOfWeek.Tuesday_Jogging;
                        break;
                    case ConsoleKey.D3:
                        schedule |= DayOfWeek.Wednesday_Jogging;
                        break;
                    case ConsoleKey.D4:
                        schedule |= DayOfWeek.Thursday_Jogging;
                        break;
                    case ConsoleKey.D5:
                        schedule |= DayOfWeek.Friday_Jogging;
                        break;
                    case ConsoleKey.D6:
                        schedule |= DayOfWeek.Saturday_Jogging;
                        break;
                    case ConsoleKey.D7:
                        schedule |= DayOfWeek.Sunday_Jogging;
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

            return schedule;
        }
    }
}
