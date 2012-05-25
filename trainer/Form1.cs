using System;
using System.Drawing;
using System.Windows.Forms;

namespace trainer
{
    public partial class Form1 : Form
    {
        enum ExerciseState
        {
            NotStarted,
            Active,
            Paused
        }

        SourceText sourceText;
        CharHandler charHandler;
        Statistic statistic;
        
        ExerciseState exerciseState;

        public Form1()
        {
            InitializeComponent();
            LoadSource(GetRandomTextFile(), false);
            DrawColorSquare();
        }

        private void LoadSource(string filePath, bool byUser)
        {
            if (filePath != "")
            {
                sourceText = new SourceText(filePath, byUser);
                statistic = new Statistic();
                charHandler = new CharHandler(sourceText, statistic);

                Text = sourceText.Title + " - " + sourceText.FileName + " - Keyboard trainer";
            }

            StartToolStripMenuItem.Enabled = sourceText != null;            
        }
        private string OnNoFiles()
        {
            DialogResult result = MessageBox.Show("В папке " + SourceText.textsPath.ToString() + " нет текстовых файлов.\nВыбрать файл в другом месте?", 
                                                  "Файл не найден", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                OpenTextFile();

            return "";
        }
        private string GetRandomTextFile()
        {
            string[] fileNames = System.IO.Directory.GetFiles(SourceText.textsPath, "*.txt");

            if (fileNames.Length == 0)
            {
                return OnNoFiles();
            }
            else
            {
                string newFile;
                string currentFile = "";
                if (sourceText != null)
                    currentFile = sourceText.FilePath;
                Random r = new Random();                
                do
                {
                    newFile = fileNames[r.Next(fileNames.Length)];
                }
                while (newFile == currentFile && fileNames.Length > 1);
                return newFile;
            }
        }
        private void OpenTextFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadSource(openFileDialog.FileName, true);
                SetMenusState();
            }
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
                EndTyping();
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

            if (charHandler.TextEnded)
            {
                EndTyping();
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
        }
        private void PaintSourceViewChar(int offset, Color backColor, Color color)
        {
            richTextBoxSourceView.Select(charHandler.MarkerPosition - offset, 1);
            richTextBoxSourceView.SelectionBackColor = backColor;
            richTextBoxSourceView.SelectionColor = color;
        }

        private void StopTyping()
        {
            if (exerciseState == ExerciseState.Active)
            {
                exerciseState = ExerciseState.Paused;
                statistic.PauseTimer();

                richTextBoxInput.Enabled = false;
                SetStartButtonLabel();
            }
        }
        private void ResumeTyping()
        {
            exerciseState = ExerciseState.Active;

            SetStartButtonLabel();
            richTextBoxInput.Enabled = true;
            richTextBoxInput.Focus();
        }
        private void EndTyping()
        {
            StopTyping();
            if (statistic.EnoughToResult)
            {
                ShowResult();
            }
            else
            {
                FinishExercise();
            }
        }

        private void FinishExercise()
        {
            exerciseState = ExerciseState.NotStarted;

            keyboard.TurnOffHighlighting();

            SetMenusState();
            SetStartButtonLabel();
            SetWidgetsVisability();
            timerUpdateWidgets.Enabled = false;

            if (statistic.EnoughToResult)
            {
                Progress.SaveToXml(sourceText, statistic);
                Progress.SaveToDsv(sourceText, statistic);
            }
        }
        private void StartExercise()
        {
            if (charHandler.TextEnded && !sourceText.OpenedByUser)
                LoadSource(GetRandomTextFile(), false);

            PrepareTextBoxes();
            ResumeTyping();

            keyboard.HighlightKeyButtons(charHandler.NextCharToType);
            SetMenusState();
            SetStartButtonLabel();
            SetWidgetsVisability();
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
            ResultForm resultForm = new ResultForm(statistic.GetResult(), sourceText);
            if (resultForm.ShowDialog() == DialogResult.OK)
            {
                FinishExercise();
            }
            else
            {
                ResumeTyping();
            }
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (exerciseState)
            {
                case ExerciseState.Paused:
                    ResumeTyping();
                    return;
                case ExerciseState.Active:
                    EndTyping();
                    return;
                case ExerciseState.NotStarted:
                    StartExercise();
                    return;
            }
        }
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTextFile();
        }
        private void RandomTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sourceText != null && sourceText.OpenedByUser)
            {
                LoadSource(GetRandomTextFile(), false);
                SetMenusState();
            }
        }
        private void AnotherTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSource(GetRandomTextFile(), false);
        }
        private void SetMenusState()
        {
            OpenFileToolStripMenuItem.Checked = sourceText.OpenedByUser;
            RandomTextToolStripMenuItem.Checked = !sourceText.OpenedByUser;

            OpenFileToolStripMenuItem.Enabled = exerciseState == ExerciseState.NotStarted;
            RandomTextToolStripMenuItem.Enabled = exerciseState == ExerciseState.NotStarted;
            AnotherTextToolStripMenuItem.Enabled = exerciseState == ExerciseState.NotStarted;
        }
        private void SetStartButtonLabel()
        {
            switch (exerciseState)
            {
                case ExerciseState.Paused:
                    StartToolStripMenuItem.Text = "Продолжить";
                    return;
                case ExerciseState.Active:
                    StartToolStripMenuItem.Text = "Стоп";
                    return;
                case ExerciseState.NotStarted:
                    StartToolStripMenuItem.Text = "Старт";
                    return;
            }
        }

        private void SetWidgetsVisability()
        {
            panelTypingMeasures.Visible = exerciseState != ExerciseState.NotStarted;
            panelProgress.Visible = exerciseState != ExerciseState.NotStarted;
        }
        private void timerUpdateWidgets_Tick(object sender, EventArgs e)
        {
            labelTime.Text = ResultForm.FormatTimeSpan(statistic.Now);
            labelRemainTime.Text = '-' + ResultForm.FormatTimeSpan(statistic.GetExpectedRemainTime(sourceText.Length));
            progressBar.Value = (int)(charHandler.TextProgress * progressBar.Maximum);
            labelVelocity.Text = statistic.Speed.Average.ToString("F");
            labelErrors.Text = statistic.Errors.ToString();
        }

        private void checkBoxKeyboardLabeled_CheckedChanged(object sender, EventArgs e)
        {
            keyboard.Labeled = checkBoxKeyboardLabeled.Checked;
        }
        private void checkBoxKeyboardColored_CheckedChanged(object sender, EventArgs e)
        {
            keyboard.FingerZonesColored = checkBoxKeyboardColored.Checked;
            DrawColorSquare();
        }
        private void DrawColorSquare()
        {
            int size = checkBoxKeyboardColored.Checked ? checkBoxKeyboardColored.Width / 2 : checkBoxKeyboardColored.Width - 1;
            checkBoxKeyboardColored.Image = keyboard.GetFingerColorsSquare(size);
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            StopTyping();
        }
        private void richTextBoxInput_Leave(object sender, EventArgs e)
        {
            StopTyping();
        }

        private void ProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Progress progressForm = new Progress();
            progressForm.Show();
        }
    }
}
