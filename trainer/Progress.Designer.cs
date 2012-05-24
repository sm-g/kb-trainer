namespace trainer
{
    partial class Progress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
            this.exerciseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passedCharsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rhythmicityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrintingTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxGeneral, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 566);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.Location = new System.Drawing.Point(3, 3);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(364, 203);
            this.groupBoxGeneral.TabIndex = 0;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "Статистика";
            // 
            // exerciseBindingSource
            // 
            this.exerciseBindingSource.DataSource = typeof(trainer.Exercise);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.textTitleDataGridViewTextBoxColumn,
            this.speedDataGridViewTextBoxColumn,
            this.passedCharsDataGridViewTextBoxColumn,
            this.errorsDataGridViewTextBoxColumn,
            this.rhythmicityDataGridViewTextBoxColumn,
            this.totalPrintingTimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.exerciseBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 286);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 14;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(390, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 58;
            // 
            // textTitleDataGridViewTextBoxColumn
            // 
            this.textTitleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.textTitleDataGridViewTextBoxColumn.DataPropertyName = "TextTitle";
            this.textTitleDataGridViewTextBoxColumn.HeaderText = "Текст";
            this.textTitleDataGridViewTextBoxColumn.Name = "textTitleDataGridViewTextBoxColumn";
            this.textTitleDataGridViewTextBoxColumn.ReadOnly = true;
            this.textTitleDataGridViewTextBoxColumn.Width = 62;
            // 
            // speedDataGridViewTextBoxColumn
            // 
            this.speedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.speedDataGridViewTextBoxColumn.DataPropertyName = "Speed";
            this.speedDataGridViewTextBoxColumn.HeaderText = "Скорость";
            this.speedDataGridViewTextBoxColumn.Name = "speedDataGridViewTextBoxColumn";
            this.speedDataGridViewTextBoxColumn.ReadOnly = true;
            this.speedDataGridViewTextBoxColumn.Width = 80;
            // 
            // passedCharsDataGridViewTextBoxColumn
            // 
            this.passedCharsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.passedCharsDataGridViewTextBoxColumn.DataPropertyName = "PassedChars";
            this.passedCharsDataGridViewTextBoxColumn.HeaderText = "Длина";
            this.passedCharsDataGridViewTextBoxColumn.Name = "passedCharsDataGridViewTextBoxColumn";
            this.passedCharsDataGridViewTextBoxColumn.ReadOnly = true;
            this.passedCharsDataGridViewTextBoxColumn.Width = 65;
            // 
            // errorsDataGridViewTextBoxColumn
            // 
            this.errorsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.errorsDataGridViewTextBoxColumn.DataPropertyName = "Errors";
            this.errorsDataGridViewTextBoxColumn.HeaderText = "Ошибки";
            this.errorsDataGridViewTextBoxColumn.Name = "errorsDataGridViewTextBoxColumn";
            this.errorsDataGridViewTextBoxColumn.ReadOnly = true;
            this.errorsDataGridViewTextBoxColumn.Width = 72;
            // 
            // rhythmicityDataGridViewTextBoxColumn
            // 
            this.rhythmicityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.rhythmicityDataGridViewTextBoxColumn.DataPropertyName = "Rhythmicity";
            this.rhythmicityDataGridViewTextBoxColumn.HeaderText = "Ритмичность";
            this.rhythmicityDataGridViewTextBoxColumn.Name = "rhythmicityDataGridViewTextBoxColumn";
            this.rhythmicityDataGridViewTextBoxColumn.ReadOnly = true;
            this.rhythmicityDataGridViewTextBoxColumn.Width = 98;
            // 
            // totalPrintingTimeDataGridViewTextBoxColumn
            // 
            this.totalPrintingTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.totalPrintingTimeDataGridViewTextBoxColumn.DataPropertyName = "TotalPrintingTime";
            this.totalPrintingTimeDataGridViewTextBoxColumn.HeaderText = "Время";
            this.totalPrintingTimeDataGridViewTextBoxColumn.Name = "totalPrintingTimeDataGridViewTextBoxColumn";
            this.totalPrintingTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalPrintingTimeDataGridViewTextBoxColumn.Width = 65;
            // 
            // Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Progress";
            this.Text = "Прогресс";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exerciseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxGeneral;
        private System.Windows.Forms.BindingSource exerciseBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passedCharsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rhythmicityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrintingTimeDataGridViewTextBoxColumn;
    }
}