using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin.Model.Parameters
{
    /// <summary>
    /// Класс параметров стола
    /// </summary>
   public class TableParameters
    {
        /// <summary>
        /// Длина столешницы
        /// </summary>
        private Parameter _topLength;

        /// <summary>
        /// Ширина столешницы
        /// </summary>
        private Parameter _topWidth;

        /// <summary>
        /// Высота столешницы
        /// </summary>
        private Parameter _topHeight;

        /// <summary>
        /// Диаметр ножек стола
        /// </summary>
        private Parameter _legsDiameters;

        /// <summary>
        /// Высота ножек стола
        /// </summary>
        private Parameter _legsHeight;

        /// <summary>
        /// Конструктор класса TableParameters
        /// </summary>
        /// <param name="topLength">Длина столешницы</param>
        /// <param name="topWidth">Ширина столешницы</param>
        /// <param name="topHeight">Высота столешницы</param>
        /// <param name="legsDiameters">Диаметр ножек стола</param>
        /// <param name="legsHeight">Длина ножек</param>
        public TableParameters(double topLength, double topWidth, double topHeight,
            double legsDiameters, double legsHeight) 
        {
            TopLength = new Parameter("Длина столешницы", 400, 800, topLength);
            TopWidth = new Parameter("Ширина столешницы", 400, 800, topWidth);
            TopHeight = new Parameter("Высота столешницы", 20, 80, topHeight);
            LegsDiameters = new Parameter("Диаметр ножек стола", 50, 200, legsDiameters);
            LegsHeight = new Parameter("Высота ножек стола", 400, 700, legsHeight);
        }

        /// <summary>
        /// Длина столешницы
        /// </summary>
        public Parameter TopLength 
        {
            get => _topLength;
            set
            {
                _topLength = value;
            }
        }

        /// <summary>
        /// Ширина столешницы
        /// </summary>
        public Parameter TopWidth 
        {
            get => _topWidth;
            set
            {
                _topWidth = value;
            }
        }

        /// <summary>
        /// Высота столешницы
        /// </summary>
        public Parameter TopHeight 
        {
            get => _topHeight;
            set
            {
                _topHeight = value;
            }
        }

        /// <summary>
        /// Диаметр ножек стола
        /// </summary>
        public Parameter LegsDiameters 
        { 
            get=> _legsDiameters; 
            set
            {
                double maximumValueLegs = (Math.Max(TopWidth.Value, TopLength.Value)) / 3;
                if(value.Value >= (TopWidth.Value / 3) || value.Value >= (TopLength.Value / 3))
                {
                    throw new ArgumentException($"- {value.Name} должен быть  меньше " +
                        $"{Math.Truncate(maximumValueLegs)} мм относительно параметра "
                        + $" {TopWidth.Name} и {TopLength.Name} ");
                }
                else
                {
                    _legsDiameters = value;
                }
            }
        }

        /// <summary>
        /// Высота ножек стола
        /// </summary>
        public  Parameter LegsHeight 
        {
            get => _legsHeight;
            set
            {
                _legsHeight = value;
            }
        }

    }
}
