﻿using System;

using EquationLib;

namespace Exceptions
{
    class Program
    {
        static void Main()
        {
            try
            {
                QuadraticEquation one = new QuadraticEquation(1, 2, 1);
                one.Run();

                Console.WriteLine($"X1 = {one.X1}, X2 = {one.X2}");    // TODO: Just add the second root.
            }
            catch (FactorArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}, \n{ex.StackTrace}");
            }
            catch (FieldAccessException ex)
            {
                Console.WriteLine($"{ex.Message}, \n{ex.StackTrace}");
            }
            Console.ReadKey();
        }
    }
}
