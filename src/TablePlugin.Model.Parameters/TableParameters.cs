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
        /// Длина ножек
        /// </summary>
        private Parameter _legsLength;

        // бахнуть тут конструктор

        /// <summary>
        /// Длина столешницы
        /// </summary>
        public Parameter TopLength 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Ширина столешницы
        /// </summary>
        public Parameter TopWidth { get; set; }

        /// <summary>
        /// Высота столешницы
        /// </summary>
        public Parameter TopHeight { get; set; }

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
        /// Длина ножек
        /// </summary>
        public Parameter legsLength { get; set; }

    }
}
