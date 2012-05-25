using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace trainer
{
    public partial class Graph : UserControl
    {
        public Graph()
        {
            InitializeComponent();
        }
        
        public void AddInstantSpeed(List<Keystroke> keystrokes, string serieName)
        {
            if (chart.Series.IndexOf(serieName) == -1)
            {
                chart.Series.Add(serieName);
                chart.Series[serieName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart.Series[serieName].ToolTip = "#VAL{N2}";

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
                chart.Series.Add(serieName);
                chart.Series[serieName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart.Series[serieName].ToolTip = "#VAL{N2}";

                int span = Statistic.TypingSpeed.FitInstantSpeedSpan(keystrokes.Count);
                double speed;
                for (int i = span; i < keystrokes.Count; i += span)
                {
                    speed = Statistic.TypingSpeed.GetAverage(keystrokes[i].DownTime, i);
                    chart.Series[serieName].Points.AddXY(i, speed);
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
