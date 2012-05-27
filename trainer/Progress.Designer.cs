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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.loadedExerciseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.graph = new trainer.Graph();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passedChars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rhythmicity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadedExerciseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxGeneral, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.graph, 1, 0);
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
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.date,
            this.textTitle,
            this.AverageSpeed,
            this.passedChars,
            this.errors,
            this.rhythmicity,
            this.FormattedTime});
            this.dgv.DataSource = this.loadedExerciseBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 286);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.RowTemplate.Height = 14;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(390, 277);
            this.dgv.TabIndex = 2;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // loadedExerciseBindingSource
            // 
            this.loadedExerciseBindingSource.DataSource = typeof(trainer.LoadedExercise);
            // 
            // graph
            // 
            this.graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graph.Location = new System.Drawing.Point(399, 3);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(390, 277);
            this.graph.TabIndex = 3;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 22;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.date.DataPropertyName = "Date";
            this.date.HeaderText = "Дата";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 58;
            // 
            // textTitle
            // 
            this.textTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textTitle.DataPropertyName = "TextTitle";
            this.textTitle.HeaderText = "Текст";
            this.textTitle.MinimumWidth = 30;
            this.textTitle.Name = "textTitle";
            this.textTitle.ReadOnly = true;
            // 
            // AverageSpeed
            // 
            this.AverageSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.AverageSpeed.DataPropertyName = "AverageSpeed";
            this.AverageSpeed.HeaderText = "Скорость";
            this.AverageSpeed.Name = "AverageSpeed";
            this.AverageSpeed.ReadOnly = true;
            this.AverageSpeed.Width = 5;
            // 
            // passedChars
            // 
            this.passedChars.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.passedChars.DataPropertyName = "PassedChars";
            this.passedChars.HeaderText = "Длина";
            this.passedChars.Name = "passedChars";
            this.passedChars.ReadOnly = true;
            this.passedChars.Width = 5;
            // 
            // errors
            // 
            this.errors.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.errors.DataPropertyName = "Errors";
            this.errors.HeaderText = "Ошибки";
            this.errors.Name = "errors";
            this.errors.ReadOnly = true;
            this.errors.Width = 5;
            // 
            // rhythmicity
            // 
            this.rhythmicity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.rhythmicity.DataPropertyName = "Rhythmicity";
            this.rhythmicity.HeaderText = "Ритмичность";
            this.rhythmicity.Name = "rhythmicity";
            this.rhythmicity.ReadOnly = true;
            this.rhythmicity.Width = 5;
            // 
            // FormattedTime
            // 
            this.FormattedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.FormattedTime.DataPropertyName = "FormattedTime";
            this.FormattedTime.HeaderText = "Время";
            this.FormattedTime.Name = "FormattedTime";
            this.FormattedTime.ReadOnly = true;
            this.FormattedTime.Width = 5;
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
            ((System.ComponentModel.ISupportInitialize)(this.loadedExerciseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxGeneral;
        private System.Windows.Forms.DataGridView dgv;
        private Graph graph;
        private System.Windows.Forms.DataGridViewTextBoxColumn speed;
        private System.Windows.Forms.BindingSource loadedExerciseBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn textTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn passedChars;
        private System.Windows.Forms.DataGridViewTextBoxColumn errors;
        private System.Windows.Forms.DataGridViewTextBoxColumn rhythmicity;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedTime;
    }
}