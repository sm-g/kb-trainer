using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trainer
{
    class CharHandler
    {
        public event EventHandler TextEnds;

        private SourceText sourceText;
        private int markerPosition;
        private int linePosition;
        private int errorCounter;
        private bool correcting;

        public CharHandler(SourceText _sourceText)
        {
            sourceText = _sourceText;
        }

        public int Errors
        {
            get { return errorCounter; }
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
            linePosition++;
            markerPosition = 0;
            if (linePosition == sourceText.Lines.Length)
            {
                OnRaiseTextEnds(new EventArgs());
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
        private void AddError()
        {
            if (!correcting)
            {
                errorCounter++;
                correcting = true;
            }
        }
        private void DeleteChar()
        {
            if (!correcting)
            {
                MoveMarkerBack();
            }
        }
        public bool Validate(char ch)
        {
            if (ch == '\b')
            {
                DeleteChar();
                return true;
            }

            if (sourceText.Lines[linePosition][markerPosition] == ch)
            {
                correcting = false;
                MoveMarkerForward();
                return true;
            }
            else
            {
                AddError();
                return false;
            }
        }

        protected virtual void OnRaiseTextEnds(EventArgs e)
        {
            TextEnds(this, e);
        }
    }
}
