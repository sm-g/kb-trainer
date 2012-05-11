﻿using System.Collections.Generic;
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

        private int FitSpan(int count)
        {
            if (count < 10)
                return 1;
            if (count < 50)
                return 2;
            return 3;
        }

        public void Add(List<Keystroke> keystrokes)
        {
            int span = FitSpan(keystrokes.Count);
            for (int i = span; i < keystrokes.Count - 1; i += span)
                chart.Series[0].Points.AddXY(i, Statistic.Velocity.GetInstant(keystrokes[i - span].DownTime, keystrokes[i].DownTime, span));
        }
    }
}