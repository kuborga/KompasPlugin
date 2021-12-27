using System;
using NUnit.Framework;
using TablePlugin.Model.Parameters;
using Assert = NUnit.Framework.Assert;

namespace TablePlugin.UnitTests
{
    /// <summary>
    /// Класс для тестирования класса <see cref="TableParameters"/>
    /// </summary>
    class TestTableParameters
    {
        /// <summary>
        /// Возвращает новый экземпляр класс <see cref="TableParameters"/>
        /// </summary>
        private TableParameters _tableParameters  = new TableParameters();

        [TestCase(ParameterType.TableTopLength, 600,
            Description = "Проверка корректного значения" +
                          " получения свойства TableTopLength")]
        [TestCase(ParameterType.TableTopWidth, 700,
            Description = "Проверка корректного значения " +
                          " получения свойства TableTopWidth")]
        [TestCase(ParameterType.TableTopHeight, 60,
            Description = "Проверка корректного значения  " +
                          " получения свойства TableTopHeight")]
        [TestCase(ParameterType.TableLegsHeight, 550,
            Description = "Проверка корректного значения  " +
                          " получения свойства TableLegsHeight")]
        [TestCase(ParameterType.TableLegsBase, 130,
            Description = "Проверка корректного значения " +
                          " получения свойства TableLegsBase")]
        public void Test_GetValue_CorrectGetValue(
            ParameterType parameterType,
            int value)
        {
            var tableParameters = _tableParameters;

            var expected = value;

            tableParameters.SetValue(parameterType, value);

            var actual = tableParameters.GetValue(parameterType);

            Assert.AreEqual(expected, actual, 
                "Вернулось некорректное значение");
        }

        [TestCase(ParameterType.TableTopLength,
            "Длина столешницы",
            Description = "Проверка корректного получения " +
                          "названия свойства TableTopLength")]
        [TestCase(ParameterType.TableTopWidth,
            "Ширина столешницы",
            Description = "Проверка корректного  получения " +
                          "названия свойства TableTopWidth")]
        [TestCase(ParameterType.TableTopHeight,
            "Высота столешницы",
            Description = "Проверка корректного получения " +
                          "названия свойства TableTopHeight")]
        [TestCase(ParameterType.TableLegsBase,
            "Основание ножек стола",
            Description = "Проверка корректного получения " +
                          "названия свойства TableLegsBase")]
        [TestCase(ParameterType.TableLegsHeight,
            "Высота ножек стола",
            Description = "Проверка корректного получения " +
                          "названия свойства TableLegsHeight")]
        public void Test_GetValue_CorrectGetName(
            ParameterType parameterType,
            string name)
        {
            var tableParameters = _tableParameters;

            var expected = name;

            var actual = tableParameters.GetName(parameterType);
            Assert.AreEqual(expected, actual,
                "Вернулось некорректное название параметра");
        }

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
        [TestCase(ParameterType.TableLegsBase, 130,
            Description = "Проверка корректной записи значения " +
                          " свойства TableLegsHeight")]
        public void Test_SetValue_CorrectSetValue(
            ParameterType parameterType,
            int value)
        {
            var tableParameters = _tableParameters;

            Assert.DoesNotThrow(
                () => tableParameters.SetValue(parameterType, value),
                "Не удалось присвоить корректное значение");
        }

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
        [TestCase(ParameterType.TableLegsBase, 40,
            Description = "Проверка некорректной записи значения" +
                          " свойства TableLegsHeight" +
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
        [TestCase(ParameterType.TableLegsBase, 1000,
            Description = "Проверка некорректной записи значения " +
                          " свойства TableLegsHeight" +
                          " больше максимального")]
        public void Test_SetValue_IncorrectSetValue(
            ParameterType parameterType,
            int value)
        {
            var tableParameters = _tableParameters;

            Assert.Throws<ArgumentException>(
                () => tableParameters.SetValue(parameterType, value),
                $"Было присвоено значение не входящие в диапазон");
        }
    }
}
