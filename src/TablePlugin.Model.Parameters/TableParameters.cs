using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TablePlugin.Model.Parameters
{
    /// <summary>
    /// Класс параметров стола
    /// </summary>
    public class TableParameters
    {

        /// <summary>
        /// Коэффициент зависимых значений.
        /// Используется только расчётов.
        /// </summary>
        private const double СoefficientDependentParameter = 3.0;

        /// <summary>
        /// Минимальная длина столешницы
        /// </summary>
        private const int MinTableTopLength = 400;

        /// <summary>
        /// Минимальная ширина столешницы
        /// </summary>
        private const int MinTableTopWidth = 400;

        /// <summary>
        /// Минимальная выcота столешницы
        /// </summary>
        private const int MinTableTopHeight = 20;

        /// <summary>
        /// Максимальное значение ножек стола
        /// </summary>
        private const int MaxTableLegsBase = 200;

        /// <summary>
        /// Минимальная высота ножек стола
        /// </summary>
        private const int MinTableLegsHeight = 400;

        /// <summary>
        /// Минимальная общая (высота столешницы + высота ножек) высота стола
        /// </summary>
        private const int MinTotalHeightTable = 441;

        /// <summary>
        /// Словарь параметров класса <see cref="TableParameters"/>
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _parameters =
            new Dictionary<ParameterType, Parameter>
            {
                { ParameterType.TableTopLength,
                    new Parameter(MinTableTopLength,800,600, "Длина столешницы")},
                { ParameterType.TableTopWidth,
                    new Parameter(MinTableTopWidth,800,600, "Ширина столешницы")},
                { ParameterType.TableTopHeight,
                    new Parameter(MinTableTopHeight,80,60, "Высота столешницы")},
                { ParameterType.TableLegsBase,
                    new Parameter(50,MaxTableLegsBase,125,"Основание ножек стола")},
                { ParameterType.TableLegsHeight,
                    new Parameter(MinTableLegsHeight,700,550, "Высота ножек стола")},
            };

        /// <summary>
        /// Конструктор класса <see cref="TableParameters"/> без параметров
        /// </summary>
        public TableParameters()
        { }

        /// <summary>
        /// Установить значение параметра
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <param name="value">Значение параметра</param>
        public void SetValue(ParameterType parameterType, int value)
        {
            var minValue = _parameters[parameterType].Minimum;
            var maxValue = _parameters[parameterType].Maximum;

            switch(parameterType)
            {
                case ParameterType.TableTopLength:
                {
                    minValue =
                        SetValueDependentParameters(ParameterType.TableTopLength, 
                            MinTableTopLength);
                        break;
                }
                case ParameterType.TableTopWidth:
                {
                    minValue = 
                        SetValueDependentParameters(ParameterType.TableTopWidth, 
                            MinTableTopWidth);
                        break;
                }
                case ParameterType.TableTopHeight:
                {
                        minValue =
                            SetValueTotalHeightTable(ParameterType.
                                TableTopHeight,
                                MinTableTopHeight, 
                                ParameterType.
                                    TableLegsHeight);
                        break;
                }
                case ParameterType.TableLegsHeight:
                {
                        minValue =
                            SetValueTotalHeightTable(ParameterType.
                                TableLegsHeight, 
                                MinTableTopHeight,
                                ParameterType.
                                TableTopHeight);
                        break;
                }
                case ParameterType.TableLegsBase:
                {
                    maxValue = SetValueTableLegsBase(ParameterType.
                        TableLegsBase,
                        MaxTableLegsBase);
                        break;
                }
            }

            _parameters[parameterType].Minimum = minValue;
            _parameters[parameterType].Maximum = maxValue;
            _parameters[parameterType].Value = value;
        }

        /// <summary>
        /// Установка значения для зависимого параметра
        /// "Высота столешницы" ил "Высота ножек стола".
        ///  Значение "Высота столешницы" + "Высота ножек стола"
        /// должно быть больше 400
        /// </summary>
        /// <param name="parameterType">Тип паарметра</param>
        /// <param name="minAllowedValue">Минимальное допустимое значение</param>
        /// <param name="depedentParameterType">Тип зависимого параметра</param>
        /// <returns></returns>
        private int SetValueTotalHeightTable(ParameterType parameterType,
            int minAllowedValue, ParameterType depedentParameterType)
        {
            if (parameterType != ParameterType.TableTopHeight
                && parameterType != ParameterType.TableLegsHeight)
            {
                string textError = "Передан неправильный ParameterType " +
                                   "в метод SetValueTableLegsBase";
                throw new ArgumentException(textError);
            }

            int minValue = (double.IsNaN(_parameters[parameterType].Value) ?
                minAllowedValue :
                (MinTotalHeightTable - 
                 _parameters[depedentParameterType].Value));

            if (minValue < minAllowedValue)
            {
                minValue = minAllowedValue;
            }
            return minValue;
            
        }

        /// <summary>
        /// Установка значений для параметра "Основание ножек стола"
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <param name="maxAllowedValue">
        /// Максимальное допустимое значение</param>
        /// <returns></returns>
        private int SetValueTableLegsBase(ParameterType parameterType,
            int maxAllowedValue)
        {
            if (parameterType != ParameterType.TableLegsBase)
            {
                string textError = "Передан неправильный ParameterType " +
                                   "в метод SetValueTableLegsBase";
                throw new ArgumentException(textError);
            }
            var minimumValue = Math.
                Min(_parameters[ParameterType.TableTopWidth].Value,
                    _parameters[ParameterType.TableTopLength].Value);
            var tempValue = (int)Math.
                Round(minimumValue / СoefficientDependentParameter,
                    0, MidpointRounding.AwayFromZero);
            var maxValue = (double.IsNaN(_parameters[ParameterType.
                TableLegsBase].Value)
                ? MaxTableLegsBase
                : tempValue);
            if (maxValue > maxAllowedValue)
            {
                maxValue = maxAllowedValue;
            }
            return maxValue;
        }

        /// <summary>
        /// Установка значений для параметра
        /// "Длина столешницы", "Ширина столешницы".
        ///  "Длина столешницы", "Ширина столешницы" зависят от
        ///  параметра "Значение основание стола" 
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <param name="minAllowedValue">Минимальное допустимое значение</param>
        /// <returns>Значения минимума</returns>
        private int SetValueDependentParameters(ParameterType parameterType, 
            int minAllowedValue)
        {
            if (parameterType != ParameterType.TableTopLength 
                && parameterType != ParameterType.TableTopWidth)
            {
                string textError = "Передан неправильный ParameterType " +
                                   "в метод SetValueDependentParameters";
                throw new ArgumentException(textError);
            }

            var tempMinValue = (int)Math.
                Round(_parameters[ParameterType.TableLegsBase].
                        Value * СoefficientDependentParameter,
                    0, MidpointRounding.AwayFromZero);
            var minValue = (double.IsNaN(_parameters[parameterType].Value)
                ? minAllowedValue
                : tempMinValue);

            if (minValue < minAllowedValue)
            {
                minValue = minAllowedValue;
            }
            return minValue;
        }

        /// <summary>
        /// Получить значение параметра
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <returns>Значение параметра</returns>
        public int GetValue(ParameterType parameterType)
        {
            return _parameters[parameterType].Value;
        }

        /// <summary>
        /// Получить название параметра
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <returns>Имя параметра</returns>
        public string GetName(ParameterType parameterType)
        {
            return _parameters[parameterType].Name;
        }
    }
}