using System;
using System.Collections.Generic;

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
        /// Минимальная выоста столешницы
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
                //TODO: to const (исправил +)
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
                    int tempMinValue = (int)Math.
                        Round(_parameters[ParameterType.TableLegsBase].
                                Value * СoefficientDependentParameter, 
                            0, MidpointRounding.AwayFromZero);
                    minValue = (double.IsNaN(_parameters[ParameterType.
                        TableTopLength].Value)
                    //TODO: to const (исправил +)
                        ? MinTableTopLength
                        : tempMinValue);
                    if (minValue < MinTableTopLength)
                    {
                        minValue = MinTableTopLength;
                    }
                    break;
                }
                case ParameterType.TableTopWidth:
                {
                    int tempMinValue = (int)Math.
                        Round(_parameters[ParameterType.TableLegsBase].
                                Value * СoefficientDependentParameter,
                        0, MidpointRounding.AwayFromZero);
                    minValue = (double.IsNaN(_parameters[ParameterType.
                        TableTopWidth].Value)
                        ? MinTableTopWidth
                        : tempMinValue);
                    if (minValue < MinTableTopWidth)
                    {
                        minValue = MinTableTopWidth;
                    }
                    break;
                }
                case ParameterType.TableTopHeight:
                {
                    minValue = (double.IsNaN(_parameters[ParameterType.
                        TableTopHeight].Value)
                        ? MinTableTopHeight
                        : (MinTotalHeightTable - _parameters[ParameterType.
                            TableLegsHeight].Value));
                    if (minValue < MinTableTopHeight)
                    {
                        minValue = MinTableTopHeight;
                    } 
                    break;
                }
                case ParameterType.TableLegsHeight:
                {
                    minValue = (double.IsNaN(_parameters[ParameterType.
                        TableLegsHeight].Value)
                        ? MinTableLegsHeight
                        : (MinTotalHeightTable - _parameters[ParameterType.
                            TableTopHeight].Value));
                    if (minValue < MinTableLegsHeight)
                    {
                        minValue = MinTableLegsHeight;
                    }
                    break;
                }
                case ParameterType.TableLegsBase:
                {
                    int minimumValue = Math.
                        Min(_parameters[ParameterType.TableTopWidth].Value,
                        _parameters[ParameterType.TableTopLength].Value);
                    int tempValue = (int)Math.
                        Round( minimumValue / СoefficientDependentParameter,
                            0 ,MidpointRounding.AwayFromZero);
                    maxValue = (double.IsNaN(_parameters[ParameterType.
                        TableLegsBase].Value)
                        ? MaxTableLegsBase
                        : tempValue);
                    if (maxValue > MaxTableLegsBase)
                    {
                        maxValue = MaxTableLegsBase;
                    }
                    break;
                }
            }

            _parameters[parameterType].Minimum = minValue;
            _parameters[parameterType].Maximum = maxValue;
            _parameters[parameterType].Value = value;
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