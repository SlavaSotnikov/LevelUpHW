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

            //UI.Show(one.GetView());

            //Line myLine = new Line(one, two);
            //UI.Show(myLine.GetPoints());

            //Triangle right = new Triangle(one, two, three);
            //UI.Show(right.GetPoints());
            //right.Move(10, 0);
            //UI.Show(right.GetPoints());

            //Square my = new Square(one, 10);
            //UI.Show(my.GetPoints());
            //my.Move(5, 0);
            //UI.Show(my.GetPoints());

            //Rectangle rec = new Rectangle(one, 25, 5);
            //UI.Show(rec.GetPoints());
            //rec.Move(35, 8);
            //UI.Show(rec.GetPoints());

            //Circle myEl = new Circle(four, 8);
            //UI.Show(myEl.GetPoints());
            //myEl.Move(10, 0);
            //UI.Show(myEl.GetPoints());

            //Trapeze trap = new Trapeze(one, 10, 15, 5);
            //UI.Show(trap.GetPoints());
            //trap.Move(10, 20);
            //UI.Show(trap.GetPoints());

            Point[] po = { new Point(20, 15), new Point(10, 17), new Point(10, 20) };
            PolyLine poly = new PolyLine(one, two, po);
            UI.Show(poly.GetPoints());
            poly.Move(10, 0);
            UI.Show(poly.GetPoints());

            //Picture pic = new Picture();
            //pic.AddPicture(pl);
            //pic.AddPicture(tr);
            //pic.AddPicture(myEl);
            //pic.AddPicture(myLine);
            //pic.Move(2, 2);


            Console.ReadKey();
        }
    }
}
