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
            if (!charHandler.Validate(e.KeyChar))
            {
                DisplayError();
            }
        }

        private void DisplayError()
        {
            PaintLetters(richTextBoxSourceView, errorColor, richTextBoxInput.Text.Length, 1);
            labelErrors.Text = "ошибки: " + charHandler.Errors.ToString();
        }

        private void PaintLetters(RichTextBox richTextBox, Color color, int start, int lenght)
        {
            richTextBox.Select(start, lenght);
            richTextBox.SelectionBackColor = color;
        }

        private void FinishTyping(object sender, EventArgs e)
        {
            richTextBoxInput.Enabled = false;
        }


    }
}
