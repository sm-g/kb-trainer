using System.IO;

namespace trainer
{
    public class SourceText
    {
        public static string textsPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "text");

        private string[] textData;

        public int Length
        {
            get
            {
                int result = 0;
                foreach (string s in textData)
                {
                    result += s.Length;
                }
                return result;
            }
        }
        public string Title { get { return textData[0].Replace(Progress.AttributeDelimeter, Progress.SafeChar).Trim(); } }
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public bool OpenedByUser { get; private set; }
        public string[] Lines { get { return textData; } }

        public SourceText(string filePath, bool byUser)
        {            
            textData = File.ReadAllLines(filePath, System.Text.Encoding.Default);
            FileName = Path.GetFileName(filePath);
            FilePath = filePath;
            OpenedByUser = byUser;

            Format();
        }

        private void Format()
        {
            for (int i = 0; i < textData.Length - 1; i++)
            {
                textData[i] = textData[i].Trim();
                textData[i] += ' '; // для разрыва со словом из следующей строки
                textData[i] = System.Text.RegularExpressions.Regex.Replace(textData[i], " +", " ");
            }
        }
    }
}
