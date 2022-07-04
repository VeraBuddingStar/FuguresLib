using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    /// <summary>
    /// При изменении радиуса, площадь пересчитывается автоматически
    /// </summary>
    public class Circle: Figure
    {
        private double _radius;
        public double Radius
        {
            get => _radius;
            set => base.Update(ref _radius, value, (value) => SetValidate(value));
        }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateSquare() => Math.Round(Math.PI * Math.Pow(Radius, 2), 3);

        /// <summary>
        /// Валидация значения, перед записью в свойство
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected double SetValidate(double value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(ExceptionMessage.ExceptionRadiusMinus);
            return value;
        }

    }

}
 