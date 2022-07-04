using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public abstract class Figure
    {
        #region Общие параметры фигур
        private double _square;
        public double Square
        {
            get => GetValidate(ref _square, new Func<double>(() => CalculateSquare()));
        }
        #endregion

        /// <summary>
        /// Список пересчитанных параметров
        /// </summary>
        private HashSet<object> changeValues = new HashSet<object>();

        /// <summary>
        /// Вызываем при изменении свойства фигуры
        /// </summary>
        protected void Update<T>(ref T _value, T value, Func<T, T> action)
        {
            _value = action(value);
            changeValues.Clear();
        }

        /// <summary>
        /// Валидация значений, на метод доступа GET
        /// </summary>
        /// <param name="_value"></param>
        /// <param name="action"> метод пересчета свойства </param>
        /// <returns></returns>
        protected T GetValidate<T>(ref T _value, Func<T> action)
        {
            if (!changeValues.Contains(_value) || _value == null)
            {
                _value = action();
                changeValues.Add(_value);
            }
            return _value;
        }

        #region abstract

        /// <summary>
        /// Вычисление площади
        /// </summary>
        public abstract double CalculateSquare();

        #endregion
    }
}
