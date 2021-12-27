
namespace TablePlugin.UI
{
    partial class TablePluginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BuildButton = new System.Windows.Forms.Button();
            this.ErrorTextGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TableLegsHeightNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.TableLegsBaseNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.LegsTypeComboBox = new System.Windows.Forms.ComboBox();
            this.legsParameters = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TableTopLengthNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TableTopWidthNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.TableTopHeightNum = new System.Windows.Forms.NumericUpDown();
            this.tableTopGroupBox = new System.Windows.Forms.GroupBox();
            this.ErrorTestTextBox = new System.Windows.Forms.TextBox();
            this.ErrorTextGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableLegsHeightNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLegsBaseNum)).BeginInit();
            this.legsParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableTopLengthNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableTopWidthNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableTopHeightNum)).BeginInit();
            this.tableTopGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(154, 273);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(169, 35);
            this.BuildButton.TabIndex = 2;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // ErrorTextGroupBox
            // 
            this.ErrorTextGroupBox.Controls.Add(this.ErrorTestTextBox);
            this.ErrorTextGroupBox.Location = new System.Drawing.Point(33, 158);
            this.ErrorTextGroupBox.Name = "ErrorTextGroupBox";
            this.ErrorTextGroupBox.Size = new System.Drawing.Size(423, 100);
            this.ErrorTextGroupBox.TabIndex = 3;
            this.ErrorTextGroupBox.TabStop = false;
            this.ErrorTextGroupBox.Text = "Ошибки:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Высота (400 - 700) мм";
            // 
            // TableLegsHeightNum
            // 
            this.TableLegsHeightNum.Location = new System.Drawing.Point(144, 23);
            this.TableLegsHeightNum.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.TableLegsHeightNum.Name = "TableLegsHeightNum";
            this.TableLegsHeightNum.Size = new System.Drawing.Size(50, 20);
            this.TableLegsHeightNum.TabIndex = 1;
            this.TableLegsHeightNum.Value = new decimal(new int[] {
            550,
            0,
            0,
            0});
            this.TableLegsHeightNum.ValueChanged += new System.EventHandler(this.AnyValueNumericUpDown_ValueChanged);
            this.TableLegsHeightNum.Validating += new System.ComponentModel.CancelEventHandler(this.AnyValueNumericUpDown_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Основание (50 - 200) мм";
            // 
            // TableLegsBaseNum
            // 
            this.TableLegsBaseNum.Location = new System.Drawing.Point(144, 57);
            this.TableLegsBaseNum.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.TableLegsBaseNum.Name = "TableLegsBaseNum";
            this.TableLegsBaseNum.Size = new System.Drawing.Size(50, 20);
            this.TableLegsBaseNum.TabIndex = 3;
            this.TableLegsBaseNum.Value = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.TableLegsBaseNum.ValueChanged += new System.EventHandler(this.AnyValueNumericUpDown_ValueChanged);
            this.TableLegsBaseNum.Validating += new System.ComponentModel.CancelEventHandler(this.AnyValueNumericUpDown_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Тип ножек";
            // 
            // LegsTypeComboBox
            // 
            this.LegsTypeComboBox.FormattingEnabled = true;
            this.LegsTypeComboBox.Items.AddRange(new object[] {
            "круглые",
            "квадратные",
            "треугольные"});
            this.LegsTypeComboBox.Location = new System.Drawing.Point(98, 90);
            this.LegsTypeComboBox.Name = "LegsTypeComboBox";
            this.LegsTypeComboBox.Size = new System.Drawing.Size(96, 21);
            this.LegsTypeComboBox.TabIndex = 6;
            this.LegsTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.LegsTypeComboBox_SelectedIndexChanged);
            // 
            // legsParameters
            // 
            this.legsParameters.Controls.Add(this.LegsTypeComboBox);
            this.legsParameters.Controls.Add(this.label4);
            this.legsParameters.Controls.Add(this.TableLegsBaseNum);
            this.legsParameters.Controls.Add(this.label5);
            this.legsParameters.Controls.Add(this.TableLegsHeightNum);
            this.legsParameters.Controls.Add(this.label6);
            this.legsParameters.Location = new System.Drawing.Point(256, 24);
            this.legsParameters.Name = "legsParameters";
            this.legsParameters.Size = new System.Drawing.Size(200, 118);
            this.legsParameters.TabIndex = 1;
            this.legsParameters.TabStop = false;
            this.legsParameters.Text = "Параметры ножек";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Длина (400 - 800) мм";
            // 
            // TableTopLengthNum
            // 
            this.TableTopLengthNum.Location = new System.Drawing.Point(144, 23);
            this.TableTopLengthNum.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.TableTopLengthNum.Name = "TableTopLengthNum";
            this.TableTopLengthNum.Size = new System.Drawing.Size(50, 20);
            this.TableTopLengthNum.TabIndex = 1;
            this.TableTopLengthNum.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.TableTopLengthNum.ValueChanged += new System.EventHandler(this.AnyValueNumericUpDown_ValueChanged);
            this.TableTopLengthNum.Validating += new System.ComponentModel.CancelEventHandler(this.AnyValueNumericUpDown_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ширина (400 - 800) мм";
            // 
            // TableTopWidthNum
            // 
            this.TableTopWidthNum.Location = new System.Drawing.Point(144, 57);
            this.TableTopWidthNum.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.TableTopWidthNum.Name = "TableTopWidthNum";
            this.TableTopWidthNum.Size = new System.Drawing.Size(50, 20);
            this.TableTopWidthNum.TabIndex = 3;
            this.TableTopWidthNum.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.TableTopWidthNum.ValueChanged += new System.EventHandler(this.AnyValueNumericUpDown_ValueChanged);
            this.TableTopWidthNum.Validating += new System.ComponentModel.CancelEventHandler(this.AnyValueNumericUpDown_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Высота (20 - 80) мм";
            // 
            // TableTopHeightNum
            // 
            this.TableTopHeightNum.Location = new System.Drawing.Point(144, 91);
            this.TableTopHeightNum.Name = "TableTopHeightNum";
            this.TableTopHeightNum.Size = new System.Drawing.Size(50, 20);
            this.TableTopHeightNum.TabIndex = 5;
            this.TableTopHeightNum.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.TableTopHeightNum.ValueChanged += new System.EventHandler(this.AnyValueNumericUpDown_ValueChanged);
            this.TableTopHeightNum.Validating += new System.ComponentModel.CancelEventHandler(this.AnyValueNumericUpDown_Validating);
            // 
            // tableTopGroupBox
            // 
            this.tableTopGroupBox.Controls.Add(this.TableTopHeightNum);
            this.tableTopGroupBox.Controls.Add(this.label3);
            this.tableTopGroupBox.Controls.Add(this.TableTopWidthNum);
            this.tableTopGroupBox.Controls.Add(this.label2);
            this.tableTopGroupBox.Controls.Add(this.TableTopLengthNum);
            this.tableTopGroupBox.Controls.Add(this.label1);
            this.tableTopGroupBox.Location = new System.Drawing.Point(33, 24);
            this.tableTopGroupBox.Name = "tableTopGroupBox";
            this.tableTopGroupBox.Size = new System.Drawing.Size(200, 118);
            this.tableTopGroupBox.TabIndex = 0;
            this.tableTopGroupBox.TabStop = false;
            this.tableTopGroupBox.Text = "Параметры столешницы";
            // 
            // ErrorTestTextBox
            // 
            this.ErrorTestTextBox.Location = new System.Drawing.Point(7, 20);
            this.ErrorTestTextBox.Multiline = true;
            this.ErrorTestTextBox.Name = "ErrorTestTextBox";
            this.ErrorTestTextBox.Size = new System.Drawing.Size(410, 74);
            this.ErrorTestTextBox.TabIndex = 0;
            // 
            // TablePluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 322);
            this.Controls.Add(this.ErrorTextGroupBox);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.legsParameters);
            this.Controls.Add(this.tableTopGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(502, 360);
            this.MinimumSize = new System.Drawing.Size(502, 360);
            this.Name = "TablePluginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Плагин для построения журнального столика";
            this.ErrorTextGroupBox.ResumeLayout(false);
            this.ErrorTextGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableLegsHeightNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLegsBaseNum)).EndInit();
            this.legsParameters.ResumeLayout(false);
            this.legsParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableTopLengthNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableTopWidthNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableTopHeightNum)).EndInit();
            this.tableTopGroupBox.ResumeLayout(false);
            this.tableTopGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.GroupBox ErrorTextGroupBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown TableLegsHeightNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown TableLegsBaseNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LegsTypeComboBox;
        private System.Windows.Forms.GroupBox legsParameters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TableTopLengthNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TableTopWidthNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TableTopHeightNum;
        private System.Windows.Forms.GroupBox tableTopGroupBox;
        private System.Windows.Forms.TextBox ErrorTestTextBox;
    }
}

