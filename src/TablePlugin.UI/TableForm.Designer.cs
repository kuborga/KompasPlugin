
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
            this.tableTopGroupBox = new System.Windows.Forms.GroupBox();
            this.tableTopHeightNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tableTopWidthNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tableTopLengthNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.legsParameters = new System.Windows.Forms.GroupBox();
            this.tableLegsDiameterNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLegsHeightNum = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.BuildButton = new System.Windows.Forms.Button();
            this.tableTopGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopHeightNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopWidthNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopLengthNum)).BeginInit();
            this.legsParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsDiameterNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsHeightNum)).BeginInit();
            this.SuspendLayout();
            // 
            // tableTopGroupBox
            // 
            this.tableTopGroupBox.Controls.Add(this.tableTopHeightNum);
            this.tableTopGroupBox.Controls.Add(this.label3);
            this.tableTopGroupBox.Controls.Add(this.tableTopWidthNum);
            this.tableTopGroupBox.Controls.Add(this.label2);
            this.tableTopGroupBox.Controls.Add(this.tableTopLengthNum);
            this.tableTopGroupBox.Controls.Add(this.label1);
            this.tableTopGroupBox.Location = new System.Drawing.Point(33, 24);
            this.tableTopGroupBox.Name = "tableTopGroupBox";
            this.tableTopGroupBox.Size = new System.Drawing.Size(200, 118);
            this.tableTopGroupBox.TabIndex = 0;
            this.tableTopGroupBox.TabStop = false;
            this.tableTopGroupBox.Text = "Параметры столешницы";
            // 
            // tableTopHeightNum
            // 
            this.tableTopHeightNum.Location = new System.Drawing.Point(144, 91);
            this.tableTopHeightNum.Name = "tableTopHeightNum";
            this.tableTopHeightNum.Size = new System.Drawing.Size(50, 20);
            this.tableTopHeightNum.TabIndex = 5;
            this.tableTopHeightNum.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
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
            // tableTopWidthNum
            // 
            this.tableTopWidthNum.Location = new System.Drawing.Point(144, 57);
            this.tableTopWidthNum.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.tableTopWidthNum.Name = "tableTopWidthNum";
            this.tableTopWidthNum.Size = new System.Drawing.Size(50, 20);
            this.tableTopWidthNum.TabIndex = 3;
            this.tableTopWidthNum.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
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
            // tableTopLengthNum
            // 
            this.tableTopLengthNum.Location = new System.Drawing.Point(144, 23);
            this.tableTopLengthNum.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.tableTopLengthNum.Name = "tableTopLengthNum";
            this.tableTopLengthNum.Size = new System.Drawing.Size(50, 20);
            this.tableTopLengthNum.TabIndex = 1;
            this.tableTopLengthNum.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
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
            // legsParameters
            // 
            this.legsParameters.Controls.Add(this.tableLegsDiameterNum);
            this.legsParameters.Controls.Add(this.label5);
            this.legsParameters.Controls.Add(this.tableLegsHeightNum);
            this.legsParameters.Controls.Add(this.label6);
            this.legsParameters.Location = new System.Drawing.Point(33, 161);
            this.legsParameters.Name = "legsParameters";
            this.legsParameters.Size = new System.Drawing.Size(200, 94);
            this.legsParameters.TabIndex = 1;
            this.legsParameters.TabStop = false;
            this.legsParameters.Text = "Параметры ножек";
            // 
            // tableLegsDiameterNum
            // 
            this.tableLegsDiameterNum.Location = new System.Drawing.Point(144, 57);
            this.tableLegsDiameterNum.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.tableLegsDiameterNum.Name = "tableLegsDiameterNum";
            this.tableLegsDiameterNum.Size = new System.Drawing.Size(50, 20);
            this.tableLegsDiameterNum.TabIndex = 3;
            this.tableLegsDiameterNum.Value = new decimal(new int[] {
            125,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Диаметр (50 - 200) мм";
            // 
            // tableLegsHeightNum
            // 
            this.tableLegsHeightNum.Location = new System.Drawing.Point(144, 23);
            this.tableLegsHeightNum.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.tableLegsHeightNum.Name = "tableLegsHeightNum";
            this.tableLegsHeightNum.Size = new System.Drawing.Size(50, 20);
            this.tableLegsHeightNum.TabIndex = 1;
            this.tableLegsHeightNum.Value = new decimal(new int[] {
            550,
            0,
            0,
            0});
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
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(53, 261);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(160, 35);
            this.BuildButton.TabIndex = 2;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // TablePluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 312);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.legsParameters);
            this.Controls.Add(this.tableTopGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(280, 350);
            this.MinimumSize = new System.Drawing.Size(280, 350);
            this.Name = "TablePluginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TablePlugin";
            this.tableTopGroupBox.ResumeLayout(false);
            this.tableTopGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopHeightNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopWidthNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopLengthNum)).EndInit();
            this.legsParameters.ResumeLayout(false);
            this.legsParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsDiameterNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsHeightNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox tableTopGroupBox;
        private System.Windows.Forms.NumericUpDown tableTopHeightNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tableTopWidthNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown tableTopLengthNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox legsParameters;
        private System.Windows.Forms.NumericUpDown tableLegsDiameterNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown tableLegsHeightNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BuildButton;
    }
}

