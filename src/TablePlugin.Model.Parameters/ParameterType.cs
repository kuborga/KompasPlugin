using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin.Model.Parameters
{
    /// <summary>
    /// Перечисление параметров стола
    /// </summary>
   public enum ParameterType
    {
        /// <summary>
        /// Длина столешницы
        /// </summary>
        TableTopLength,

        /// <summary>
        /// Ширина столешницы
        /// </summary>
        TableTopWidth,

        /// <summary>
        /// Высота столешницы
        /// </summary>
        TableTopHeight,

        /// <summary>
        /// Высота ножек стола
        /// </summary>
        TableLegsHeight,

        /// <summary>
        /// Диаметр (основания) ножек стола
        /// </summary>
        TableLegsDiameter,
    }
}
