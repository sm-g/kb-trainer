using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace trainer
{
    public partial class Form1 : Form
    {
        static string textsPath  = Path.Combine(Application.StartupPath, "text");
        static Color errorColor  = Color.Chocolate;
        static Color passedColor = Color.Gray;
        static Color clearColor  = Color.White;
        SourceText sourceText;
        CharHandler charHandler;
        Statistic statistic;
        bool exerciseStarted;
        bool textOpenedFromFile;

        public Form1()
        {
            InitializeComponent();
            LoadSource(GetRandomTextFile(textsPath));
        }

        private void LoadSource(string filePath)
        {
            sourceText = new SourceText(filePath);
            statistic = new Statistic();
            charHandler = new CharHandler(sourceText, statistic);
            charHandler.TextEnds += StopTyping;

            Text = sourceText.Title + " - " + sourceText.FileName + " - Keyboard trainer";
        }
        private string GetRandomTextFile(string directoryPath)
        {
            string[] fileNames = Directory.GetFiles(directoryPath, "*.txt");
            Random r = new Random();
            return fileNames[r.Next(fileNames.Length)];
        }
        private void ChangeText()
        {
            string currentFile = sourceText.FileName;
            string newFile;
            do
            {
                newFile = GetRandomTextFile(textsPath);
            }
            while (Path.GetFileName(newFile) == currentFile && Directory.GetFiles(textsPath, "*.txt").Length > 1);
            LoadSource(newFile);
        }

        private void richTextBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar)) // перехват управляющих клавиш
                return;

            if (charHandler.ValidateChar(e.KeyChar))
            {
                DisplayPassedLetter();

                keyboard.HighlightKey(CharHandler.CharToKeyLabel(charHandler.NextChar));

                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    CleanInput();
                }
            }
            else
            {
                DisplayWrongLetter();
            }
        }
        private void richTextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                StopTyping(sender, e);
                return; // не записывается в статистику
            }
            statistic.RegisterKeyDown(e.KeyCode);
            if (e.KeyData == Keys.Back && richTextBoxInput.Text.Length != 0)
            {
                DeleteLetter(richTextBoxInput.Text[richTextBoxInput.Text.Length - 1]);

                keyboard.HighlightKey(CharHandler.CharToKeyLabel(charHandler.NextChar));
            }
            
            Console.Write(charHandler.NextChar);
        }
        private void richTextBoxInput_KeyUp(object sender, KeyEventArgs e)
        {
            statistic.RegisterKeyUp(e.KeyCode);
            labelVelocity.Text = "скорость: " + statistic.Speed.Average.ToString("F");
        }
        private void richTextBoxInput_SelectionChanged(object sender, EventArgs e)
        {
            richTextBoxInput.SelectionStart = richTextBoxInput.Text.Length; // ввод только с конца

        }
        private void CleanInput()
        {
            richTextBoxInput.Clear();
        }

        private void DeleteLetter(char ch)
        {
            PaintLetter(richTextBoxSourceView, clearColor);
            charHandler.DeleteChar(ch);
        }
        private void DisplayPassedLetter()
        {
            PaintLetter(richTextBoxSourceView, passedColor);
        }
        private void DisplayWrongLetter()
        {
            PaintLetter(richTextBoxSourceView, errorColor);
            System.Media.SystemSounds.Beep.Play();
            labelErrors.Text = "ошибки: " + statistic.Errors.ToString();
        }
        private void PaintLetter(RichTextBox richTextBox, Color color)
        {
            richTextBox.Select(charHandler.MarkerPosition - 1, 1);
            richTextBox.SelectionBackColor = color;
        }

        private void StopTyping(object sender, EventArgs e)
        {
            statistic.PauseTimer();

            richTextBoxInput.Enabled = false;
            timerResultDelay.Enabled = true;
        }
        private void ResumeTyping()
        {
            richTextBoxInput.Enabled = true;
            richTextBoxInput.Focus();
        }

        private void FinishExercise()
        {
            exerciseStarted = false;
            StartEndToolStripMenuItem.Text = "Старт";
            SetTextMenu();

            timerUpdateWidgets.Enabled = false;
        }
        private void StartExercise()
        {
            exerciseStarted = true;
            StartEndToolStripMenuItem.Text = "Финиш";
            SetTextMenu();
            PrepareTextBoxes();
            ResumeTyping();

            timerUpdateWidgets.Enabled = true;
            keyboard.HighlightKey(CharHandler.CharToKeyLabel(charHandler.NextChar));
        }
        private void PrepareTextBoxes()
        {
            CleanInput();
            richTextBoxSourceView.Clear();
            richTextBoxSourceView.Lines = sourceText.Lines;
        }

        private void timerResultDelay_Tick(object sender, EventArgs e)
        {
            timerResultDelay.Enabled = false;
            Result resultForm = new Result(statistic.GetResultInfo(), sourceText.GetInfo());
            if (resultForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FinishExercise();
            }
            else
            {
                ResumeTyping();
            }
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textOpenedFromFile = true;
                LoadSource(openFileDialog.FileName);
                SetTextMenu();
            }
        }
        private void StartEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (exerciseStarted)
            {
                StopTyping(sender, e);
            }
            else
            {
                if (charHandler.TextEnded && !textOpenedFromFile)
                    ChangeText();
                StartExercise();
            }
        }
        private void RandomTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textOpenedFromFile)
            {
                textOpenedFromFile = false;
                LoadSource(GetRandomTextFile(textsPath));
                SetTextMenu();
            }
        }
        private void SetTextMenu()
        {
            OpenFileToolStripMenuItem.Checked    = textOpenedFromFile;
            RandomTextToolStripMenuItem.Checked  = !textOpenedFromFile;

            OpenFileToolStripMenuItem.Enabled    = !exerciseStarted;
            RandomTextToolStripMenuItem.Enabled  = !exerciseStarted;
            AnotherTextToolStripMenuItem.Enabled = !exerciseStarted;
        }
        private void AnotherTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeText();
        }

        private void timerUpdateWidgets_Tick(object sender, EventArgs e)
        {
            labelTime.Text = Result.FormatTimeSpan(statistic.Now);
            progressBar.Value = charHandler.TextProgress;
        }



    }
}
