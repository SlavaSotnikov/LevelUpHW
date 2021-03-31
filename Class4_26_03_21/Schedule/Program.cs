using System;

namespace Schedule
{
    class Program
    {
        static void Main()
        {
            string password = String.Empty;
            int count = -1;
            byte schedule = 0;
            const byte EMPTYSCHEDULE = (byte)0x00;
            const byte MONDAY = (byte)0x01;     //gym on Monday
            const byte TUESDAY = (byte)0x02;    //gym on Tuesday
            const byte WEDNESDAY = (byte)0x04;  //gym on Wednesday
            const byte THURSDAY = (byte)0x08;   //gym on Thursday
            const byte FRIDAY = (byte)0x10;     //gym on Friday
            const byte SATURDAY = (byte)0x20;   //gym on Saturday
            const byte SUNDAY = (byte)0x40;     //gym on Sunday

            schedule = EMPTYSCHEDULE;

            while (password != "q")
            {
                schedule = EMPTYSCHEDULE;
                char weekDay = ' ';
                Console.WriteLine("Set up your gym schedule: ");
                Console.WriteLine("1-Mon  2-Tue  3-Wed  4-Thu  5-Fri  6-Sat  7-Sun");

                weekDay = Console.ReadKey().KeyChar;

                while (weekDay != '0')
                {
                    switch (weekDay)
                    {
                        case '1':
                            schedule = (byte)(schedule | MONDAY);
                            break;
                        case '2':
                            schedule = (byte)(schedule | TUESDAY);
                            break;
                        case '3':
                            schedule = (byte)(schedule | WEDNESDAY);
                            break;
                        case '4':
                            schedule = (byte)(schedule | THURSDAY);
                            break;
                        case '5':
                            schedule = (byte)(schedule | FRIDAY);
                            break;
                        case '6':
                            schedule = (byte)(schedule | SATURDAY);
                            break;
                        case '7':
                            schedule = (byte)(schedule | SUNDAY);
                            break;
                        case '0':
                            Console.WriteLine("Exit");
                            break;
                        default:
                            Console.WriteLine("\n" + "You should use only 1-7 keys. Try again, please.");
                            break;
                    }

                    count++;
                    if (count >= 0)
                    {
                        Console.Write("\n" + "Next day: ");
                        weekDay = Console.ReadKey().KeyChar;
                    }
                }

                Console.Clear();

                Console.WriteLine();


                if ((schedule & MONDAY) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("MONDAY   " + "\t");
                }
                else
                {
                    Console.Write("Monday   " + "\t");
                }
                if ((schedule & TUESDAY) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("TUESDAY  " + "\t");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("Tuesday  " + "\t");
                }
                if ((schedule & WEDNESDAY) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("WEDNESDAY" + "\t");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("Wednesday" + "\t");
                }
                if ((schedule & THURSDAY) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("THURSDAY " + "\t");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("Thursday " + "\t");
                }
                if ((schedule & FRIDAY) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("FRIDAY   " + "\t");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("Friday   " + "\t");
                }
                if ((schedule & SATURDAY) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("SATURDAY " + "\t");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("Saturday " + "\t");
                }
                if ((schedule & SUNDAY) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("SUNDAY   " + "\t");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine("Sunday   " + "\t");
                }
                Console.WriteLine();

                
                do
                {
                    Console.ResetColor();
                    Console.Write("If you want to change the schedule please enter a password or quit(q): ");
                    password = Console.ReadLine();

                    if (password == "123456")
                    {
                        Console.Write("Welcome! ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"This '{password}' password is incorrect, try again.");
                    }
                    if (password.ToLower() == "q")
                    {
                        break;
                    }

                } while (password != "123456");

                Console.Clear();
            }
        }
    }
}
