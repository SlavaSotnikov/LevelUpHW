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
                Equation one = Equation.FindEquation(1, 2, 1);
                one.Solve();

                if (one is Linear lin)
                {
                    Console.WriteLine($"X1 = {lin.X1}");
                }

                if (one is Quadratic qu)
                {
                    Console.WriteLine($"X1 = {qu.X1} \nX2 = {qu.X2}");
                }
                
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
