using System;
using System.Drawing;
using System.Windows.Forms;

namespace trainer
{
    public partial class Form1 : Form
    {
        SourceText source;
        Exercise exercise;

        public Form1()
        {
            InitializeComponent();
            LoadSource(GetRandomTextFile(), false);
            CreateExersice();
            DrawColorSquare();
        }

        private void LoadSource(string filePath, bool byUser)
        {
            if (filePath != "")
            {
                source = new SourceText(filePath, byUser);

                Text = source.Title + " - " + source.FileName + " - Keyboard trainer";
            }

            StartToolStripMenuItem.Enabled = source != null;
        }
        private string OnNoFiles()
        {
            DialogResult result = MessageBox.Show("В папке \"" + SourceText.textsPath.ToString() + "\" нет текстовых файлов.\nВыбрать файл в другом месте?",
                                                  "Файл не найден - Keyboard trainer", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                OpenTextFile();

            return "";
        }
        private string GetRandomTextFile()
        {
            if (!System.IO.Directory.Exists(SourceText.textsPath))
            {
                System.IO.Directory.CreateDirectory(SourceText.textsPath);
                return OnNoFiles();
            }

            string[] fileNames = System.IO.Directory.GetFiles(SourceText.textsPath, "*.txt");

            if (fileNames.Length == 0)
            {
                return OnNoFiles();
            }
            else
            {
                string newFile;
                string currentFile = "";
                if (source != null)
                    currentFile = source.FilePath;
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
                CreateExersice();
                SetMenusState();
            }
        }

        private void richTextBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar)) // перехват управляющих клавиш
                return;
            if (exercise.ValidateChar(e.KeyChar))
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

            exercise.RegisterKeyDown(code);
            if (code == Keys.Back && richTextBoxInput.Text.Length != 0)
            {
                char deletingChar = richTextBoxInput.Text[richTextBoxInput.Text.Length - 1];
                exercise.DeleteChar(deletingChar);

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
            if (exercise.TextEnded)
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
            keyboard.HighlightKeyButtons(exercise.NextCharToType);
        }
        private void DisplayCorrectInput()
        {
            PaintSourceViewChar(1, Colors.passedLetterBackground, Colors.passedLetter);
            keyboard.HighlightKeyButtons(exercise.NextCharToType);
        }
        private void DisplayWrongInput()
        {
            PaintSourceViewChar(1, Colors.wrongLetterBackground, Colors.wrongLetter);
            keyboard.HighlightKeyButtons(exercise.NextCharToType);

            System.Media.SystemSounds.Beep.Play();
        }
        private void PaintSourceViewChar(int offset, Color backColor, Color color)
        {
            richTextBoxSourceView.Select(exercise.MarkerPosition - offset, 1);
            richTextBoxSourceView.SelectionBackColor = backColor;
            richTextBoxSourceView.SelectionColor = color;
        }

        private void StopTyping()
        {
            if (exercise.State == ExerciseState.Active)
            {
                exercise.State = ExerciseState.Paused;
                exercise.PauseTimer();
                SetStartButtonLabel();

                timerUpdateWidgets.Enabled = false;
                richTextBoxInput.Enabled = false;
            }
        }
        private void ResumeTyping()
        {
            exercise.State = ExerciseState.Active;

            SetStartButtonLabel();

            timerUpdateWidgets.Enabled = true;
            richTextBoxInput.Enabled = true;
            richTextBoxInput.Focus();
        }
        private void EndTyping()
        {
            StopTyping();
            if (exercise.EnoughToResult)
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
            exercise.State = ExerciseState.NotStarted;

            keyboard.TurnOffHighlighting();

            SetMenusState();
            SetStartButtonLabel();
            SetWidgetsVisability();

            if (exercise.EnoughToResult)
            {
                Progress.Save(exercise.GetResult());
            }
        }
        private void StartExercise()
        {
            if (exercise.TextEnded && !source.OpenedByUser)
            {
                LoadSource(GetRandomTextFile(), false);                
            }
            CreateExersice();
            
            PrepareTextBoxes();
            ResumeTyping();

            keyboard.HighlightKeyButtons(exercise.NextCharToType);
            SetMenusState();
            SetStartButtonLabel();
            SetWidgetsVisability();
        }
        private void CreateExersice()
        {
            exercise = new Exercise(source);
        }
        private void PrepareTextBoxes()
        {
            CleanInput();
            richTextBoxSourceView.Clear();
            richTextBoxSourceView.Lines = source.Lines;
        }

        private void ShowResult()
        {
            ResultForm resultForm = new ResultForm(exercise.GetResult(), source);
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
            switch (exercise.State)
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
            if (source != null && source.OpenedByUser)
            {
                LoadSource(GetRandomTextFile(), false);
                CreateExersice();
                SetMenusState();
            }
        }
        private void AnotherTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSource(GetRandomTextFile(), false);
            CreateExersice();
        }
        private void SetMenusState()
        {
            OpenFileToolStripMenuItem.Checked = source.OpenedByUser;
            RandomTextToolStripMenuItem.Checked = !source.OpenedByUser;

            OpenFileToolStripMenuItem.Enabled =
                RandomTextToolStripMenuItem.Enabled =
                AnotherTextToolStripMenuItem.Enabled = exercise.State == ExerciseState.NotStarted;
        }
        private void SetStartButtonLabel()
        {
            switch (exercise.State)
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
            panelTypingMeasures.Visible = exercise.State != ExerciseState.NotStarted;
            panelProgress.Visible = exercise.State != ExerciseState.NotStarted;
        }
        private void timerUpdateWidgets_Tick(object sender, EventArgs e)
        {
            labelTime.Text = ResultForm.FormatTimeSpan(exercise.PastTime);
            labelRemainTime.Text = '-' + ResultForm.FormatTimeSpan(exercise.ExpectedRemainTime);
            progressBar.Value = (int)(exercise.TextProgress * progressBar.Maximum);
            labelVelocity.Text = exercise.Speed.ToString("F");
            labelErrors.Text = exercise.Errors.ToString();
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
