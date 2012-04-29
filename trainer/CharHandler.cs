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

        private SourceText sourceText;
        private Statistic statistic;
        private int markerPosition;
        private int linePosition;
        private int wrongChars;

        public int Errors
        {
            get { return statistic.Errors; }
        }

        public int RichTextPosition
        {
            get
            {
                if (markerPosition == 0 && linePosition != 0)
                    return statistic.PassedChars + linePosition - 2;
                else
                    return statistic.PassedChars + linePosition - 1;
            }
        }
        public bool IsCorrecting
        {
            get { return wrongChars > 0; }
        }

        public CharHandler(SourceText _sourceText, ref Statistic _statistic)
        {
            sourceText = _sourceText;
            statistic = new Statistic();
        }

        private void MoveMarkerForward()
        {
            markerPosition++;
            if (markerPosition == sourceText.Lines[linePosition].Length)
            {
                MoveLineForward();
            }
        }
        private void MoveMarkerBack()
        {
            markerPosition--;
            if (markerPosition == -1)
            {
                MoveLineBack();
            }
        }
        private void MoveLineForward()
        {
            if (linePosition == sourceText.Lines.Length - 1)
            {
                OnRaiseTextEnds(new EventArgs());
            }
            else
            {
                linePosition++;
                markerPosition = 0;
            }
        }
        private void MoveLineBack()
        {
            if (linePosition > 0)
            {
                linePosition--;
                markerPosition = sourceText.Lines[linePosition].Length - 1;
            }
            else
            {
                markerPosition = 0;
            }
        }
        private void AddWrongChar(char ch)
        {
            if (!IsCorrecting)
            {
                statistic.AddError(ch);
            }
            wrongChars++;
        }
        public void DeleteChar()
        {
            statistic.AddDeletion();
            if (!IsCorrecting)
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
            if (!IsCorrecting && sourceText.Lines[linePosition][markerPosition] == ch)
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
        }
    }
}
