using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin.Model.Parameters
{

    class TableParameters
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
        /// Длина ножек стола
        /// </summary>
        private Parameter _legsLength;

        /// <summary>
        /// Конструктор класса TableParameters
        /// </summary>
        /// <param name="topLength">Длина столешницы</param>
        /// <param name="topWidth">Ширина столешницы</param>
        /// <param name="topHeight">Высота столешницы</param>
        /// <param name="legsDiameters">Диаметр ножек стола</param>
        /// <param name="legsLength">Длина ножек</param>
        public TableParameters(double topLength, double topWidth, double topHeight,
            double legsDiameters, double legsLength) 
        {
            TopLength = new Parameter("Длина столешницы", 400, 800, topLength);
            TopWidth = new Parameter("Ширина столешницы", 400, 800, topWidth);
            TopHeight = new Parameter("Высота столешницы", 20, 80, topHeight);
            LegsDiameters = new Parameter("Диаметр ножек стола", 50, 200, legsDiameters);
            LegsLength = new Parameter("Длина ножек стола", 400, 700, legsLength);
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
                if(value.Value >= (TopWidth.Value / 3) || value.Value >= (TopLength.Value / 3))
                {
               // TODO: поправить;
                    throw new ArgumentException($" ошибка зависимых параметров ");
                }
                else
                {
                    _legsDiameters = value;
                }
            }
        }

        /// <summary>
        /// Длина ножек стола
        /// </summary>
        public Parameter LegsLength 
        {
            get => _legsLength;
            set
            {
                _legsLength = value;
            }
        }

    }
}
