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
                Equation one = Equation.FindEquation(2, 3);
                one.Solve();

                Console.WriteLine($"X1 = {one.X1}");
            }
            catch (EquationException ex)
            {
                Console.WriteLine($"{ex.Message} \n{ex.HelpLink} \n{ex.TargetSite}");
            }

            Console.ReadKey();
        }
    }
}
