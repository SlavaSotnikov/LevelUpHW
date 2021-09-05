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
                Equation one = Utilits.FindEquation(1, -6);

                Console.WriteLine($"Roots: {one.RootsCount}");
                Console.ReadLine();

                Console.WriteLine($"X1 = {one[1]} X2 = {one[2]}");
                
            }
            catch (EquationException ex)
            {
                Console.WriteLine($"{ex.Message} \n{ex.HelpLink} \n{ex.TargetSite}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} \n{ex.HelpLink} \n{ex.TargetSite}");
            }

            Console.ReadKey();
        }
    }
}
