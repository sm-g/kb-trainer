using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace trainer
{
    public partial class Form1 : Form
    {
        const string defaultTextPath = "..\\..\\..\\text\\dict a.txt";
        static Color errorColor = Color.Chocolate;
        static Color passedColor = Color.Gray;
        static Color clearColor = Color.White;
        SourceText sourceText;
        CharHandler charHandler;

        public Form1()
        {
            InitializeComponent();
            LoadSource(defaultTextPath);
        }

        private void LoadSource(string path)
        {
            sourceText = new SourceText(path);
            charHandler = new CharHandler(sourceText);
            charHandler.TextEnds += FinishTyping;

            richTextBoxSourceView.Lines = sourceText.Lines;
        }

        private void richTextBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;

            if (!charHandler.Validate(e.KeyChar))
            {
                DisplayError();
            }
            else
            {
                DisplayPassed();
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    ChangeWord();
                }
            }
        }

        private void richTextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back && richTextBoxInput.Text.Length != 0)
            {
                DeleteLetter();
            }
        }

        private void richTextBoxInput_SelectionChanged(object sender, EventArgs e)
        {
            richTextBoxInput.SelectionStart = richTextBoxInput.Text.Length;
        }

        private void ChangeWord()
        {
            richTextBoxInput.Clear();
        }

        private void DeleteLetter()
        {
            PaintLetters(richTextBoxSourceView, clearColor);
            charHandler.DeleteChar();
        }

        private void DisplayPassed()
        {
            PaintLetters(richTextBoxSourceView, passedColor);
        }

        private void DisplayError()
        {
            PaintLetters(richTextBoxSourceView, errorColor);
            labelErrors.Text = "ошибки: " + charHandler.Errors.ToString();
        }

        private void PaintLetters(RichTextBox richTextBox, Color color)
        {
            richTextBox.Select(charHandler.RichTextPosition, 1);
            richTextBox.SelectionBackColor = color;
        }

        private void FinishTyping(object sender, EventArgs e)
        {
            richTextBoxInput.Enabled = false;
        }

        private void richTextBoxInput_KeyUp(object sender, KeyEventArgs e)
        {
            //
        }
    }
}
