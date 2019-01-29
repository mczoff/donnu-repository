using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProductionCode1;

namespace ProductionCode.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void ThrowsFormatExceptionIsNegativeSideInContructor()
        {
            Assert.Throws<FormatException>(() => 
            {
                Triangle triangle = new Triangle(2, -1, 7);
            });
        }

        [Test]
        public void ThrowsFormatExceptionIsNegativeSideInMethod()
        {
            Triangle triangle = new Triangle();

            Assert.Throws<FormatException>(() =>
            {
                triangle.SetSides(2, -12, 2);
            });
        }

        [Test]
        public void ThrowsArgumentExceptionIsUnrealTriangeInContructor()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Triangle triangle = new Triangle(2, 7, 60);
            });
        }

        [Test]
        public void ThrowsArgumentExceptionIsUnrealTriangeInMethod()
        {
            Triangle triangle = new Triangle();

            Assert.Throws<ArgumentException>(() =>
            {
                triangle.SetSides(2, 5, 20);
            });
        }

        [Test]
        public void TriangeWithSides_5_5_6_Return_12()
        {
            Triangle triangle = new Triangle();

            triangle.SetSides(5, 5, 6);
            double square = triangle.Area();

            Assert.AreEqual(square, 12);
        }
    }
}
