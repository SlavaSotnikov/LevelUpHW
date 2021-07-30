using System;

namespace GeometricShapes
{
    class Program
    {
        static void Main()
        {
            Point one = new Point(12, 1);
            Point two = new Point(12, 10); 
            Point three = new Point(25, 1);
            Point four = new Point(22, 10);

            //Line myLine = new Line(one, two);
            //UI.Show(BL.GetPoints(myLine));
            //myLine.Move(0, 4);
            //UI.Show(BL.GetPoints(myLine));

            //Triangle right = new Triangle(one, two, three);
            //UI.Show(BL.GetPoints(right));
            //right.Move(12, 0);
            //UI.Show(BL.GetPoints(right));

            //Square my = new Square(one, 10);
            //UI.Show(BL.GetPoints(my));
            //my.Move(5, 0);
            //UI.Show(BL.GetPoints(my));

            //Rectangle rec = new Rectangle(one, 25, 5);
            //UI.Show(BL.GetPoints(rec));
            //rec.Move(35, 8);
            //UI.Show(BL.GetPoints(rec));

            //Circle myEl = new Circle(four, 10);
            //UI.DrawCircle(myEl);
            //myEl.Move(10, 0);
            //UI.DrawCircle(myEl);

            //Trapeze tr = new Trapeze(one, 10, 15, 5);
            //UI.Show(BL.GetPoints(tr));
            //tr.Move(0, 20);
            //UI.Show(BL.GetPoints(tr));

            Point[] po = { new Point(20, 15), new Point(10, 17), new Point(10, 20) };
            PolyLine pl = new PolyLine(one, two, po);
            UI.Show(BL.GetPoints(pl));
            pl.Move(5, 0);
            UI.Show(BL.GetPoints(pl));

            Console.ReadKey();
        }
    }
}
