namespace trainer
{
    partial class Graph
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStripGraph = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogGraph = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.contextMenuStripGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisX.MaximumAutoSize = 30F;
            chartArea3.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisY.MaximumAutoSize = 30F;
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Name = "Series1";
            series3.ToolTip = "#VAL{N2}";
            series3.YValuesPerPoint = 2;
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(150, 150);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            this.chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart_MouseClick);
            // 
            // contextMenuStripGraph
            // 
            this.contextMenuStripGraph.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveGraphToolStripMenuItem});
            this.contextMenuStripGraph.Name = "contextMenuStripGraph";
            this.contextMenuStripGraph.ShowImageMargin = false;
            this.contextMenuStripGraph.Size = new System.Drawing.Size(117, 26);
            // 
            // SaveGraphToolStripMenuItem
            // 
            this.SaveGraphToolStripMenuItem.Name = "SaveGraphToolStripMenuItem";
            this.SaveGraphToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.SaveGraphToolStripMenuItem.Text = "Сохранить...";
            this.SaveGraphToolStripMenuItem.Click += new System.EventHandler(this.SaveGraphToolStripMenuItem_Click);
            // 
            // saveFileDialogGraph
            // 
            this.saveFileDialogGraph.Filter = "PNG|*.png";
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart);
            this.Name = "Graph";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.contextMenuStripGraph.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGraph;
        private System.Windows.Forms.ToolStripMenuItem SaveGraphToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogGraph;
    }
}
