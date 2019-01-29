using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCode1
{
    public class Triangle
    {
        double _a;
        double _b;
        double _c;

        public Triangle()
        {

        }

        public Triangle(double a, double b, double c)
        {
            this.ValidateSides(a, b, c);

            _a = a;
            _b = b;
            _c = c;
        }

        public void SetSides(double a, double b, double c)
        {
            this.ValidateSides(a, b, c);

            _a = a;
            _b = b;
            _c = c;
        }

        public double Area()
        {
            double p = (_a + _b + _c) / 2;
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }

        private void ValidateSides(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new FormatException("Sides have negative value");

            if (a + b < c || a + c < b || b + c < a)
                throw new ArgumentException("Triangle isnt be in area");
        }
    }
}
