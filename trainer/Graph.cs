using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace trainer
{
    public partial class Graph : UserControl
    {
        public Graph()
        {
            InitializeComponent();
        }
        
        private void PrepareSerie(string serieName, SeriesChartType type = SeriesChartType.Line, MarkerStyle marker = MarkerStyle.None)
        {
            chart.Series.Add(serieName);
            chart.Series[serieName].ChartType = type;
            chart.Series[serieName].MarkerStyle = marker;
            chart.Series[serieName].ToolTip = "#VAL{N2}";
        }

        public void AddInstantSpeed(List<Keystroke> keystrokes, string serieName)
        {
            if (chart.Series.IndexOf(serieName) == -1)
            {
                PrepareSerie(serieName);

                int span = Statistic.TypingSpeed.FitInstantSpeedSpan(keystrokes.Count);
                double speed;
                for (int i = span; i < keystrokes.Count; i += span)
                {
                    speed = Statistic.TypingSpeed.GetInstant(keystrokes[i - span].DownTime, keystrokes[i].DownTime, span);
                    chart.Series[serieName].Points.AddXY(i, speed);
                }
            }
        }
        public void AddAverageSpeed(List<Keystroke> keystrokes, string serieName)
        {
            if (chart.Series.IndexOf(serieName) == -1)
            {
                PrepareSerie(serieName);

                int span = Statistic.TypingSpeed.FitInstantSpeedSpan(keystrokes.Count);
                double speed;
                for (int i = span; i < keystrokes.Count; i += span)
                {
                    speed = Statistic.TypingSpeed.GetAverage(keystrokes[i].DownTime, i);
                    chart.Series[serieName].Points.AddXY(i, speed);
                }
            }
        }

        public void Bind(LoadedExercise[] exercises, string serieName, string xValues, string yValues)
        {
            chart.DataSource = exercises;
            PrepareSerie(serieName, SeriesChartType.Line, MarkerStyle.Circle);

            chart.Series[serieName].XValueMember = xValues;
            chart.Series[serieName].YValueMembers = yValues;
        }

        public void HighlightSeriePoints(string serieName, int[] ids)
        {
            if (chart.Series[serieName].Points.Count != 0)
            {
                foreach (var p in chart.Series[serieName].Points)
                {
                    p.MarkerColor = Color.Blue;
                }

                foreach (int id in ids)
                {
                    chart.Series[serieName].Points.FindByValue(id, "X").MarkerColor = Color.Orange;
                }
            }
        }

        private void SaveGraphToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialogGraph.ShowDialog() == DialogResult.OK)
            {
                chart.SaveImage(saveFileDialogGraph.FileName, ImageFormat.Png);
            }
        }
        private void chart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                contextMenuStripGraph.Show(this, e.Location);
        }
    }
}
