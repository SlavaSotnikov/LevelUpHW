using System;

namespace MoveShip
{
    struct Spacecraft
    {
        public string[] view;
        public int сoordinateX;
        public int сoordinateY;
        public int oldCoordinateX;
        public int oldCoordinateY;
        public bool alive;
        public byte hitPoints;
        public byte life;
    }
}
