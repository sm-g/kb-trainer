using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace trainer
{
    public partial class Progress : Form
    {
        private const string fileName = "statistic.txt";
        private const char exerciseDelimeter = '\n';
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
            sb.Append(exerciseDelimeter);

            using (var file = File.AppendText(fileName))
            {
                file.Write(sb);
            }
        }
        public static FinalizedExercise[] LoadFromFile()
        {            
            if (!File.Exists(fileName))
                return new FinalizedExercise[] { };

            string s;
            using (var file = File.OpenText(fileName))
            {
                s = file.ReadToEnd();
            }
            string[] exercises = s.Split(exerciseDelimeter);

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
        }
    }
}
