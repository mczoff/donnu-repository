using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_prog1
{
    class LagrangeMethod
    {
        readonly PointF[] _points;
        readonly int _size;

        public LagrangeMethod(PointF[] points, int size)
        {
            _points = points;
            _size = size;
        }

        private double Calculate(double x)
        {
            double lagrangePol = 0;

            for (int i = 0; i < _size; i++)
            {
                double basicsPol = 1;
                for (int j = 0; j < _size; j++)
                    if (j != i)
                        basicsPol *= (x - _points[j].X) / (_points[i].X - _points[j].X);
                    lagrangePol += basicsPol * _points[i].Y;
            }

            return lagrangePol;
        }

        public double Resolve(double x)
            => this.Calculate(x);
    }
}
