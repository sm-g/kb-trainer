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

        public CharHandler(SourceText sourceText, Statistic _statistic)
        {
            source = sourceText;
            statistic = _statistic;
        }

        #region Перемещение позиции ввода
     
        private void MoveMarkerForward()
        {
            markerPosition++;
            if (markerPosition == source.Lines[linePosition].Length)
            {
                MoveLineDown();
            }
        }
        private void MoveMarkerBack()
        {
            markerPosition--;
            if (markerPosition == -1)
            {
                MoveLineUp();
            }
        }
        private void MoveLineDown()
        {
            if (linePosition == source.Lines.Length - 1)
            {
                OnRaiseTextEnds(new EventArgs());
            }
            else
            {
                linePosition++;
                markerPosition = 0;
            }
        }
        private void MoveLineUp()
        {
            if (linePosition > 0)
            {
                linePosition--;
                markerPosition = source.Lines[linePosition].Length - 1;
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
            if (!IsCorrecting && source.Lines[linePosition][markerPosition] == ch)
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
