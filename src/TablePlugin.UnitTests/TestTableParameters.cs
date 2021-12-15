using System;
using NUnit.Framework;
using TablePlugin.Model.Parameters;
using Assert = NUnit.Framework.Assert;

namespace TablePlugin.UnitTests
{
    /// <summary>
    /// класс для тестирования класса <see cref="TestTableParameters"/>
    /// </summary>
    class TestTableParameters
    {
        /// <summary>
        /// Возвращает новый экземпляр класс <see cref="TableParameters"/>
        /// </summary>
        private TableParameters _tableParameters  = new TableParameters();

        /// <summary>
        /// Позитивные тесты
        /// </summary>
        /// <param name="parameterType">Тип параметра
        /// <see cref="ParameterType"/></param>
        /// <param name="value">Значение параметра</param>
        [TestCase(ParameterType.TableTopLength, 600,
            Description = "Проверка корректного значения" +
                          " получения свойства TableTopLength")]
        [TestCase(ParameterType.TableTopWidth, 700,
            Description = "Проверка корректного значения " +
                          " получения свойстваTableTopWidth")]
        [TestCase(ParameterType.TableTopHeight, 60,
            Description = "Проверка корректного значения  " +
                          " получения свойстваTableTopHeight")]
        [TestCase(ParameterType.TableLegsHeight, 550,
            Description = "Проверка корректного значения  " +
                          " получения свойстваTableLegsHeight")]
        [TestCase(ParameterType.TableLegsDiameter, 130,
            Description = "Проверка корректного значения " +
                          " получения свойстваTableLegsHeight")]
        public void Test_GetValue_CorrectGetValue(
            ParameterType parameterType,
            double value)
        {
            var tableParameters = _tableParameters;

            var expected = value;

            tableParameters.SetValue(parameterType, value);

            var actual = tableParameters.GetValue(parameterType);

            Assert.AreEqual(expected, actual, 
                "Вернулось некорректное значение");
        }

        /// <summary>
        /// Позитивные тесты
        /// </summary>
        /// <param name="parameterType">Тип параметра
        /// <see cref="ParameterType"/></param>
        /// <param name="value">Значение параметра</param>
        [TestCase(ParameterType.TableTopLength, 600,
            Description = "Проверка корректной записи значения" +
                          " свойства TableTopLength")]
        [TestCase(ParameterType.TableTopWidth, 700,
            Description = "Проверка корректной записи значения" +
                          " свойства TableTopWidth")]
        [TestCase(ParameterType.TableTopHeight, 60,
            Description = "Проверка корректной записи значения" +
                          " свойства TableTopHeight")]
        [TestCase(ParameterType.TableLegsHeight, 550,
            Description = "Проверка корректной записи значения " +
                          " свойства TableLegsHeight")]
        [TestCase(ParameterType.TableLegsDiameter, 130,
            Description = "Проверка корректной записи значения " +
                          " свойстваTableLegsHeight")]
        public void Test_SetValue_CorrectSetValue(
            ParameterType parameterType, 
            double value)
        {
            var tableParameters = _tableParameters;

            Assert.DoesNotThrow(
                () => tableParameters.SetValue(parameterType, value),
                "Не удалось присвоить корректное значение.");
        }

        /// <summary>
        /// Негативные тесты
        /// </summary>
        /// <param name="parameterType">
        /// <see cref="ParameterType"/></param>
        /// <param name="value"></param>
        [TestCase(ParameterType.TableTopLength, 300,
            Description = "Проверка некорректной записи значения" +
                          " свойства TableTopLength" +
                          " меньше минимального")]
        [TestCase(ParameterType.TableTopWidth, 300,
            Description = "Проверка некорректной записи значения" +
                          " свойства TableTopWidth" +
                          " меньше минимального")]
        [TestCase(ParameterType.TableTopHeight, 200,
            Description = "Проверка некорректной записи значения" +
                          "свойства TableTopHeight" +
                          " меньше минимального")]
        [TestCase(ParameterType.TableLegsHeight, 300,
            Description = "Проверка некорректной записи значения" +
                          " свойства TableLegsHeight" +
                          " меньше минимального ")]
        [TestCase(ParameterType.TableLegsDiameter, 40,
            Description = "Проверка некорректной записи значения" +
                          " свойстваTableLegsHeight" +
                          " меньше минимального ")]
        [TestCase(ParameterType.TableTopLength, 1000,
            Description = "Проверка некорректной записи значения " +
                          " свойства TableTopLength" +
                          " больше максимального")]
        [TestCase(ParameterType.TableTopWidth, 1000,
            Description = "Проверка некорректной записи значения " +
                          " свойства TableTopWidth" +
                          " больше максимального")]
        [TestCase(ParameterType.TableTopHeight, 1000,
            Description = "Проверка некорректной записи значения  " +
                          " свойства TableTopHeight" +
                          " мбольше максимального")]
        [TestCase(ParameterType.TableLegsHeight, 1000,
            Description = "Проверка некорректной записи значения  " +
                          " свойства TableLegsHeight" +
                          " больше максимального")]
        [TestCase(ParameterType.TableLegsDiameter, 1000,
            Description = "Проверка некорректной записи значения " +
                          " свойстваTableLegsHeight" +
                          " больше максимального")]
        public void Test_SetValue_IncorrectSetValue(
            ParameterType parameterType, 
            double value)
        {
            var tableParameters = _tableParameters;
            Assert.Throws<ArgumentException>(
                () => tableParameters.SetValue(parameterType, value),
                $"Было присвоино значение не входящие в диапазон");
        }
    }
}
