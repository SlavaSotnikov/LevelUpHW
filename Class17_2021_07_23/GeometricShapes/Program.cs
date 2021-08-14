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
            Point four = new Point(12, 30);
            Point five = new Point(12, 14);
            Point six = new Point(12, 40);

            //UI.Show(one.GetView());

            //Line myLine = new Line(one, two);
            //UI.Show(myLine.GetPoints());

            //Triangle right = new Triangle(one, two, three);
            //UI.Show(right.GetPoints());
            //right.Move(10, 0);
            //UI.Show(right.GetPoints());

            Square sq = new Square(one, 10);
            //UI.Show(my.GetPoints());
            //my.Move(5, 0);
            //my.Resize(2);
            //UI.Show(my.GetPoints());

            Rectangle rect = new Rectangle(five, 25, 5);
            //UI.Show(rec.GetPoints());
            //rec.Move(35, 8);
            //rec.Resize(2);
            //UI.Show(rec.GetPoints());

            Circle circ = new Circle(four, 8);
            //UI.Show(myEl.GetPoints());
            //myEl.Move(10, 0);
            //myEl.Resize(2);
            //UI.Show(myEl.GetPoints());

            Trapeze trap = new Trapeze(six, 10, 15, 5);
            //UI.Show(trap.GetPoints());
            //trap.Move(10, 20);
            //trap.Resize(2);
            //UI.Show(trap.GetPoints());

            //Point[] po = { new Point(20, 15), new Point(10, 17), new Point(10, 20) };
            //PolyLine poly = new PolyLine(one, two, po);
            //UI.Show(poly.GetPoints());
            //poly.Move(10, 0);
            //UI.Show(poly.GetPoints());

            Picture pic = new Picture();
            pic.AddPicture(sq);
            pic.AddPicture(rect);
            pic.AddPicture(circ);
            pic.AddPicture(trap);
            pic.Show();

            pic.Move(30, 0);

            pic.Resize(0.5);
            pic.Show();

            UI.Print("Perimeter", pic.GetPerimeter(), 5);
            UI.Print("Area", pic.GetArea(), 40);

            Console.ReadKey();
        }
    }
}