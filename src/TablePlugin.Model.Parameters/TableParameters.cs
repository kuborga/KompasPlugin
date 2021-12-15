using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        /// Словарь параметров класса <see cref="TableParameters"/>
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _parameters =
            new Dictionary<ParameterType, Parameter>
            {
                { ParameterType.TableTopLength,
                    new Parameter(400,800,600, "Длина столешницы")},
                { ParameterType.TableTopWidth,
                    new Parameter(400,800,600, "Ширина столешницы")},
                { ParameterType.TableTopHeight,
                    new Parameter(20,80,60, "Высота столешницы")},
                { ParameterType.TableLegsDiameter,
                    new Parameter(50,200,125,"Высота ножек стола")},
                { ParameterType.TableLegsHeight,
                    new Parameter(400,700,550, "Диаметр ножек стола")},
            };

        /// <summary>
        /// Конструктор класс <see cref="TableParameters"/> без параметров
        /// </summary>
        public TableParameters()
        { }

        /// <summary>
        /// Установить значение параметра
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <param name="value">Значение параметра</param>
        public void SetValue(ParameterType parameterType, double value)
        {
            _parameters[parameterType].Value = value;

            if (parameterType == ParameterType.TableTopHeight 
                || parameterType == ParameterType.TableLegsHeight)
            {
                CheckingFullHeightTable();
            }

            if (parameterType == ParameterType.TableLegsDiameter
                || parameterType == ParameterType.TableTopLength
                || parameterType == ParameterType.TableTopHeight)
            {
                CheckingDiameterTableLegs();
            }
        }

        /// <summary>
        /// Получить значение параметра
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <returns>Значение параметра</returns>
        public double GetValue(ParameterType parameterType)
        {
            return _parameters[parameterType].Value;
        }

        /// <summary>
        /// Проверка общей высоты стола
        /// </summary>
        private void CheckingFullHeightTable()
        {
             var tableTopHeightName = _parameters[ParameterType.TableTopHeight].Name;
             var tableLegHeightName = _parameters[ParameterType.TableLegsHeight].Name;
    
            var fullHeightTable = _parameters[ParameterType.TableTopHeight].Value
                + _parameters[ParameterType.TableLegsHeight].Value;
            if (fullHeightTable < 440)
            {
                string textError = $"Общая высота стола( " + $"{tableTopHeightName} " 
                                 + $"+ {tableLegHeightName} ) "
                                 + $"должна быть больше либо равна 440 мм";
                throw new ArgumentException(textError);
            }
        }

        /// <summary>
        /// Проверка для диаметра оснований ножек стола
        /// </summary>
        private void CheckingDiameterTableLegs()
        {
            var tableTopLenght = _parameters[ParameterType.TableTopLength].Value;
            var tableTopWidth = _parameters[ParameterType.TableTopWidth].Value;


            var valueLegsDiameter = _parameters[ParameterType.TableLegsDiameter].Value;

            var nameTableTopLenght = _parameters[ParameterType.TableTopLength].Name;
            var nameTableTopWidth = _parameters[ParameterType.TableTopWidth].Name;
            var nameLegsDiameter = _parameters[ParameterType.TableLegsDiameter].Name;
            
            if (valueLegsDiameter >= (tableTopLenght / 3.0) 
                || valueLegsDiameter >= (tableTopWidth / 3.0) )
            { 
            string textError = $"{nameLegsDiameter} должна быть меньше 1/3 значений"
                           +$" относительно параметра  {nameTableTopLenght}"
                           + " и " + $"{nameTableTopWidth}";
                throw new ArgumentException(textError);
            }
        }

    }
}