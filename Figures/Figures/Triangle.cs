using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    /// <summary>
    /// -: 
    ///     Нет проверки, что это действительно треугольник
    /// +: 
    ///     можно менять параметры фигуры, остальные показатели будут пересчитываться автоматически
    /// </summary>
    public class Triangle : Figure
    {
        #region params

        #region sides
        private double _sideA, _sideB, _sideC;
        public double SideA
        {
            get => _sideA;
            set => base.Update(ref _sideA, value, (value) => SetValidate(value));
        }
        public double SideB
        {
            get => _sideB;
            set => base.Update(ref _sideB, value, (value) => SetValidate(value));
        }
        public double SideC
        {
            get => _sideC;
            set => base.Update(ref _sideC, value, (value) => SetValidate(value));
        }
        #endregion

        private bool _isRightAngled = false;

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        public bool IsRightAngled {
            get => GetValidate(ref _isRightAngled, () => CheckIsRightAngled());
        }

        #endregion

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }
        public override double CalculateSquare()
        {
            var semiPerimeter = (SideA + SideB + SideC) / 2d;
            return Math.Round(Math.Sqrt(
                semiPerimeter
                * (semiPerimeter - SideA)
                * (semiPerimeter - SideB)
                * (semiPerimeter - SideC)
            ), 3);
        }

        /// <summary>
        /// Прямоугольный
        /// </summary>
        /// <returns></returns>
        public bool CheckIsRightAngled()
        {
            /// с2 = a2 + b2 (Пифагор), где с - наибольшая сторона
            var sideArray = new double[] { SideA, SideB, SideC };
            Array.Sort(sideArray); Array.Reverse(sideArray);
            return Math.Pow(sideArray[0], 2) == Math.Pow(sideArray[1], 2) + Math.Pow(sideArray[2], 2);
        }

        /// <summary>
        /// Валидация значения, перед записью в свойство
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected double SetValidate(double value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(ExceptionMessage.ExceptionSideMinus);
            return value;
        }

    }
}
