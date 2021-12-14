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
        /// Словарь параметров класса <see cref="TableParameters"/>
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _parameters =
            new Dictionary<ParameterType, Parameter>
            {
                { ParameterType.TableTopLength,new Parameter(400,800,600)},
                { ParameterType.TableTopWidth,new Parameter(400,800,600)},
                { ParameterType.TableTopHeight,new Parameter(20,80,60)},
                { ParameterType.TableLegsDiameter,new Parameter(50,200,125)},
                { ParameterType.TableLegsHeight,new Parameter(400,700,550)},
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
            var minValue = _parameters[parameterType].Minimum;
            var maxValue = _parameters[parameterType].Maximum;

            switch (parameterType)
            {
                case ParameterType.TableTopLength:
                    break;
                case ParameterType.TableTopWidth:
                    break;
                case ParameterType.TableTopHeight:
                    break;
                case ParameterType.TableLegsHeight:
                    break;
                case ParameterType.TableLegsDiameter:
                {
                    break;
                }
            }

            _parameters[parameterType].Minimum = minValue;
            _parameters[parameterType].Maximum = maxValue;
            _parameters[parameterType].Value = value;
            if (parameterType == ParameterType.TableTopHeight || parameterType == ParameterType.TableLegsHeight)
            {
                CheckingFullHeightTable();
            }

            if (parameterType == ParameterType.TableLegsDiameter)
            {
                CheckingDiameterTanbleLegs();
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
            // TODO
            if (fullHeightTable < 440)
            {
                throw new ArgumentException($"Общая высота стола({tableTopHeightName} " +
                                            $"+ {tableLegHeightName}) " +
                                            $"должна быть больше либо равна 440 мм");
            }
        }

        /// <summary>
        /// Проверки диаметра оснований ножек стола
        /// </summary>
        private void CheckingDiameterTanbleLegs()
        {
            var tableTopLenght = _parameters[ParameterType.TableTopLength].Value;
            var tableTopWidth = _parameters[ParameterType.TableTopWidth].Value;
            var tableLegsDiameter = _parameters[ParameterType.TableLegsDiameter].Value;
           
            if (tableLegsDiameter >= (tableTopLenght / 3) || tableLegsDiameter >= (tableTopWidth / 3) )
            {
                throw new ArgumentException("Диаметр ножек стола должен быть меньше");
            }
        }

    }
}