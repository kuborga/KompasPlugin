using System;
using NUnit.Framework;
using TablePlugin.Model.Parameters;

namespace TablePlugin.UnitTests
{
    [TestFixture]
    public class TestParameter
    {
        [Test(Description = "Позитивный тест конструктора")]
        public void Test_Constructor_CorrectValue()
        {
            Assert.DoesNotThrow(
                () => new Parameter(10, 20,
                    15,"Название параметра")
                , "Вылетела ошибка при корректных значениях конструктора");
        }

        [Test(Description = "Позитивный тест проверки " +
                            "корректного значения свойста Minimum")]
        public void Test_Minimum_CorrectGetValue()
        {
            var value = 30.0;

            var expected = value;

            var parameter = new Parameter(value, 50,
                40, "Название параметра");

            var actual = parameter.Minimum;

            Assert.AreEqual(expected, actual, "Вернулось некорректное " +
                                              "значение");
        }

        [Test(Description = "Позитивный тест проверки " +
                            "корректного значения свойста Maximim")]
        public void Test_Maximum_CorrectGetValue()
        {
            var value = 50.0;

            var expected = value;

            var parameter = new Parameter(20, 50,
                40, "Название параметра");

            var actual = parameter.Maximum;

            Assert.AreEqual(expected, actual, "Вернулось некорректное " +
                                              "значение");
        }

        [Test(Description = "Позитивный тест проверки " +
                            "корректного значения свойста Name")]
        public void Test_Name_CorrectGetValue()
        {
            var value = "Ножка стола";

            var expected = value;

            var parameter = new Parameter(20, 50,
                40, "Ножка стола");

            var actual = parameter.Name;

            Assert.AreEqual(expected, actual, "Вернулось некорректное " +
                                              "значение");
        }


        [Test(Description = "Негативный тест " +
                            "присвоения пустой строки для свойства Name " +
                            "должно выкинуться исключение")]
        public void Test_Name_IncorrectSetValue()
        {
            Assert.Throws<ArgumentException>(
                () => new Parameter(5, 15, 7, 
                    string.Empty)
                ,"Не вылетела ошибка при некорректном " +
                 "значении Name");
        }

        [TestCase(TestName = "Проверка корректного получения" +
                             " значения свойства Value")]
        public void Test_Value_CorrectGetValue()
        {
            var value = 10.0;

            var expected = value;

            var parameter = new Parameter(1, 20,
                value, "Название параметра");

            var actual = parameter.Value;

            Assert.AreEqual(expected, actual,
                "Вернулось некорректное значение");
        }

        [TestCase(TestName = "Проверка корректной записи" +
                             " значения свойства Value")]
        public void Test_Value_CorrectSetValue()
        {
            var value = 10.0;

            var parameter = new Parameter(1, 20, 
                10.0, "Название параметра");

            Assert.DoesNotThrow(() => parameter.Value = value,
                "Не удалось присвоить корректное значение");
        }

        [TestCase(10, Description = "Позитивный тест." +
                                    "Проверка записи "  +
                                    "значения свойства Value " +
                                    "меньшему минимальному значению." +
                                    "Должно выкинуть исключение")]
        [TestCase(150, Description = "Позитивный тест." +
                                     "Проверка записи" +
                                     " значения свойства Value " +
                                     " больше максимального значения." +
                                     "Должно выкинуть исключение")]
        public void Test_Value_IncorrectSetValue(double value)
        {
            var parameter = new Parameter(15, 90,
                20, "Рандомное название параметра");

            Assert.Throws<ArgumentException>(() => parameter.Value = value,
                "Не удалось присвоить корректное значение");
        }

    }
}
