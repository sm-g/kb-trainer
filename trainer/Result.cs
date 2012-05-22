using System;
using System.Windows.Forms;
using System.Drawing;

namespace trainer
{
    public partial class Result : Form
    {
        public Result(ResultInfo result, SourceInfo source)
        {
            InitializeComponent();

            if (source.Length == result.PassedChars) // нельзя продолжить
            {
                buttonContinue.Enabled = false;
                CancelButton = buttonEnd;
            }

            TimeSpan time = result.Keystrokes[result.Keystrokes.Count - 1].DownTime;

            textBoxAvSpeed.Text = result.Speed.ToString("F") + " зн/мин";
            textBoxErrors.Text = ((double)result.Errors / result.PassedChars).ToString("F2") + " %";
            textBoxTime.Text = FormatTimeSpan(time);

            graph.Add(result.Keystrokes);
        }

        public static string FormatTimeSpan(TimeSpan timespan)
        {
            string hours = timespan.Hours > 0 ? string.Format("{0:0}:", timespan.Hours) : string.Empty;
            return String.Format("{0}{1:0}:{2:00}", hours, timespan.Minutes, timespan.Seconds);
        }
    }
}
