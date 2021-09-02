using System;

using EquationLib;

namespace ExceptionSolver
{
    class Program
    {
        static void Main()
        {
            Equation one = Equation.SolveEquation(1, 2, 1);
            one.Run();

            Console.WriteLine($"X1 = {one.X1}");

            Console.ReadKey();
        }
    }
}
