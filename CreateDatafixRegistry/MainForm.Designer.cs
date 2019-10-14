namespace CreateDatafixRegistry
{
    partial class MainForm
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
            this.LbRelease = new System.Windows.Forms.Label();
            this.TbRelease = new System.Windows.Forms.TextBox();
            this.BtRelease = new System.Windows.Forms.Button();
            this.LboxExcelFileList = new System.Windows.Forms.ListBox();
            this.LbExcelFileList = new System.Windows.Forms.Label();
            this.BtDF = new System.Windows.Forms.Button();
            this.BtPPF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbRelease
            // 
            this.LbRelease.AutoSize = true;
            this.LbRelease.Location = new System.Drawing.Point(12, 9);
            this.LbRelease.Name = "LbRelease";
            this.LbRelease.Size = new System.Drawing.Size(56, 13);
            this.LbRelease.TabIndex = 0;
            this.LbRelease.Text = "Поставка";
            // 
            // TbRelease
            // 
            this.TbRelease.Location = new System.Drawing.Point(74, 9);
            this.TbRelease.Name = "TbRelease";
            this.TbRelease.Size = new System.Drawing.Size(257, 20);
            this.TbRelease.TabIndex = 1;
            // 
            // BtRelease
            // 
            this.BtRelease.Location = new System.Drawing.Point(337, 7);
            this.BtRelease.Name = "BtRelease";
            this.BtRelease.Size = new System.Drawing.Size(75, 23);
            this.BtRelease.TabIndex = 2;
            this.BtRelease.Text = "Задать";
            this.BtRelease.UseVisualStyleBackColor = true;
            this.BtRelease.Click += new System.EventHandler(this.BtRelease_Click);
            // 
            // LboxExcelFileList
            // 
            this.LboxExcelFileList.FormattingEnabled = true;
            this.LboxExcelFileList.Location = new System.Drawing.Point(10, 57);
            this.LboxExcelFileList.Name = "LboxExcelFileList";
            this.LboxExcelFileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LboxExcelFileList.Size = new System.Drawing.Size(397, 147);
            this.LboxExcelFileList.TabIndex = 3;
            // 
            // LbExcelFileList
            // 
            this.LbExcelFileList.AutoSize = true;
            this.LbExcelFileList.Location = new System.Drawing.Point(12, 41);
            this.LbExcelFileList.Name = "LbExcelFileList";
            this.LbExcelFileList.Size = new System.Drawing.Size(118, 13);
            this.LbExcelFileList.TabIndex = 4;
            this.LbExcelFileList.Text = "Список всех экселек:";
            // 
            // BtDF
            // 
            this.BtDF.Location = new System.Drawing.Point(15, 211);
            this.BtDF.Name = "BtDF";
            this.BtDF.Size = new System.Drawing.Size(123, 23);
            this.BtDF.TabIndex = 5;
            this.BtDF.Text = "Создать реестр DF";
            this.BtDF.UseVisualStyleBackColor = true;
            this.BtDF.Click += new System.EventHandler(this.BtDF_Click);
            // 
            // BtPPF
            // 
            this.BtPPF.Location = new System.Drawing.Point(144, 210);
            this.BtPPF.Name = "BtPPF";
            this.BtPPF.Size = new System.Drawing.Size(123, 23);
            this.BtPPF.TabIndex = 6;
            this.BtPPF.Text = "Создать реестр PPF";
            this.BtPPF.UseVisualStyleBackColor = true;
            this.BtPPF.Click += new System.EventHandler(this.BtPPF_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 240);
            this.Controls.Add(this.BtPPF);
            this.Controls.Add(this.BtDF);
            this.Controls.Add(this.LbExcelFileList);
            this.Controls.Add(this.LboxExcelFileList);
            this.Controls.Add(this.BtRelease);
            this.Controls.Add(this.TbRelease);
            this.Controls.Add(this.LbRelease);
            this.Name = "MainForm";
            this.Text = "Сбор реестра датафиксов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbRelease;
        private System.Windows.Forms.TextBox TbRelease;
        private System.Windows.Forms.Button BtRelease;
        private System.Windows.Forms.ListBox LboxExcelFileList;
        private System.Windows.Forms.Label LbExcelFileList;
        private System.Windows.Forms.Button BtDF;
        private System.Windows.Forms.Button BtPPF;
    }
}

