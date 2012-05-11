namespace trainer
{
    partial class Result
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
            this.buttonEnd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxErrors = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAvSpeed = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.graph = new trainer.Graph();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEnd
            // 
            this.buttonEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonEnd.AutoSize = true;
            this.buttonEnd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonEnd.Location = new System.Drawing.Point(61, 143);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(75, 23);
            this.buttonEnd.TabIndex = 0;
            this.buttonEnd.Text = "Закончить";
            this.buttonEnd.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonContinue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonEnd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.graph, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 176);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxErrors, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxAvSpeed, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxTime, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelTime, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(191, 60);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxErrors.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxErrors.Location = new System.Drawing.Point(98, 23);
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.ReadOnly = true;
            this.textBoxErrors.Size = new System.Drawing.Size(90, 13);
            this.textBoxErrors.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Скорость:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 23);
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
            this.textBoxAvSpeed.Location = new System.Drawing.Point(98, 3);
            this.textBoxAvSpeed.Name = "textBoxAvSpeed";
            this.textBoxAvSpeed.ReadOnly = true;
            this.textBoxAvSpeed.Size = new System.Drawing.Size(90, 13);
            this.textBoxAvSpeed.TabIndex = 1;
            // 
            // textBoxTime
            // 
            this.textBoxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTime.Location = new System.Drawing.Point(98, 43);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(90, 13);
            this.textBoxTime.TabIndex = 5;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(49, 43);
            this.labelTime.Margin = new System.Windows.Forms.Padding(3);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(43, 13);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "Время:";
            // 
            // buttonContinue
            // 
            this.buttonContinue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonContinue.AutoSize = true;
            this.buttonContinue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonContinue.Location = new System.Drawing.Point(255, 143);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(80, 23);
            this.buttonContinue.TabIndex = 1;
            this.buttonContinue.Text = "Продолжить";
            this.buttonContinue.UseVisualStyleBackColor = true;
            // 
            // graph
            // 
            this.graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graph.Location = new System.Drawing.Point(200, 3);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(191, 134);
            this.graph.TabIndex = 3;
            // 
            // Result
            // 
            this.AcceptButton = this.buttonEnd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonContinue;
            this.ClientSize = new System.Drawing.Size(394, 176);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Result";
            this.Text = "Результат";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxErrors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAvSpeed;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonContinue;
        private Graph graph;
    }
}