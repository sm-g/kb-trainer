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
            this.tableLayoutPanelMainArea = new System.Windows.Forms.TableLayoutPanel();
            this.panelTypingMeasures = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelTime = new System.Windows.Forms.Label();
            this.tableLayoutPanelTextBoxes = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBoxSourceView = new System.Windows.Forms.RichTextBox();
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.panelKeyboardSettings = new System.Windows.Forms.Panel();
            this.checkBoxKeyboardLabeled = new System.Windows.Forms.CheckBox();
            this.checkBoxKeyboardColored = new System.Windows.Forms.CheckBox();
            this.timerResultDelay = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnotherTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerUpdateWidgets = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelKeyboard = new System.Windows.Forms.TableLayoutPanel();
            this.keyboard = new trainer.Keyboard();
            this.tableLayoutPanelMainArea.SuspendLayout();
            this.panelTypingMeasures.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.tableLayoutPanelTextBoxes.SuspendLayout();
            this.panelKeyboardSettings.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanelGeneral.SuspendLayout();
            this.tableLayoutPanelKeyboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelVelocity
            // 
            this.labelVelocity.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVelocity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVelocity.Location = new System.Drawing.Point(0, 76);
            this.labelVelocity.Name = "labelVelocity";
            this.labelVelocity.Size = new System.Drawing.Size(113, 27);
            this.labelVelocity.TabIndex = 2;
            this.labelVelocity.Text = "0.00";
            this.labelVelocity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelErrors
            // 
            this.labelErrors.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelErrors.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelErrors.Location = new System.Drawing.Point(0, 13);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(113, 63);
            this.labelErrors.TabIndex = 1;
            this.labelErrors.Text = "0";
            this.labelErrors.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanelMainArea
            // 
            this.tableLayoutPanelMainArea.ColumnCount = 3;
            this.tableLayoutPanelMainArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelMainArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelMainArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelMainArea.Controls.Add(this.panelTypingMeasures, 0, 0);
            this.tableLayoutPanelMainArea.Controls.Add(this.panelProgress, 2, 0);
            this.tableLayoutPanelMainArea.Controls.Add(this.tableLayoutPanelTextBoxes, 1, 0);
            this.tableLayoutPanelMainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMainArea.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanelMainArea.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMainArea.Name = "tableLayoutPanelMainArea";
            this.tableLayoutPanelMainArea.RowCount = 2;
            this.tableLayoutPanelMainArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMainArea.Size = new System.Drawing.Size(794, 314);
            this.tableLayoutPanelMainArea.TabIndex = 1;
            // 
            // panelTypingMeasures
            // 
            this.panelTypingMeasures.AutoSize = true;
            this.panelTypingMeasures.Controls.Add(this.label2);
            this.panelTypingMeasures.Controls.Add(this.labelVelocity);
            this.panelTypingMeasures.Controls.Add(this.labelErrors);
            this.panelTypingMeasures.Controls.Add(this.label1);
            this.panelTypingMeasures.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTypingMeasures.Location = new System.Drawing.Point(3, 3);
            this.panelTypingMeasures.Name = "panelTypingMeasures";
            this.panelTypingMeasures.Size = new System.Drawing.Size(113, 126);
            this.panelTypingMeasures.TabIndex = 1;
            this.panelTypingMeasures.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "зн/мин";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ошибок:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelProgress
            // 
            this.panelProgress.AutoSize = true;
            this.panelProgress.Controls.Add(this.progressBar);
            this.panelProgress.Controls.Add(this.labelTime);
            this.panelProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProgress.Location = new System.Drawing.Point(689, 3);
            this.panelProgress.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(90, 31);
            this.panelProgress.TabIndex = 10;
            this.panelProgress.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(0, 21);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(90, 10);
            this.progressBar.TabIndex = 0;
            // 
            // labelTime
            // 
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTime.Location = new System.Drawing.Point(0, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(90, 21);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "0:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanelTextBoxes
            // 
            this.tableLayoutPanelTextBoxes.ColumnCount = 1;
            this.tableLayoutPanelTextBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTextBoxes.Controls.Add(this.richTextBoxSourceView, 0, 0);
            this.tableLayoutPanelTextBoxes.Controls.Add(this.richTextBoxInput, 0, 2);
            this.tableLayoutPanelTextBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTextBoxes.Location = new System.Drawing.Point(122, 3);
            this.tableLayoutPanelTextBoxes.Name = "tableLayoutPanelTextBoxes";
            this.tableLayoutPanelTextBoxes.RowCount = 3;
            this.tableLayoutPanelTextBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.tableLayoutPanelTextBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanelTextBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanelTextBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTextBoxes.Size = new System.Drawing.Size(549, 288);
            this.tableLayoutPanelTextBoxes.TabIndex = 2;
            // 
            // richTextBoxSourceView
            // 
            this.richTextBoxSourceView.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxSourceView.DetectUrls = false;
            this.richTextBoxSourceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSourceView.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxSourceView.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxSourceView.Name = "richTextBoxSourceView";
            this.richTextBoxSourceView.ReadOnly = true;
            this.richTextBoxSourceView.Size = new System.Drawing.Size(543, 151);
            this.richTextBoxSourceView.TabIndex = 0;
            this.richTextBoxSourceView.TabStop = false;
            this.richTextBoxSourceView.Text = "";
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxInput.Enabled = false;
            this.richTextBoxInput.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxInput.Location = new System.Drawing.Point(3, 238);
            this.richTextBoxInput.Multiline = false;
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(543, 26);
            this.richTextBoxInput.TabIndex = 1;
            this.richTextBoxInput.Text = "";
            this.richTextBoxInput.SelectionChanged += new System.EventHandler(this.richTextBoxInput_SelectionChanged);
            this.richTextBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxInput_KeyDown);
            this.richTextBoxInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxInput_KeyPress);
            this.richTextBoxInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBoxInput_KeyUp);
            this.richTextBoxInput.Leave += new System.EventHandler(this.richTextBoxInput_Leave);
            // 
            // panelKeyboardSettings
            // 
            this.panelKeyboardSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKeyboardSettings.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelKeyboardSettings.Controls.Add(this.checkBoxKeyboardLabeled);
            this.panelKeyboardSettings.Controls.Add(this.checkBoxKeyboardColored);
            this.panelKeyboardSettings.Location = new System.Drawing.Point(25, 30);
            this.panelKeyboardSettings.Margin = new System.Windows.Forms.Padding(3, 30, 0, 3);
            this.panelKeyboardSettings.Name = "panelKeyboardSettings";
            this.panelKeyboardSettings.Size = new System.Drawing.Size(54, 69);
            this.panelKeyboardSettings.TabIndex = 1;
            // 
            // checkBoxKeyboardLabeled
            // 
            this.checkBoxKeyboardLabeled.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxKeyboardLabeled.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxKeyboardLabeled.Checked = true;
            this.checkBoxKeyboardLabeled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeyboardLabeled.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxKeyboardLabeled.FlatAppearance.BorderSize = 0;
            this.checkBoxKeyboardLabeled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxKeyboardLabeled.Location = new System.Drawing.Point(5, 5);
            this.checkBoxKeyboardLabeled.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxKeyboardLabeled.Name = "checkBoxKeyboardLabeled";
            this.checkBoxKeyboardLabeled.Size = new System.Drawing.Size(26, 26);
            this.checkBoxKeyboardLabeled.TabIndex = 0;
            this.checkBoxKeyboardLabeled.Text = "А";
            this.checkBoxKeyboardLabeled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxKeyboardLabeled.UseVisualStyleBackColor = false;
            this.checkBoxKeyboardLabeled.CheckedChanged += new System.EventHandler(this.checkBoxKeyboardLabeled_CheckedChanged);
            // 
            // checkBoxKeyboardColored
            // 
            this.checkBoxKeyboardColored.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxKeyboardColored.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxKeyboardColored.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxKeyboardColored.FlatAppearance.BorderSize = 0;
            this.checkBoxKeyboardColored.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxKeyboardColored.Location = new System.Drawing.Point(5, 38);
            this.checkBoxKeyboardColored.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxKeyboardColored.Name = "checkBoxKeyboardColored";
            this.checkBoxKeyboardColored.Size = new System.Drawing.Size(26, 26);
            this.checkBoxKeyboardColored.TabIndex = 1;
            this.checkBoxKeyboardColored.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxKeyboardColored.UseVisualStyleBackColor = false;
            this.checkBoxKeyboardColored.CheckedChanged += new System.EventHandler(this.checkBoxKeyboardColored_CheckedChanged);
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
            this.TextToolStripMenuItem,
            this.ProgressToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(794, 24);
            this.menuStrip.TabIndex = 0;
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
            // AnotherTextToolStripMenuItem
            // 
            this.AnotherTextToolStripMenuItem.Name = "AnotherTextToolStripMenuItem";
            this.AnotherTextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.AnotherTextToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.AnotherTextToolStripMenuItem.Text = "Сменить";
            this.AnotherTextToolStripMenuItem.Click += new System.EventHandler(this.AnotherTextToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
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
            // ProgressToolStripMenuItem
            // 
            this.ProgressToolStripMenuItem.Name = "ProgressToolStripMenuItem";
            this.ProgressToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ProgressToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.ProgressToolStripMenuItem.Text = "Прогресс";
            this.ProgressToolStripMenuItem.Click += new System.EventHandler(this.ProgressToolStripMenuItem_Click);
            // 
            // timerUpdateWidgets
            // 
            this.timerUpdateWidgets.Interval = 1000;
            this.timerUpdateWidgets.Tick += new System.EventHandler(this.timerUpdateWidgets_Tick);
            // 
            // tableLayoutPanelGeneral
            // 
            this.tableLayoutPanelGeneral.ColumnCount = 1;
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGeneral.Controls.Add(this.tableLayoutPanelKeyboard, 0, 2);
            this.tableLayoutPanelGeneral.Controls.Add(this.tableLayoutPanelMainArea, 0, 1);
            this.tableLayoutPanelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGeneral.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            this.tableLayoutPanelGeneral.RowCount = 3;
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelGeneral.Size = new System.Drawing.Size(794, 544);
            this.tableLayoutPanelGeneral.TabIndex = 2;
            // 
            // tableLayoutPanelKeyboard
            // 
            this.tableLayoutPanelKeyboard.ColumnCount = 3;
            this.tableLayoutPanelKeyboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelKeyboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelKeyboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelKeyboard.Controls.Add(this.keyboard, 1, 0);
            this.tableLayoutPanelKeyboard.Controls.Add(this.panelKeyboardSettings, 0, 0);
            this.tableLayoutPanelKeyboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelKeyboard.Location = new System.Drawing.Point(0, 334);
            this.tableLayoutPanelKeyboard.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelKeyboard.Name = "tableLayoutPanelKeyboard";
            this.tableLayoutPanelKeyboard.RowCount = 1;
            this.tableLayoutPanelKeyboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelKeyboard.Size = new System.Drawing.Size(794, 210);
            this.tableLayoutPanelKeyboard.TabIndex = 4;
            // 
            // keyboard
            // 
            this.keyboard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.keyboard.FingerZonesColored = false;
            this.keyboard.Labeled = true;
            this.keyboard.Location = new System.Drawing.Point(79, 3);
            this.keyboard.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.keyboard.MinimumSize = new System.Drawing.Size(450, 120);
            this.keyboard.Name = "keyboard";
            this.keyboard.Size = new System.Drawing.Size(632, 204);
            this.keyboard.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.tableLayoutPanelGeneral);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(480, 300);
            this.Name = "Form1";
            this.Text = "Keyboard Trainer";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.tableLayoutPanelMainArea.ResumeLayout(false);
            this.tableLayoutPanelMainArea.PerformLayout();
            this.panelTypingMeasures.ResumeLayout(false);
            this.panelProgress.ResumeLayout(false);
            this.tableLayoutPanelTextBoxes.ResumeLayout(false);
            this.panelKeyboardSettings.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanelGeneral.ResumeLayout(false);
            this.tableLayoutPanelKeyboard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVelocity;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainArea;
        private System.Windows.Forms.Timer timerResultDelay;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RandomTextToolStripMenuItem;
        private Keyboard keyboard;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timerUpdateWidgets;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem AnotherTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox checkBoxKeyboardLabeled;
        private System.Windows.Forms.CheckBox checkBoxKeyboardColored;
        private System.Windows.Forms.ToolStripMenuItem ProgressToolStripMenuItem;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTypingMeasures;
        private System.Windows.Forms.Panel panelKeyboardSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTextBoxes;
        private System.Windows.Forms.RichTextBox richTextBoxSourceView;
        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelKeyboard;
    }
}