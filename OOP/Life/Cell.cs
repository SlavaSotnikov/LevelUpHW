using System;

namespace Life
{
    abstract class Cell
    {
        protected Ocean _game;
        protected Coordinate _coord;

        protected char _image;
        protected ConsoleColor _color;

        public abstract char View 
        {
            get; 
        }

        public abstract ConsoleColor Color
        {
            get;
        }

        public abstract new Type GetType();

    }
}
