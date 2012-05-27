using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace trainer
{
    public partial class Progress : Form
    {
        private const string FileName = "statistic.txt";
        private const char ExerciseDelimeter = '\n';
        public const char AttributeDelimeter = ';';
        public const char SafeChar = ',';

        public Progress()
        {
            InitializeComponent();
            ReadExercises(LoadFromFile());
        }

        private void ReadExercises(FinalizedExercise[] exercises)
        {
            dgv.DataSource = exercises;

            graph.Bind(exercises, "speeds", "Id", "Speed");
        }
        private void ShowStatisticForSelection()
        {            
            int count = dgv.SelectedRows.Count;
            if (count > 0)
            {
                double speedSum = 0;
                double speed;
                double errorspercentSum = 0;
                int rhythmicitySum = 0;
                int passedCharsSum = 0;
                int passedChars;
                TimeSpan timeSum = TimeSpan.Zero;
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    speed = (double)row.Cells["speedDataGridViewTextBoxColumn"].Value;
                    passedChars = (int)row.Cells["passedCharsDataGridViewTextBoxColumn"].Value;
                    speedSum += speed;
                    errorspercentSum += (double)row.Cells["errorsPercentDataGridViewTextBoxColumn"].Value;
                    rhythmicitySum += (int)row.Cells["rhythmicityDataGridViewTextBoxColumn"].Value;
                    passedCharsSum += passedChars;
                    timeSum += TimeSpan.FromMinutes(passedChars / speed);
                }
                textBoxCount.Text = count.ToString();
                textBoxAvSpeed.Text = (speedSum / count).ToString("F2") + " зн/мин";
                textBoxErrors.Text = (errorspercentSum / count).ToString("F2") + " %";
                textBoxRhithmicity.Text = (rhythmicitySum / count).ToString() + " %";
                textBoxTime.Text = ResultForm.FormatTimeSpan(timeSum);
            }
        }

        public static void Save(FinalizedExercise result)
        {
            var sb = new StringBuilder();

            sb.Append(DateTime.Now.ToShortDateString()); sb.Append(AttributeDelimeter);
            sb.Append(result.TextTitle);                 sb.Append(AttributeDelimeter);
            sb.Append(result.PassedChars);               sb.Append(AttributeDelimeter);
            sb.Append(result.Errors);                    sb.Append(AttributeDelimeter);
            sb.Append(result.Time);                      sb.Append(AttributeDelimeter);
            sb.Append(result.Rhythmicity);               sb.Append(AttributeDelimeter);
            sb.Remove(sb.Length - 1, 1);
            sb.Append(ExerciseDelimeter);

            using (var file = File.AppendText(FileName))
            {
                file.Write(sb);
            }
        }
        public static FinalizedExercise[] LoadFromFile()
        {            
            if (!File.Exists(FileName))
                return new FinalizedExercise[] { };

            string s;
            using (var file = File.OpenText(FileName))
            {
                s = file.ReadToEnd();
            }
            string[] exercises = s.Split(ExerciseDelimeter);

            FinalizedExercise[] result = new FinalizedExercise[exercises.Length - 1];

            for (int i = 0; i < exercises.Length - 1; i++)
            {
                result[i] = new FinalizedExercise(exercises[i], i);
            }

            return result;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            int[] ids = new int[dgv.SelectedRows.Count];
            for (int i = 0; i < dgv.SelectedRows.Count; i++)
            {
                ids[i] = (int)dgv.SelectedRows[i].Cells["idDataGridViewTextBoxColumn"].Value;
            }
            graph.HighlightSeriePoints("speeds", ids);
            ShowStatisticForSelection();
        }
        private void buttonAll_Click(object sender, EventArgs e)
        {
            dgv.SelectAll();
        }

        private void buttonLast10_Click(object sender, EventArgs e)
        {
            dgv.ClearSelection();
            for (int i = dgv.Rows.Count-1; i >= 0 && i >= dgv.Rows.Count - 10; i--)
            {
                dgv.Rows[i].Selected = true;
            }
        }
    }
}
