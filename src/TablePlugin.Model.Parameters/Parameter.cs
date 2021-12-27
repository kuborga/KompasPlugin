using System;

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
        /// Значение параметра
        /// </summary>
        private int _value;

        /// <summary>
        /// Конструктор класса <see cref="Parameter"/>
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="minimum">Минимальное значение</param>
        /// <param name="maximum">Максимальное значение</param>
        /// <param name="value">Значение</param>
        public Parameter(
            int minimum, 
            int maximum,
            int value,
            string name)
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
                    throw new ArgumentException(
                        "Имя параметра не может быть пустым");
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
        public int Minimum { get; set; }

        /// <summary>
        ///  Максимальное значение параметра
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        /// Значение параметра
        /// </summary>
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                if (value < Minimum || value > Maximum)
                {
                    throw new ArgumentException(
                        $"{Name}: размер выходит за диапазон" +
                        $" от {Minimum} до {Maximum} мм.");
                }
            }
        }
    }
}
