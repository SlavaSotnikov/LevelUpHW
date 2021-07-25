using System;

namespace GeometricShapes
{
    class Program
    {
        static void Main()
        {
            //Point one = new Point(5, 1);
            //UI.ShowPoint(one);

            //Line straight = new Line(15, 20, 30, 40);
            //UI.ShowLine(two);

            Triangle right = new Triangle(5, 10, 30, 30, 5, 30);
            UI.ShowTriangle(right);

            Console.ReadKey();
        }
    }
}
