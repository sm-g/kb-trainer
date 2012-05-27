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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
            this.buttonLast10 = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxErrors = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAvSpeed = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxRhithmicity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passedCharsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formattedTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorsPercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rhythmicityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadedExerciseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.graph = new trainer.Graph();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxGeneral.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadedExerciseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.dgv, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 566);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.textTitleDataGridViewTextBoxColumn,
            this.passedCharsDataGridViewTextBoxColumn,
            this.formattedTimeDataGridViewTextBoxColumn,
            this.speedDataGridViewTextBoxColumn,
            this.errorsPercentDataGridViewTextBoxColumn,
            this.rhythmicityDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.loadedExerciseBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 3);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.RowTemplate.Height = 14;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(469, 560);
            this.dgv.TabIndex = 2;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.graph, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxGeneral, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(478, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(311, 560);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.Controls.Add(this.buttonLast10);
            this.groupBoxGeneral.Controls.Add(this.buttonAll);
            this.groupBoxGeneral.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGeneral.Location = new System.Drawing.Point(3, 378);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(305, 179);
            this.groupBoxGeneral.TabIndex = 0;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "Статистика";
            // 
            // buttonLast10
            // 
            this.buttonLast10.AutoSize = true;
            this.buttonLast10.Location = new System.Drawing.Point(106, 19);
            this.buttonLast10.Name = "buttonLast10";
            this.buttonLast10.Size = new System.Drawing.Size(94, 32);
            this.buttonLast10.TabIndex = 5;
            this.buttonLast10.Text = "Последние 10";
            this.buttonLast10.UseVisualStyleBackColor = true;
            this.buttonLast10.Click += new System.EventHandler(this.buttonLast10_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.AutoSize = true;
            this.buttonAll.Location = new System.Drawing.Point(6, 19);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(94, 32);
            this.buttonAll.TabIndex = 4;
            this.buttonAll.Text = "Выбрать всё";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.textBoxCount, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxErrors, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.textBoxAvSpeed, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelTime, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxTime, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxRhithmicity, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(50, 45, 0, 0);
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(299, 160);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // textBoxCount
            // 
            this.textBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCount.Location = new System.Drawing.Point(153, 48);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.ReadOnly = true;
            this.textBoxCount.Size = new System.Drawing.Size(144, 13);
            this.textBoxCount.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Выбрано:";
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxErrors.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxErrors.Location = new System.Drawing.Point(153, 118);
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.ReadOnly = true;
            this.textBoxErrors.Size = new System.Drawing.Size(144, 13);
            this.textBoxErrors.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Скорость:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ошибок:";
            // 
            // textBoxAvSpeed
            // 
            this.textBoxAvSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAvSpeed.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxAvSpeed.Location = new System.Drawing.Point(153, 98);
            this.textBoxAvSpeed.Name = "textBoxAvSpeed";
            this.textBoxAvSpeed.ReadOnly = true;
            this.textBoxAvSpeed.Size = new System.Drawing.Size(144, 13);
            this.textBoxAvSpeed.TabIndex = 1;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(53, 68);
            this.labelTime.Margin = new System.Windows.Forms.Padding(3);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(43, 13);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "Время:";
            // 
            // textBoxTime
            // 
            this.textBoxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTime.Location = new System.Drawing.Point(153, 68);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(144, 13);
            this.textBoxTime.TabIndex = 5;
            // 
            // textBoxRhithmicity
            // 
            this.textBoxRhithmicity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRhithmicity.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxRhithmicity.Location = new System.Drawing.Point(153, 138);
            this.textBoxRhithmicity.Name = "textBoxRhithmicity";
            this.textBoxRhithmicity.ReadOnly = true;
            this.textBoxRhithmicity.Size = new System.Drawing.Size(144, 13);
            this.textBoxRhithmicity.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ритмичность:";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 5;
            // 
            // textTitleDataGridViewTextBoxColumn
            // 
            this.textTitleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textTitleDataGridViewTextBoxColumn.DataPropertyName = "TextTitle";
            this.textTitleDataGridViewTextBoxColumn.HeaderText = "Текст";
            this.textTitleDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.textTitleDataGridViewTextBoxColumn.Name = "textTitleDataGridViewTextBoxColumn";
            this.textTitleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passedCharsDataGridViewTextBoxColumn
            // 
            this.passedCharsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.passedCharsDataGridViewTextBoxColumn.DataPropertyName = "PassedChars";
            this.passedCharsDataGridViewTextBoxColumn.HeaderText = "Напечатано";
            this.passedCharsDataGridViewTextBoxColumn.Name = "passedCharsDataGridViewTextBoxColumn";
            this.passedCharsDataGridViewTextBoxColumn.ReadOnly = true;
            this.passedCharsDataGridViewTextBoxColumn.Width = 5;
            // 
            // formattedTimeDataGridViewTextBoxColumn
            // 
            this.formattedTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.formattedTimeDataGridViewTextBoxColumn.DataPropertyName = "FormattedTime";
            this.formattedTimeDataGridViewTextBoxColumn.HeaderText = "Время";
            this.formattedTimeDataGridViewTextBoxColumn.Name = "formattedTimeDataGridViewTextBoxColumn";
            this.formattedTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.formattedTimeDataGridViewTextBoxColumn.Width = 5;
            // 
            // speedDataGridViewTextBoxColumn
            // 
            this.speedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.speedDataGridViewTextBoxColumn.DataPropertyName = "Speed";
            this.speedDataGridViewTextBoxColumn.FillWeight = 50F;
            this.speedDataGridViewTextBoxColumn.HeaderText = "Скорость";
            this.speedDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.speedDataGridViewTextBoxColumn.Name = "speedDataGridViewTextBoxColumn";
            this.speedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // errorsPercentDataGridViewTextBoxColumn
            // 
            this.errorsPercentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.errorsPercentDataGridViewTextBoxColumn.DataPropertyName = "ErrorsPercent";
            this.errorsPercentDataGridViewTextBoxColumn.HeaderText = "Ошибок";
            this.errorsPercentDataGridViewTextBoxColumn.Name = "errorsPercentDataGridViewTextBoxColumn";
            this.errorsPercentDataGridViewTextBoxColumn.ReadOnly = true;
            this.errorsPercentDataGridViewTextBoxColumn.Width = 5;
            // 
            // rhythmicityDataGridViewTextBoxColumn
            // 
            this.rhythmicityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.rhythmicityDataGridViewTextBoxColumn.DataPropertyName = "Rhythmicity";
            this.rhythmicityDataGridViewTextBoxColumn.HeaderText = "Ритмичность";
            this.rhythmicityDataGridViewTextBoxColumn.Name = "rhythmicityDataGridViewTextBoxColumn";
            this.rhythmicityDataGridViewTextBoxColumn.ReadOnly = true;
            this.rhythmicityDataGridViewTextBoxColumn.Width = 5;
            // 
            // loadedExerciseBindingSource
            // 
            this.loadedExerciseBindingSource.DataSource = typeof(trainer.FinalizedExercise);
            // 
            // graph
            // 
            this.graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graph.Location = new System.Drawing.Point(3, 3);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(305, 369);
            this.graph.TabIndex = 3;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadedExerciseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxGeneral;
        private System.Windows.Forms.DataGridView dgv;
        private Graph graph;
        private System.Windows.Forms.BindingSource loadedExerciseBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRhithmicity;
        private System.Windows.Forms.TextBox textBoxErrors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAvSpeed;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passedCharsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formattedTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorsPercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rhythmicityDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonLast10;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label label4;
    }
}