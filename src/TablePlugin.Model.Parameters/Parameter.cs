using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin.Model.Parameters
{
    /// <summary>
    /// Класс  дополнительных параметров журнального столика
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Имя параметра
        /// </summary>
        private string _name;

        /// <summary>
        /// Минимальное значение параметра
        /// </summary>
        private double _minimum;

        /// <summary>
        /// Максимальное значение параметра
        /// </summary>
        private double _maximum;

        /// <summary>
        /// Значение параметра
        /// </summary>
        private double _value;

        /// <summary>
        /// Конструктор класса Параметр
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="minimum">Минимальное значение</param>
        /// <param name="maximum">Максимальное значение</param>
        /// <param name="value">Значение</param>
        public Parameter(string name, double minimum, double maximum, double value)
        {
            Name = name;
            Minimum = minimum;
            Maximum = maximum;
            Value = value;
        }

        /// <summary>
        /// Название параметра
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Минимальное значение параметра
        /// </summary>
        public double Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
            }
        }

        /// <summary>
        ///  Максимальное значение параметра
        /// </summary>
        public double Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
            }
        }

        /// <summary>
        /// Значение параметра
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

    }
}
