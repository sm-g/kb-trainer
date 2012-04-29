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
        private int errorsCounter;
        private int deletedCharsCounter;
        private int typedChars;
        private int wrongChars;

        public int Errors
        {
            get { return errorsCounter; }
        }
        public int RichTextPosition
        {
            get
            {
                if (markerPosition == 0 && linePosition != 0)
                    return typedChars - deletedCharsCounter + linePosition - 2;
                else
                    return typedChars - deletedCharsCounter + linePosition - 1;
            }
        }
        public bool IsCorrecting
        {
            get { return wrongChars > 0; }
        }

        public CharHandler(SourceText _sourceText)
        {
            sourceText = _sourceText;
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
        private void AddError()
        {
            if (!IsCorrecting)
            {
                errorsCounter++;
            }
            wrongChars++;
        }
        public void DeleteChar()
        {
            deletedCharsCounter++;
            if (!IsCorrecting)
            {
                MoveMarkerBack();
            }
            else
            {
                wrongChars--;
            }
        }
        public bool Validate(char ch)
        {
            typedChars++;
            if (!IsCorrecting && sourceText.Lines[linePosition][markerPosition] == ch)
            {
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
