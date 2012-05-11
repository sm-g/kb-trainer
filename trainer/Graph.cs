using System.Collections.Generic;
using System.Drawing;
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
    }
}
