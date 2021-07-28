using System;

namespace GeometricShapes
{
    class Program
    {
        static void Main()
        {
            Point one = new Point(12, 1);
            //UI.Print(one);

            Point two = new Point(12, 10); 
            //UI.Print(one);

            Point three = new Point(25, 1);
            //UI.Print(one);

            //Line myLine = new Line(one, two);
            //myLine.Move(2, 4);
            //UI.Show(myLine);

            //Triangle right = new Triangle(one, two, three);
            //UI.Show(right);

            //Square my = new Square(one, 10);
            //UI.Show(BL.GetPoints(my));

            //Circle ellipse = new Circle(one, 10);
            //UI.ShowCircle(ellipse);

            Trapeze tr = new Trapeze(one, two, 5, 10);
            UI.Show(tr);

            Console.ReadKey();
        }
    }
}
