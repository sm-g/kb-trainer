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

        public Form1()
        {
            InitializeComponent();
            ChooseRandomText(textsPath);
        }

        private void LoadSource(string path)
        {
            sourceText = new SourceText(path);
            statistic = new Statistic();
            charHandler = new CharHandler(sourceText, statistic);
            charHandler.TextEnds += FinishTyping;

            Text = sourceText.Title + " - " + sourceText.FileName + " - Keyboard trainer";
        }
        private void ChooseRandomText(string directoryPath)
        {
            string[] fileNames = Directory.GetFiles(directoryPath, "*.txt");
            Random r = new Random();
            string chosenFileName = fileNames[r.Next(fileNames.Length)];
            LoadSource(chosenFileName);
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
                    ChangeWord();
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
                FinishTyping(sender, e);
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
        private void ChangeWord()
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
            labelErrors.Text = "ошибки: " + statistic.Errors.ToString();
        }
        private void PaintLetter(RichTextBox richTextBox, Color color)
        {
            richTextBox.Select(charHandler.MarkerPosition - 1, 1);
            richTextBox.SelectionBackColor = color;
        }

        private void FinishTyping(object sender, EventArgs e)
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

        private void EndExercise()
        {
            //
        }
        private void StartExercise()
        {
            richTextBoxInput.Enabled = true;
            richTextBoxInput.Focus();
            richTextBoxSourceView.Lines = sourceText.Lines;

            keyboard.HighlightKey(CharHandler.CharToKeyLabel(charHandler.NextChar));
        }

        private void timerResultDelay_Tick(object sender, EventArgs e)
        {
            timerResultDelay.Enabled = false;
            Result resultForm = new Result(statistic.GetResultInfo(), sourceText.GetInfo());
            if (resultForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EndExercise();
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
                LoadSource(openFileDialog.FileName);
                OpenFileToolStripMenuItem.Checked = true;
                RandomTextToolStripMenuItem.Checked = false;
            }
        }
        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartExercise();
        }
        private void RandomTextToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            OpenFileToolStripMenuItem.Checked = false;
            RandomTextToolStripMenuItem.Checked = true;
        }

        private void RandomTextToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (RandomTextToolStripMenuItem.Checked)
                ChooseRandomText(textsPath);
        }
    }
}
