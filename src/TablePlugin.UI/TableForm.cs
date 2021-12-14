using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TablePlugin.Model.Parameters;
using TablePlugin.Model.Kompas;

namespace TablePlugin.UI
{
    /// <summary>
    /// Класс для работы с главной формой плагина
    /// </summary>
    public partial class TablePluginForm : Form
    {
        /// <summary>
        /// Класс построения стола
        /// </summary>
        private TableBuilder _tableBuilder;

        /// <summary>
        /// Параметры стола
        /// </summary>
        private TableParameters _tableParameters;

        /// <summary>
        /// Словарь ошибок
        /// </summary>
        private Dictionary<ParameterType, string> _errors 
            = new Dictionary<ParameterType, string>();


        /// <summary>
        /// Конструктор класса(создан системой) TablePluginForm
        /// </summary>
        public TablePluginForm()
        {
            InitializeComponent();
            _tableParameters = new TableParameters();
        }


        /// <summary>
        /// Возращает строку всех ошибок
        /// </summary>
        /// <returns></returns>
        private string GetAllErrors()
        {
            var errorMessage = string.Empty;
            for (var i = 0; i < _errors.Keys.Count; i++)
            {
                var key = _errors.Keys.ToArray()[i];
                errorMessage += _errors[key] + '\n';
            }
            return errorMessage;
        }


        /// <summary>
        /// Обработчик кнопки "Построить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            if(_errors.Any())
            {
                var message = GetAllErrors();
                MessageBox.Show(message, "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _tableBuilder = _tableBuilder ?? new TableBuilder();
                _tableBuilder.Build(_tableParameters);
            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Событие при измении значения в поле <see cref="NumericUpDown"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnyValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!(sender is NumericUpDown numericUpDown))
            {
                return;
            }
            SetValueParameter(numericUpDown,FindParameters(numericUpDown.Name));
        }

        /// <summary>
        /// Уставнока значений из numericUpDown в класс TableParameter
        /// </summary>
        /// <param name="numericUpDown"></param>
        /// <param name="parameterType"></param>
        private void SetValueParameter(NumericUpDown numericUpDown, ParameterType parameterType)
        {
            try
            {
                var value = (double)numericUpDown.Value;
                _tableParameters.SetValue(parameterType, value);
                if (_errors.ContainsKey(parameterType))
                {
                    _errors.Remove(parameterType);
                }
            }
            catch (ArgumentException exception)
            {
                numericUpDown.BackColor = Color.Red;
                if (!_errors.ContainsKey(parameterType))
                {
                    _errors.Add(parameterType, exception.Message);
                }
                else
                {
                    _errors[parameterType] = exception.Message;
                }
                return;
            }
            numericUpDown.BackColor = Color.White;
        }

        /// <summary>
        /// Поиск <see cref="Parameters"/> по названию <see cref="NumericUpDown"/>
        /// </summary>
        /// <param name="numericUpDownName">Название NumericUpDown</param>
        /// <returns><see cref="ParameterType"/> </returns>
        private ParameterType FindParameters(string numericUpDownName)
        {
            var parameters = Enum.GetValues(typeof(ParameterType))
                .Cast<ParameterType>()
                .ToList();
            foreach (var parameter in parameters)
            {
                if (numericUpDownName.Contains(parameter.ToString()))
                {
                    return parameter;
                }
            }
            throw new ArgumentException("Не найдено значение в перечисление TypeParameter");
        }


    }
}
