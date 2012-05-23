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

        SourceText sourceText;
        CharHandler charHandler;
        Statistic statistic;
        bool exerciseStarted;
        bool textOpenedFromFile;
        bool windowIsActive;

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
                keyboard.HighlightKeys(charHandler.NextCharToType);

                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    CleanInput();
                }
            }
            else
            {
                DisplayWrongLetter();
                keyboard.HighlightKeys(charHandler.NextCharToType);
            }
        }
        private void richTextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                StopTyping();
                return; // не записывается в статистику
            }
            statistic.RegisterKeyDown(e.KeyCode);
            if (e.KeyData == Keys.Back && richTextBoxInput.Text.Length != 0)
            {
                DeleteLetter(richTextBoxInput.Text[richTextBoxInput.Text.Length - 1]);

                keyboard.HighlightKeys(charHandler.NextCharToType);
            }
        }
        private void richTextBoxInput_KeyUp(object sender, KeyEventArgs e)
        {
            statistic.RegisterKeyUp(e.KeyCode);
            labelVelocity.Text = "скорость: " + statistic.Speed.Average.ToString("F");
            if (charHandler.TextEnded)
            {
                StopTyping();
            }
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
            PaintLetter(richTextBoxSourceView, Colors.clearLetterBackground, Colors.clearLetter);
            charHandler.DeleteChar(ch);
        }
        private void DisplayPassedLetter()
        {
            PaintLetter(richTextBoxSourceView, Colors.passedLetterBackground, Colors.passedLetter);
        }
        private void DisplayWrongLetter()
        {
            PaintLetter(richTextBoxSourceView, Colors.wrongLetterBackground, Colors.wrongLetter);
            System.Media.SystemSounds.Beep.Play();
            labelErrors.Text = "ошибки: " + statistic.Errors.ToString();
        }
        private void PaintLetter(RichTextBox richTextBox, Color backColor, Color color)
        {
            richTextBox.Select(charHandler.MarkerPosition - 1, 1);
            richTextBox.SelectionBackColor = backColor;
            richTextBox.SelectionColor = color;
        }

        private void StopTyping()
        {
            statistic.PauseTimer();

            richTextBoxInput.Enabled = false;

            if (windowIsActive)
                EndTyping();
        }
        private void ResumeTyping()
        {
            richTextBoxInput.Enabled = true;
            richTextBoxInput.Focus();
        }
        private void EndTyping()
        {
            if (statistic.EnoughToResult)
            {
                if (charHandler.TextEnded)
                    timerResultDelay.Enabled = true;
                else
                    ShowResult();
            }
            else
            {
                FinishExercise();
            }
        }

        private void FinishExercise()
        {
            exerciseStarted = false;                        
            
            keyboard.TurnOffHighlighting();
            
            SetMenus();
            timerUpdateWidgets.Enabled = false;
        }
        private void StartExercise()
        {
            if (charHandler.TextEnded && !textOpenedFromFile)
                ChangeText();

            exerciseStarted = true;
            
            PrepareTextBoxes();
            ResumeTyping();
            
            keyboard.HighlightKeys(charHandler.NextCharToType);
            SetMenus();
            timerUpdateWidgets.Enabled = true;
        }
        private void PrepareTextBoxes()
        {
            CleanInput();
            richTextBoxSourceView.Clear();
            richTextBoxSourceView.Lines = sourceText.Lines;
        }

        private void ShowResult()
        {
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
        private void timerResultDelay_Tick(object sender, EventArgs e)
        {
            timerResultDelay.Enabled = false;
            ShowResult();
        }

        private void StartEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (exerciseStarted)
            {
                StopTyping();
            }
            else
            {                
                StartExercise();
            }
        }
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textOpenedFromFile = true;
                LoadSource(openFileDialog.FileName);
                SetMenus();
            }
        }
        private void RandomTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textOpenedFromFile)
            {
                textOpenedFromFile = false;
                LoadSource(GetRandomTextFile(textsPath));
                SetMenus();
            }
        }
        private void AnotherTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeText();
        }
        private void SetMenus()
        {
            OpenFileToolStripMenuItem.Checked    = textOpenedFromFile;
            RandomTextToolStripMenuItem.Checked  = !textOpenedFromFile;

            OpenFileToolStripMenuItem.Enabled    = !exerciseStarted;
            RandomTextToolStripMenuItem.Enabled  = !exerciseStarted;
            AnotherTextToolStripMenuItem.Enabled = !exerciseStarted;

            StartEndToolStripMenuItem.Text = exerciseStarted ? "Стоп" : "Старт";
        }


        private void timerUpdateWidgets_Tick(object sender, EventArgs e)
        {
            labelTime.Text = Result.FormatTimeSpan(statistic.Now);
            progressBar.Value = (int)(charHandler.TextProgress * progressBar.Maximum);
        }

        private void checkBoxKeyboardLabeled_CheckedChanged(object sender, EventArgs e)
        {
            keyboard.Labeled = checkBoxKeyboardLabeled.Checked;
        }
        private void checkBoxKeyboardColored_CheckedChanged(object sender, EventArgs e)
        {
            keyboard.FingerZonesColored = checkBoxKeyboardColored.Checked;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            windowIsActive = false;
            if (exerciseStarted)
                StopTyping();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            windowIsActive = true;
            if (exerciseStarted)
                ResumeTyping();
        }
    }
}
