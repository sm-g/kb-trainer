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
            this.labelVelocity = new System.Windows.Forms.Label();
            this.labelErrors = new System.Windows.Forms.Label();
            this.richTextBoxSourceView = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timerResultDelay = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.StartEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerUpdateWidgets = new System.Windows.Forms.Timer(this.components);
            this.AnotherTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.keyboard = new trainer.Keyboard();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelVelocity
            // 
            this.labelVelocity.AutoSize = true;
            this.labelVelocity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVelocity.Location = new System.Drawing.Point(717, 338);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelVelocity, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelErrors, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.keyboard, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 1, 0);
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
            this.panel1.Size = new System.Drawing.Size(629, 302);
            this.panel1.TabIndex = 0;
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxInput.Enabled = false;
            this.richTextBoxInput.Location = new System.Drawing.Point(0, 282);
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
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(717, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 13);
            this.labelTime.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(82, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(629, 24);
            this.progressBar.TabIndex = 6;
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
            this.StartEndToolStripMenuItem,
            this.TextToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(794, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // StartEndToolStripMenuItem
            // 
            this.StartEndToolStripMenuItem.Name = "StartEndToolStripMenuItem";
            this.StartEndToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.StartEndToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.StartEndToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.StartEndToolStripMenuItem.Text = "Старт";
            this.StartEndToolStripMenuItem.Click += new System.EventHandler(this.StartEndToolStripMenuItem_Click);
            // 
            // TextToolStripMenuItem
            // 
            this.TextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnotherTextToolStripMenuItem,
            this.toolStripSeparator1,
            this.OpenFileToolStripMenuItem,
            this.RandomTextToolStripMenuItem});
            this.TextToolStripMenuItem.Name = "TextToolStripMenuItem";
            this.TextToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.TextToolStripMenuItem.Text = "Текст";
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
            // RandomTextToolStripMenuItem
            // 
            this.RandomTextToolStripMenuItem.Checked = true;
            this.RandomTextToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RandomTextToolStripMenuItem.Name = "RandomTextToolStripMenuItem";
            this.RandomTextToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.RandomTextToolStripMenuItem.Text = "Случайный";
            this.RandomTextToolStripMenuItem.Click += new System.EventHandler(this.RandomTextToolStripMenuItem_Click);
            // 
            // timerUpdateWidgets
            // 
            this.timerUpdateWidgets.Interval = 1000;
            this.timerUpdateWidgets.Tick += new System.EventHandler(this.timerUpdateWidgets_Tick);
            // 
            // AnotherTextToolStripMenuItem
            // 
            this.AnotherTextToolStripMenuItem.Name = "AnotherTextToolStripMenuItem";
            this.AnotherTextToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.AnotherTextToolStripMenuItem.Text = "Сменить";
            this.AnotherTextToolStripMenuItem.Click += new System.EventHandler(this.AnotherTextToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // keyboard
            // 
            this.keyboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboard.Location = new System.Drawing.Point(82, 341);
            this.keyboard.Name = "keyboard";
            this.keyboard.Size = new System.Drawing.Size(629, 200);
            this.keyboard.TabIndex = 4;
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVelocity;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.RichTextBox richTextBoxSourceView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.Timer timerResultDelay;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem StartEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RandomTextToolStripMenuItem;
        private Keyboard keyboard;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timerUpdateWidgets;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem AnotherTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}