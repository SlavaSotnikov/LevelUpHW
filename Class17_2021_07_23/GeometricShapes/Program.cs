using System;

namespace GeometricShapes
{
    class Program
    {
        static void Main()
        {
            //Point one = new Point(5, 1);
            //Console.ForegroundColor = ConsoleColor.Red;
            //UI.ShowPoint(one);
            //Console.ResetColor();

            //Line two = new Line(15, 20, 30, 40);
            //UI.ShowLine(two);



            Triangle three = new Triangle(5, 10, 30, 30, 5, 30);
            UI.ShowTriangle(three);

            Console.ReadKey();
        }
    }
}
