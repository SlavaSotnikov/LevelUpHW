using System;

using EquationLib;

namespace ExceptionSolver
{
    class Program
    {
        static void Main()
        {
            try
            {
                Equation one = Utilits.FindEquation(2, -6);

                one['A'] = 0;
                one['B'] = 1;

                switch (one.RootsCount)
                {
                    case Roots.One:
                        Console.WriteLine($"X1 = {one[1]}");
                        break;
                    case Roots.Two:
                        Console.WriteLine($"X1 = {one[1]} X2 = {one[2]}");
                        break;
                    default:
                        Console.WriteLine("Something goes wrong!");
                        break;
                }
            }
            catch (EquationException ex)
            {
                Console.WriteLine($"{ex.Message} \n{ex.HelpLink} \n{ex.TargetSite}" +
                    $"\n{ex.Describing}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} \n{ex.HelpLink} \n{ex.TargetSite}");
            }

            Console.ReadKey();
        }
    }
}
