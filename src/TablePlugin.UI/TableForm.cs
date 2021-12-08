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
    /// Класс для работы формы плагина
    /// </summary>
    public partial class TablePluginForm : Form
    {
        /// <summary>
        /// Параметры стола
        /// </summary>
        private TableBuilder _tableBuilder;

        /// <summary>
        /// Конструктор класса(создан системой) TablePluginForm
        /// </summary>
        public TablePluginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки "Построить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            try 
            {
                TableParameters tableParameters = new TableParameters(
                    (double)tableTopLengthNum.Value,
                    (double)tableTopWidthNum.Value,
                    (double)tableTopHeightNum.Value,
                    (double)tableLegsDiameterNum.Value,
                    (double)tableLegsHeightNum.Value);

                _tableBuilder = _tableBuilder ?? new TableBuilder();
                _tableBuilder.Build(tableParameters);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
