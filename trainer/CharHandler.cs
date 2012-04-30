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

        /// <summary>
        /// Положение курсора в richTextBoxSourceView перед введённой буквой
        /// </summary>
        public int RichTextPosition
        {
            get
            {
                if (markerPosition == 0 && linePosition != 0) // учитывает дополнительный невидимый символ (перевода строки) после ввода последнего символа в строке  
                    return statistic.PassedChars + linePosition - 2;
                else
                    return statistic.PassedChars + linePosition - 1;
            }
        }
        /// <summary>
        /// Корректируется ли ошибка
        /// </summary>
        public bool IsCorrecting
        {
            get { return wrongChars > 0; }
        }

        public CharHandler(SourceText _sourceText, Statistic _statistic)
        {
            sourceText = _sourceText;
            statistic = _statistic;
        }

        #region Перемещение позиции ввода
     
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

        #endregion

        private void AddWrongChar(char ch)
        {
            if (!IsCorrecting)
            {
                statistic.AddError(ch);
            }
            wrongChars++;
        }
        public void DeleteChar(char ch)
        {
            statistic.AddDeletion(ch);
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
