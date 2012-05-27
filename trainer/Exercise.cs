using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trainer
{
    public enum ExerciseState
    {
        NotStarted,
        Active,
        Paused
    }

    public class Exercise
    {
        private SourceText source;
        private int inLinePosition;
        private int lineNumber;
        private int wrongChars;

        public ExerciseState State { get; set; }
        public Statistic statistic { get; set; }

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
        public char NextCharToType
        {
            get
            {
                if (TextEnded)
                    return '\0';
                if (IsCorrectingWrongChars)
                    return '\b';
                return source.Lines[lineNumber][inLinePosition];
            }
        }
        public float TextProgress { get { return (float)(statistic.PassedChars - wrongChars) / (source.Length); } }
        public bool TextEnded { get { return TextProgress == 1; } }
        public bool IsCorrectingWrongChars { get { return wrongChars > 0; } }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public string TextTitle { get; private set; }
        public double Speed { get { return Math.Round(Statistic.TypingSpeed.GetAverage(Time, PassedChars), 2); } }
        public int PassedChars { get; private set; }
        public int Errors { get; private set; }
        public double ErrorsPercent { get { return (double)100 * Errors / PassedChars; } }
        public TimeSpan Time { get; private set; }
        public string FormattedTime { get { return ResultForm.FormatTimeSpan(Time); } }
        public double Rhythmicity { get; private set; }
        public List<Keystroke> Keystrokes { get; private set; }
        public List<Pressure> Pressures { get; private set; }

        public Exercise(SourceText sourcetext)
        {
            statistic = new Statistic();
            source = sourcetext;
        }

        public Exercise(Statistic statistic)
        {
            PassedChars = statistic.PassedChars;
            Errors = statistic.Errors;
            Time = statistic.TotalPrintingTime;
            Rhythmicity = statistic.Rhythmicity;
            Pressures = statistic.Pressures;
            Keystrokes = statistic.Keystrokes;
        }

        public Exercise(string exercise, int id)
        {
            string[] attribures = exercise.Split(Delimeters.Attribute);
            if (attribures.Length == 7)
            {
                Id = id;
                Date = DateTime.Parse(attribures[0]);
                TextTitle = attribures[1];
                PassedChars = Int32.Parse(attribures[2]);
                Errors = Int32.Parse(attribures[3]);
                Time = TimeSpan.Parse(attribures[4]);
                Rhythmicity = float.Parse(attribures[5]);

                Pressures = new List<Pressure>();
                string[] pressures = attribures[6].Split(Delimeters.Pressure);
                Pressure pressure;
                for (int i = 0; i < pressures.Length; i++)
                {
                    attribures = pressures[i].Split(Delimeters.PressureAttr);
                    pressure = new Pressure();
                    Char.TryParse(attribures[0], out pressure.Char);
                    Int32.TryParse(attribures[1], out pressure.Amount);
                    long.TryParse(attribures[2], out pressure.Duration);
                    Pressures.Add(pressure);
                }
            }
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
            if (lineNumber != source.Lines.Length - 1)
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
    }
}
