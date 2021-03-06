﻿using System;
using System.Windows.Forms;
using System.Drawing;

namespace trainer
{
    public partial class ResultForm : Form
    {
        public ResultForm(FinalizedExercise result, SourceText source)
        {
            InitializeComponent();

            if (source.Length == result.PassedChars)
            {
                buttonContinue.Enabled = false;
                CancelButton = buttonEnd;
            }

            textBoxAvSpeed.Text = result.Speed.ToString("F") + " зн/мин";
            textBoxErrors.Text = result.ErrorsPercent.ToString("F2") + " %";
            textBoxTime.Text = result.FormattedTime;
            textBoxRhithmicity.Text = result.Rhythmicity.ToString() + " %";

            graph.AddInstantSpeed(result.Keystrokes, "instantspeed");
            graph.AddAverageSpeed(result.Keystrokes, "averagespeed");
        }

        public static string FormatTimeSpan(TimeSpan timespan)
        {
            string hours = timespan.Hours > 0 ? string.Format("{0:0}:", timespan.Hours) : string.Empty;
            return String.Format("{0}{1:0}:{2:00}", hours, timespan.Minutes, timespan.Seconds);
        }
    }
}
