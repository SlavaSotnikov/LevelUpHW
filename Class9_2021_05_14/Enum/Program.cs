using System;

namespace Enum
{
    class Program
    {
        

        static void Main()
        {
            MonthsOfYear month = MonthsOfYear.None;

            Console.WriteLine("Enter month's number: ? ");
            string value = Console.ReadLine();

            if (System.Enum.TryParse(value, out month))
            {
                switch (month)
                {
                    case MonthsOfYear.None:
                        break;
                    case MonthsOfYear.January:
                        break;
                    case MonthsOfYear.Fabruary:
                        break;
                    case MonthsOfYear.March:
                        break;
                    case MonthsOfYear.April:
                        break;
                    case MonthsOfYear.May:
                        break;
                    case MonthsOfYear.June:
                        break;
                    case MonthsOfYear.July:
                        break;
                    case MonthsOfYear.August:
                        break;
                    case MonthsOfYear.September:
                        break;
                    case MonthsOfYear.October:
                        break;
                    case MonthsOfYear.November:
                        break;
                    case MonthsOfYear.December:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("This value doesn't exist.");
            }
            

            Console.WriteLine(month);
            Console.ReadKey();
        }
    }
}
