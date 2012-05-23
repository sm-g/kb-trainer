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
                DisplayCorrectInput();

                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    CleanInput();
                }
            }
            else
            {
                DisplayWrongInput();
            }            
        }
        private void richTextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            Keys code = e.KeyData != (Keys.Back ^ Keys.Control) ? e.KeyData : Keys.Back;
            if (code == Keys.Escape)
            {
                StopTyping();
                return;
            }
            
            statistic.RegisterKeyDown(code);
            if (code == Keys.Back && richTextBoxInput.Text.Length != 0)
            {
                char deletingChar = richTextBoxInput.Text[richTextBoxInput.Text.Length - 1];
                charHandler.DeleteChar(deletingChar);

                if (e.KeyData == (Keys.Back ^ Keys.Control))
                {
                    e.Handled = true;
                    richTextBoxInput.Text = richTextBoxInput.Text.Remove(richTextBoxInput.Text.Length - 1);
                }

                DisplayDeletion();                
            }
        }
        private void richTextBoxInput_KeyUp(object sender, KeyEventArgs e)
        {
            Keys code = e.KeyData != (Keys.Back ^ Keys.Control) ? e.KeyData : Keys.Back;

            statistic.RegisterKeyUp(code);
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

        private void DisplayDeletion()
        {
            PaintSourceViewChar(0, Colors.clearLetterBackground, Colors.clearLetter);
            keyboard.HighlightKeyButtons(charHandler.NextCharToType);
        }
        private void DisplayCorrectInput()
        {
            PaintSourceViewChar(1, Colors.passedLetterBackground, Colors.passedLetter);
            keyboard.HighlightKeyButtons(charHandler.NextCharToType);
        }
        private void DisplayWrongInput()
        {
            PaintSourceViewChar(1, Colors.wrongLetterBackground, Colors.wrongLetter);
            keyboard.HighlightKeyButtons(charHandler.NextCharToType);

            System.Media.SystemSounds.Beep.Play();
            labelErrors.Text = "ошибки: " + statistic.Errors.ToString();
        }
        private void PaintSourceViewChar(int offset, Color backColor, Color color)
        {
            richTextBoxSourceView.Select(charHandler.MarkerPosition - offset, 1);
            richTextBoxSourceView.SelectionBackColor = backColor;
            richTextBoxSourceView.SelectionColor = color;            
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
            
            keyboard.HighlightKeyButtons(charHandler.NextCharToType);
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
