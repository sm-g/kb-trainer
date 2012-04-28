namespace trainer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelVelocity = new System.Windows.Forms.Label();
            this.labelErrors = new System.Windows.Forms.Label();
            this.richTextBoxSourceView = new System.Windows.Forms.RichTextBox();
            this.pictureBoxKeyboard = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyboard)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelVelocity
            // 
            this.labelVelocity.AutoSize = true;
            this.labelVelocity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVelocity.Location = new System.Drawing.Point(699, 284);
            this.labelVelocity.Name = "labelVelocity";
            this.labelVelocity.Size = new System.Drawing.Size(57, 13);
            this.labelVelocity.TabIndex = 2;
            this.labelVelocity.Text = "скорость:";
            // 
            // labelErrors
            // 
            this.labelErrors.AutoSize = true;
            this.labelErrors.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelErrors.Location = new System.Drawing.Point(699, 0);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(57, 13);
            this.labelErrors.TabIndex = 1;
            this.labelErrors.Text = "ошибки: 0";
            // 
            // richTextBoxSourceView
            // 
            this.richTextBoxSourceView.DetectUrls = false;
            this.richTextBoxSourceView.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxSourceView.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxSourceView.Name = "richTextBoxSourceView";
            this.richTextBoxSourceView.ReadOnly = true;
            this.richTextBoxSourceView.Size = new System.Drawing.Size(690, 202);
            this.richTextBoxSourceView.TabIndex = 0;
            this.richTextBoxSourceView.TabStop = false;
            this.richTextBoxSourceView.Text = "";
            // 
            // pictureBoxKeyboard
            // 
            this.pictureBoxKeyboard.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxKeyboard.Image")));
            this.pictureBoxKeyboard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxKeyboard.Location = new System.Drawing.Point(3, 287);
            this.pictureBoxKeyboard.Name = "pictureBoxKeyboard";
            this.pictureBoxKeyboard.Size = new System.Drawing.Size(675, 204);
            this.pictureBoxKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxKeyboard.TabIndex = 0;
            this.pictureBoxKeyboard.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.75253F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.24747F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxKeyboard, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelVelocity, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelErrors, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 568);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBoxInput);
            this.panel1.Controls.Add(this.richTextBoxSourceView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 278);
            this.panel1.TabIndex = 0;
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxInput.Location = new System.Drawing.Point(0, 258);
            this.richTextBoxInput.Multiline = false;
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(690, 20);
            this.richTextBoxInput.TabIndex = 2;
            this.richTextBoxInput.Text = "";
            this.richTextBoxInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxInput_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Keyboard Trainer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyboard)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxKeyboard;
        private System.Windows.Forms.Label labelVelocity;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.RichTextBox richTextBoxSourceView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBoxInput;
    }
}