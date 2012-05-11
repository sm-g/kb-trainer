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

        public void Add(List<Keystroke> keystrokes)
        {
            int span = Statistic.TypingSpeed.FitInstantSpeedSpan(keystrokes.Count);
            for (int i = span; i < keystrokes.Count - 1; i += span)
            {
                chart.Series[0].Points.AddXY(i, Statistic.TypingSpeed.GetInstant(keystrokes[i - span].DownTime,
                                                                                 keystrokes[i].DownTime,
                                                                                 span));
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
