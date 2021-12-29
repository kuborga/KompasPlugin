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
                //TODO: дубль
                case ParameterType.TableTopLength:
                {
                    //int tempMinValue = (int)Math.
                    //    Round(_parameters[ParameterType.TableLegsBase].
                    //            Value * СoefficientDependentParameter, 
                    //        0, MidpointRounding.AwayFromZero);
                    //minValue = (double.IsNaN(_parameters[ParameterType.
                    //    TableTopLength].Value)
                    //    ? MinTableTopLength
                    //    : tempMinValue);
                    //    if (minValue < MinTableTopLength)
                    //    {
                    //        minValue = MinTableTopLength;
                    //    }
                    minValue =
                        SetValueDependentParameters(ParameterType.
                            TableTopLength, MinTableTopLength);
                        break;
                }
                case ParameterType.TableTopWidth:
                {
                    //TODO: дубль
                    //    int tempMinValue = (int)Math.
                    //    Round(_parameters[ParameterType.TableLegsBase].
                    //            Value * СoefficientDependentParameter,
                    //    0, MidpointRounding.AwayFromZero);
                    //minValue = (double.IsNaN(_parameters[ParameterType.
                    //    TableTopWidth].Value)
                    //    ? MinTableTopWidth
                    //    : tempMinValue);
                    //    if (minValue < MinTableTopWidth)
                    //    {
                    //        minValue = MinTableTopWidth;
                    //    }
                    minValue = 
                        SetValueDependentParameters(ParameterType.
                            TableTopWidth, MinTableTopWidth);
                        break;
                }
                case ParameterType.TableTopHeight:
                {
                        //TODO: дубль (было)
                        //minValue = (double.IsNaN(_parameters[ParameterType.
                        //TableTopHeight].Value)
                        //? MinTableTopHeight
                        //: (MinTotalHeightTable - _parameters[ParameterType.
                        //    TableLegsHeight].Value));
                        minValue = 
                            SetMinValueTotalHeightTable(ParameterType.
                                TableTopHeight, MinTableTopHeight);
                        break;
                }
                case ParameterType.TableLegsHeight:
                {
                        //TODO: дубль (было)
                        //minValue = (double.IsNaN(_parameters[ParameterType.
                        //TableLegsHeight].Value)
                        //? MinTableLegsHeight
                        //: (MinTotalHeightTable - _parameters[ParameterType.
                        //    TableTopHeight].Value));
                        //     minValue = SetMinValueTotalHeightTable(ParameterType.TableLegsHeight, MinTableLegsHeight);
                        minValue =
                            SetMinValueTotalHeightTable(ParameterType.
                                TableLegsHeight, MinTableTopHeight);
                        break;
                }
                case ParameterType.TableLegsBase:
                {
                    //TODO: дубль
                    //    int minimumValue = Math.
                    //    Min(_parameters[ParameterType.TableTopWidth].Value,
                    //    _parameters[ParameterType.TableTopLength].Value);
                    //int tempValue = (int)Math.
                    //    Round( minimumValue / СoefficientDependentParameter,
                    //        0 ,MidpointRounding.AwayFromZero);
                    //maxValue = (double.IsNaN(_parameters[ParameterType.
                    //    TableLegsBase].Value)
                    //    ? MaxTableLegsBase
                    //    : tempValue);
                    //    if (maxValue > MaxTableLegsBase)
                    //    {
                    //        maxValue = MaxTableLegsBase;
                    //    }
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
        /// Установка минимального значения для зависимого параметра
        /// "Высота столешницы" ил "Высота ножек стола".
        ///  Значение "Высота столешницы" + "Высота ножек стола"
        /// должно быть больше 400
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <param name="minAllowedValue">
        /// Минимальное допустимое значение(const)</param>
        /// <returns></returns>
        private int SetMinValueTotalHeightTable(ParameterType parameterType,
            int minAllowedValue)
        {
            int minValue = -1;
            int valueDependetParameter = -1;
            if (parameterType == ParameterType.TableTopHeight 
                || parameterType == ParameterType.TableLegsHeight)
            {
                if (parameterType == ParameterType.TableTopHeight)
                {
                    valueDependetParameter = _parameters[ParameterType.
                        TableLegsHeight].Value;
                }
                else if (parameterType == ParameterType.TableLegsHeight)
                {
                    valueDependetParameter = _parameters[ParameterType.
                        TableTopHeight].Value;
                }
                minValue = (double.IsNaN(_parameters[parameterType].Value) ?
                    minAllowedValue :
                    (MinTotalHeightTable - valueDependetParameter));
                if (minValue < minAllowedValue)
                {
                    minValue = minAllowedValue;
                }
                return minValue;
            }
            throw new ArgumentException("Передан неправильный ParameterType " +
                                        "в метод SetMinValueTotalHeightTable");
        }

        /// <summary>
        /// Установка значений для параметра "Основание ножек стола".
        /// 
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <param name="maxAllowedValue">Максимальное допустимое значение</param>
        /// <returns></returns>
        private int SetValueTableLegsBase(ParameterType parameterType,
            int maxAllowedValue)
        {
            if (parameterType != ParameterType.TableLegsBase)
            {
                throw new ArgumentException("Передан неправильный ParameterType " +
                                         "в метод SetValueTableLegsBase");
            }
            var minimumValue = Math.
                Min(_parameters[ParameterType.TableTopWidth].Value,
                    _parameters[ParameterType.TableTopLength].Value);
            var tempValue = (int)Math.
                Round(minimumValue / СoefficientDependentParameter,
                    0, MidpointRounding.AwayFromZero);
            var maxValue = (double.IsNaN(_parameters[ParameterType.TableLegsBase].Value)
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
        /// <param name="minAllowedValue"></param>
        /// <returns>Минимум и</returns>
        private int SetValueDependentParameters(ParameterType parameterType, 
            int minAllowedValue)
        {
            if (parameterType != ParameterType.TableTopLength 
                && parameterType != ParameterType.TableTopWidth)
            {
                throw new ArgumentException("Передан неуместный ParameterType " +
                                         "в метод SetValueDependentParameters");

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