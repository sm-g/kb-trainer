using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace trainer
{
    class CharHandler
    {
        public event EventHandler TextEnds;

        private SourceText source;
        private Statistic statistic;
        private int inLinePosition;
        private int lineNumber;
        private int wrongChars;

        public int MarkerPosition
        {
            get
            {
                if (inLinePosition == 0 && lineNumber != 0) // учитывает невидимый символ перевода строки после ввода последней в строке буквы
                    return statistic.PassedChars + lineNumber - 1;
                else
                    return statistic.PassedChars + lineNumber;
            }
        }
        public int TextProgress { get { return (int)(100 * statistic.PassedChars / source.Length); } }
        public char NextCharToType
        {
            get
            {
                if (IsCorrectingWrongChars)
                    return '\b';
                if (inLinePosition < source.Lines[lineNumber].Length)
                    return source.Lines[lineNumber][inLinePosition];
                return '\0';
            }
        }
        public bool IsCorrectingWrongChars
        {
            get { return wrongChars > 0; }
        }
        public bool TextEnded { get; private set; }

        public CharHandler(SourceText sourceText, Statistic _statistic)
        {
            source = sourceText;
            statistic = _statistic;
        }

        private void MoveMarkerForward()
        {
            inLinePosition++;
            if (inLinePosition == source.Lines[lineNumber].Length)
            {
                MoveMarkerToNextLine();
            }
        }
        private void MoveMarkerBack()
        {
            inLinePosition--;
            if (inLinePosition == -1)
            {
                MoveMarkerToPrevLine();
            }
        }
        private void MoveMarkerToNextLine()
        {
            if (lineNumber == source.Lines.Length - 1)
            {
                OnRaiseTextEnds(new EventArgs());
            }
            else
            {
                lineNumber++;
                inLinePosition = 0;
            }
        }
        private void MoveMarkerToPrevLine()
        {
            if (lineNumber > 0)
            {
                lineNumber--;
                inLinePosition = source.Lines[lineNumber].Length - 1;
            }
            else
            {
                inLinePosition = 0;
            }
        }

        private void AddWrongChar(char ch)
        {
            if (!IsCorrectingWrongChars)
            {
                statistic.AddError(ch);
            }
            wrongChars++;
        }
        public void DeleteChar(char ch)
        {
            statistic.AddDeletion(ch);
            if (!IsCorrectingWrongChars)
            {
                MoveMarkerBack();
            }
            else
            {
                wrongChars--;
            }
        }
        public bool ValidateChar(char ch)
        {
            statistic.AddChar(ch);
            if (!IsCorrectingWrongChars && source.Lines[lineNumber][inLinePosition] == ch)
            {
                MoveMarkerForward();
                return true;
            }
            else
            {
                AddWrongChar(ch);
                return false;
            }
        }

        protected virtual void OnRaiseTextEnds(EventArgs e)
        {
            TextEnds(this, e);
            TextEnded = true;
        }
    }
}
