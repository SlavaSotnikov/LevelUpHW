using System;

namespace GeometricShapes
{
    class BL
    {
        //public static Point[] GetPoints(Line source)
        //{
        //    Point[] result = new Point[2];

        //    result[0] = new Point(source.CoordinateX, source.CoordinateY);
        //    result[1] = new Point(source.Coordinate2X, source.Coordinate2Y);

        //    return result;
        //}

        public Point[] GetPoints(Square source)
        {
            Point[] result = new Point[5];

            result[0] = new Point(source.CoordinateX, source.CoordinateY);
            result[1] = new Point(source.CoordinateX + source.Wide, source.CoordinateY);
            result[2] = new Point(source.CoordinateX + source.Wide, source.CoordinateY + source.Wide);
            result[3] = new Point(source.CoordinateX, source.CoordinateY + source.Wide);
            result[4] = new Point(source.CoordinateX, source.CoordinateY);

            return result;
        }

        public static Point[] GetPoints(Trapeze source)
        {
            Point[] result = new Point[5];

            result[0] = new Point(source.CoordinateX, source.CoordinateY);
            result[1] = new Point(source.CoordinateX + source.Wide, source.CoordinateY);
            result[2] = new Point(source.CoordinateX + source.Wide, source.CoordinateY + source.Ground);
            result[3] = new Point(source.CoordinateX, source.CoordinateY + source.Height);
            result[4] = new Point(source.CoordinateX, source.CoordinateY);

            return result;
        }

        public static Point[] GetPoints(Triangle source)
        {
            Point[] result = new Point[4];

            result[0] = new Point(source.CoordinateX, source.CoordinateY);
            result[1] = new Point(source.Coordinate2X, source.Coordinate2Y);
            result[2] = new Point(source.Coordinate3X, source.Coordinate3Y);
            result[3] = new Point(source.CoordinateX, source.CoordinateY);

            return result;
        }

        public static Point[] GetPoints(Rectangle source)
        {
            Point[] result = new Point[5];

            result[0] = new Point(source.CoordinateX, source.CoordinateY);
            result[1] = new Point(source.CoordinateX + source.Wide, source.CoordinateY);
            result[2] = new Point(source.CoordinateX + source.Wide, source.CoordinateY + source.Height);
            result[3] = new Point(source.CoordinateX, source.CoordinateY + source.Height);
            result[4] = new Point(source.CoordinateX, source.CoordinateY);

            return result;
        }

        //public static Point[] GetPoints(PolyLine source)
        //{
        //    Point[] result = new Point[source.AmountOfPoints];

        //    result[0] = new Point(source.CoordinateX, source.CoordinateY);
        //    result[1] = new Point(source.Coordinate2X, source.Coordinate2Y);

        //    for (int i = 2; i < source.AmountOfPoints; i++)
        //    {
        //        result[i] = source[i - 2];
        //    }

        //    return result;
        //}
    }
}
