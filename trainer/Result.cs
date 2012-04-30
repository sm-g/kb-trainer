using System;
using System.Windows.Forms;

namespace trainer
{
    public partial class Result : Form
    {
        public Result(ResultInfo info)
        {
            InitializeComponent();

            textBoxAvSpeed.Text = info.Speed.ToString("F") + " зн/мин";
            textBoxErrors.Text = ((double)info.Errors / info.PassedChars).ToString("F2") + " %";
            TimeSpan time = TimeSpan.FromMilliseconds(info.Keystrokes[info.Keystrokes.Count - 1].DownTime);
            string formattedTime = string.Format("{0}{1}{2}", time.Hours > 0 ? string.Format("{0:0}:", time.Hours) : string.Empty,
                string.Format("{0:0}:", time.Minutes),
                string.Format("{0:00}", time.Seconds));
            textBoxTime.Text = formattedTime;
        }
    }
}
