using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEnum
{
    class Program
    {
        static void Main()
        {
            Direction d = Direction.None;

            Console.WriteLine("Enter direction: ? ");
            string sDirect = Console.ReadLine();

            if (System.Enum.TryParse(sDirect, out d))
            {
                switch (d)
                {
                    case Direction.None:
                        break;
                    case Direction.Left:
                        Console.WriteLine("Lf");
                        break;
                    case Direction.Top:
                        Console.WriteLine("Rt");
                        break;
                    case Direction.Right:
                        Console.WriteLine("Top");
                        break;
                    case Direction.Bottom:
                        Console.WriteLine("Bottom");
                        break;
                    default:
                        break;
                }

                Console.WriteLine("d: {0} , (int)d: {1}", d, (int)d);
            }
            else
            {
                Console.WriteLine("Error!!!");
            }

            Console.ReadKey();
        }
    }
}
