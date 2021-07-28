using System;

namespace GeometricShapes
{
    class BL
    {
        public static Point[] GetPoints(Square source)
        {
            Point[] result = new Point[5];

            result[0] = new Point(source.CoordinateX, source.CoordinateY);
            result[1] = new Point(source.CoordinateX + source.Side, source.CoordinateY);
            result[2] = new Point(source.CoordinateX + source.Side, source.CoordinateY + source.Side);
            result[3] = new Point(source.CoordinateX, source.CoordinateY + source.Side);
            result[4] = new Point(source.CoordinateX, source.CoordinateY);


            return result;
        }
    }
}
