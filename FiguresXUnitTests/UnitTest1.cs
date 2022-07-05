using Xunit;
using Figures;
using System;

namespace FiguresXUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Circle()
        {
            var circle = new Circle(3.2);
            Assert.Equal(32.17, circle.Square);

            circle.Radius = 4.6; // меняем параметр фигуры
            Assert.Equal(66.476, circle.Square);
        }

        [Fact]
        public void Triangle()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.Equal(6, triangle.Square);
            Assert.True(triangle.IsRightAngled);

            triangle.SideB = 5; // меняем параметр фигуры
            Assert.Equal(7.155, triangle.Square);
            Assert.False(triangle.IsRightAngled);
        }

        [Fact]
        // Вычисление площади фигуры без знания типа фигуры в compile-time
        public void CalculateSquareAtCompileTime()
        {
            var circle = new Circle(3.2);
            Assert.Equal(32.17, circle.CalculateSquareAtCompileTime());

            var triangle = new Triangle(3, 4, 5);
            Assert.Equal(6, triangle.CalculateSquareAtCompileTime());

        }

        [Fact]
        public void NegativeFigureValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(3, -3, 5));
        }
    }
}