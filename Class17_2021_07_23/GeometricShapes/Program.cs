using System;

namespace GeometricShapes
{
    class Program
    {
        static void Main()
        {
            Point one = new Point(5, 10);
            UI.ShowPoint(one);

            Point two = new Point(30, 30);
            UI.ShowPoint(one);

            Point three = new Point(5, 30);
            UI.ShowPoint(one);

            Line straight = new Line(one, two);
            UI.ShowLine(straight);

            Triangle right = new Triangle(one, two, three);
            UI.ShowTriangle(right);

            //Circle ellipse = new Circle(one, 10);
            //UI.ShowCircle(ellipse);

            Console.ReadKey();
        }
    }
}
