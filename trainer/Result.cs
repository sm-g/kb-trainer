using System;
using System.Windows.Forms;
using System.Drawing;

namespace trainer
{
    public partial class Result : Form
    {
        public Result(ResultInfo info, SourceInfo source)
        {
            InitializeComponent();

            if (source.Length <= info.PassedChars) // нельзя продолжить
            {
                buttonContinue.Enabled = false;
                AcceptButton = buttonOk;
                CancelButton = buttonOk;
            }

            textBoxAvSpeed.Text = info.Speed.ToString("F") + " зн/мин";
            textBoxErrors.Text = ((double)info.Errors / info.PassedChars).ToString("F2") + " %";
            TimeSpan time = info.Keystrokes[info.Keystrokes.Count - 1].DownTime;
            string formattedTime = string.Format("{0}{1}{2}", time.Hours > 0 ? string.Format("{0:0}:", time.Hours) : string.Empty,
                string.Format("{0:0}:", time.Minutes),
                string.Format("{0:00}", time.Seconds));
            textBoxTime.Text = formattedTime;

            graph.Add(info.Keystrokes);
        }
    }
}
