using System;

namespace GeometricShapes
{
    class Picture
    {
        private Figure[] _figures;
        private int _amountOfFigures;

        public Picture(int capacity = 10)
        {
            _figures = new Figure[capacity];
            _amountOfFigures = 0;
        }

        public void AddPicture(Figure source)
        {
            if (_amountOfFigures >= _figures.Length)
            {
                Array.Resize(ref _figures, _figures.Length * 2);
            }

            _figures[_amountOfFigures] = source;
            ++_amountOfFigures;
        }

        public double GetArea()
        {
            double result = 0;

            for (int i = 0; i < _amountOfFigures; i++)
            {
                if (_figures[i] is IGeometrical res)
                {
                    result += res.GetArea();
                }
            };

            return result;
        }

        public double GetPerimeter()
        {
            double result = 0;

            for (int i = 0; i < _amountOfFigures; i++)
            {
                if (_figures[i] is IGeometrical res)
                {
                    result += res.GetPerimeter();
                }
            };

            return result;
        }

        public void Move(int deltaX, int deltaY)
        {
            for (int i = 0; i < _amountOfFigures; i++)
            {
                _figures[i].Move(deltaX, deltaY);
            }
        }

        public void Resize(double mult)
        {
            for (int i = 0; i < _amountOfFigures; i++)
            {
                _figures[i].Resize(mult);
            }
        }

        public void Show()
        {
            for (int i = 0; i < _amountOfFigures; i++)
            {
                UI.Show(_figures[i].GetPoints());
            }
        }
    }
}
