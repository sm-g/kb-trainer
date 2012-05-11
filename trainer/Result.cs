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

            if (source.Length <= result.PassedChars) // нельзя продолжить
            {
                buttonContinue.Enabled = false;
                CancelButton = buttonEnd;
            }

            TimeSpan time = result.Keystrokes[result.Keystrokes.Count - 1].DownTime;
            string hours = time.Hours > 0 ? string.Format("{0:0}:", time.Hours) : string.Empty;
            string formattedTime = string.Format("{0}{1:0}:{2:00}", hours, time.Minutes, time.Seconds);

            textBoxAvSpeed.Text = result.Speed.ToString("F") + " зн/мин";
            textBoxErrors.Text = ((double)result.Errors / result.PassedChars).ToString("F2") + " %";
            textBoxTime.Text = formattedTime;

            graph.Add(result.Keystrokes);
        }
    }
}
