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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelVelocity = new System.Windows.Forms.Label();
            this.labelErrors = new System.Windows.Forms.Label();
            this.richTextBoxSourceView = new System.Windows.Forms.RichTextBox();
            this.pictureBoxKeyboard = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.timerResultDelay = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyboard)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelVelocity
            // 
            this.labelVelocity.AutoSize = true;
            this.labelVelocity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVelocity.Location = new System.Drawing.Point(717, 334);
            this.labelVelocity.Name = "labelVelocity";
            this.labelVelocity.Size = new System.Drawing.Size(57, 13);
            this.labelVelocity.TabIndex = 2;
            this.labelVelocity.Text = "скорость:";
            // 
            // labelErrors
            // 
            this.labelErrors.AutoSize = true;
            this.labelErrors.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelErrors.Location = new System.Drawing.Point(717, 30);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(57, 13);
            this.labelErrors.TabIndex = 1;
            this.labelErrors.Text = "ошибки: 0";
            // 
            // richTextBoxSourceView
            // 
            this.richTextBoxSourceView.BackColor = System.Drawing.Color.White;
            this.richTextBoxSourceView.DetectUrls = false;
            this.richTextBoxSourceView.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxSourceView.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxSourceView.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxSourceView.Name = "richTextBoxSourceView";
            this.richTextBoxSourceView.ReadOnly = true;
            this.richTextBoxSourceView.Size = new System.Drawing.Size(629, 202);
            this.richTextBoxSourceView.TabIndex = 0;
            this.richTextBoxSourceView.TabStop = false;
            this.richTextBoxSourceView.Text = "";
            // 
            // pictureBoxKeyboard
            // 
            this.pictureBoxKeyboard.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxKeyboard.Image")));
            this.pictureBoxKeyboard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxKeyboard.Location = new System.Drawing.Point(82, 337);
            this.pictureBoxKeyboard.Name = "pictureBoxKeyboard";
            this.pictureBoxKeyboard.Size = new System.Drawing.Size(629, 204);
            this.pictureBoxKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxKeyboard.TabIndex = 0;
            this.pictureBoxKeyboard.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxKeyboard, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelVelocity, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelErrors, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 544);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBoxInput);
            this.panel1.Controls.Add(this.richTextBoxSourceView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(82, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 298);
            this.panel1.TabIndex = 0;
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxInput.Enabled = false;
            this.richTextBoxInput.Location = new System.Drawing.Point(0, 278);
            this.richTextBoxInput.Multiline = false;
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(629, 20);
            this.richTextBoxInput.TabIndex = 0;
            this.richTextBoxInput.Text = "";
            this.richTextBoxInput.SelectionChanged += new System.EventHandler(this.richTextBoxInput_SelectionChanged);
            this.richTextBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxInput_KeyDown);
            this.richTextBoxInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxInput_KeyPress);
            this.richTextBoxInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBoxInput_KeyUp);
            // 
            // timerResultDelay
            // 
            this.timerResultDelay.Interval = 1000;
            this.timerResultDelay.Tick += new System.EventHandler(this.timerResultDelay_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripMenuItem,
            this.текстToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(794, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.StartToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.StartToolStripMenuItem.Text = "Старт";
            this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // текстToolStripMenuItem
            // 
            this.текстToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileToolStripMenuItem});
            this.текстToolStripMenuItem.Name = "текстToolStripMenuItem";
            this.текстToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.текстToolStripMenuItem.Text = "Текст";
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.OpenFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.OpenFileToolStripMenuItem.Text = "Из файла...";
            this.OpenFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Keyboard Trainer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyboard)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxKeyboard;
        private System.Windows.Forms.Label labelVelocity;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.RichTextBox richTextBoxSourceView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.Timer timerResultDelay;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текстToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
    }
}