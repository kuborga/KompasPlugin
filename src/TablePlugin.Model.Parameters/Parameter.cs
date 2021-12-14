using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin.Model.Parameters
{
    /// <summary>
    /// Класс  дополнительных параметров стола
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
        /// Конструктор класса Parameter
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="minimum">Минимальное значение</param>
        /// <param name="maximum">Максимальное значение</param>
        /// <param name="value">Значение</param>
        public Parameter(double minimum, double maximum, double value,string name)
        {
            Minimum = minimum;
            Maximum = maximum;
            Value = value;
            Name = name;
        }

        /// <summary>
        /// Название параметра
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Имя параметра не может быть пустым");
                }
                else
                {
                    _name = value;
                }
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
                if (value < Minimum || value > Maximum)
                {
                    throw new ArgumentException($"{Name}: размер выходит за диапазон" +
                        $" от {Minimum} до {Maximum} мм");
                }
                else
                {
                    _value = value;
                }


            }
        }
    }
}
