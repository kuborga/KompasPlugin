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
                { ParameterType.TableLegsBase,
                    new Parameter(50,200,125,"Основание ножек стола")},
                { ParameterType.TableLegsHeight,
                    new Parameter(400,700,550, "Высота ножек стола")},
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
                                Value * 3.0, 
                            0, MidpointRounding.AwayFromZero);
                    minValue = (double.IsNaN(_parameters[ParameterType.
                        TableTopLength].Value)
                        ? 400
                        : tempMinValue);
                    if (minValue < 400)
                    {
                        minValue = 400;
                    }
                    break;
                }
                case ParameterType.TableTopWidth:
                {
                    int tempMinValue = (int)Math.
                        Round(_parameters[ParameterType.TableLegsBase].
                                Value * 3.0,
                        0, MidpointRounding.AwayFromZero);
                    minValue = (double.IsNaN(_parameters[ParameterType.
                        TableTopWidth].Value)
                        ? 400
                        : tempMinValue);
                    if (minValue < 400)
                    {
                        minValue = 400;
                    }
                    break;
                }
                case ParameterType.TableTopHeight:
                {
                    minValue = (double.IsNaN(_parameters[ParameterType.
                        TableTopHeight].Value)
                        ? 20
                        : (440 - _parameters[ParameterType.
                            TableLegsHeight].Value));
                    if (minValue < 20)
                    {
                        minValue = 20;
                    } 
                    break;
                }
                case ParameterType.TableLegsHeight:
                {
                    minValue = (double.IsNaN(_parameters[ParameterType.
                        TableLegsHeight].Value)
                        ? 400
                        : (440 - _parameters[ParameterType.
                            TableTopHeight].Value));
                    if (minValue < 400)
                    {
                        minValue = 400;
                    }
                    break;
                }
                case ParameterType.TableLegsBase:
                {
                    int minimumValue = Math.
                        Min(_parameters[ParameterType.TableTopWidth].Value,
                        _parameters[ParameterType.TableTopLength].Value);
                    int tempValue = (int)Math.Round( minimumValue / 3.0,
                            0 ,MidpointRounding.AwayFromZero);
                    maxValue = (double.IsNaN(_parameters[ParameterType.
                        TableLegsBase].Value)
                        ? 200
                        : tempValue);
                    if (maxValue > 200)
                    {
                        maxValue = 200;
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