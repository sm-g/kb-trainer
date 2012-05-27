﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

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
        private const int MIN_RESULT_CHARS = 5;

        private Stopwatch stopwatch;
        private Statistic statistic;
        private SourceText source;
        private int inLinePosition;
        private int lineNumber;
        private int wrongChars;

        public ExerciseState State { get; set; }
        public TimeSpan PastTime { get { return stopwatch.Elapsed; } }
        public TimeSpan ExpectedRemainTime
        {
            get
            {
                if (statistic.PassedChars > MIN_RESULT_CHARS)
                    return TimeSpan.FromMinutes(source.Length / Statistic.GetAverageSpeed(PastTime, statistic.PassedChars));
                else return TimeSpan.Zero;
            }
        }

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
        public bool EnoughToResult { get { return statistic.PassedChars > MIN_RESULT_CHARS; } }
        public bool TextEnded { get { return TextProgress == 1; } }
        public bool IsCorrectingWrongChars { get { return wrongChars > 0; } }

        public double Speed { get { return statistic.Speed; } }
        public int Errors { get { return statistic.Errors; } }

        public Exercise(SourceText sourcetext)
        {
            statistic = new Statistic();
            stopwatch = new Stopwatch();
            source = sourcetext;
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

        private void AddWrongChar()
        {
            if (!IsCorrectingWrongChars)
            {
                statistic.AddError();
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
                AddWrongChar();
                return false;
            }
        }

        public void PauseTimer()
        {

        }

        public void RegisterKeyDown(Keys key)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }
            statistic.Keystrokes.Add(new Keystroke(stopwatch.Elapsed, key));
        }

        public FinalizedExercise GetResult()
        {
            return new FinalizedExercise(source, statistic);
        }
    }

    public class FinalizedExercise
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public string TextTitle { get; private set; }

        public int PassedChars { get; private set; }
        public int Errors { get; private set; }
        public TimeSpan Time { get; private set; }
        public double Rhythmicity { get; private set; }

        public double Speed { get { return Math.Round(Statistic.GetAverageSpeed(Time, PassedChars), 2); } }
        public double ErrorsPercent { get { return Math.Round((double)100 * Errors / PassedChars, 2); } }
        public string FormattedTime { get { return ResultForm.FormatTimeSpan(Time); } }

        public List<Keystroke> Keystrokes { get; private set; }

        public FinalizedExercise(SourceText source, Statistic statistic)
        {
            TextTitle = source.Title;
            PassedChars = statistic.PassedChars;
            Errors = statistic.Errors;
            Time = statistic.TotalPrintingTime;
            Rhythmicity = statistic.Rhythmicity;
            Keystrokes = statistic.Keystrokes;
        }

        public FinalizedExercise(string exercise, int id)
        {
            string[] attribures = exercise.Split(Delimeters.Attribute);
            if (attribures.Length == 6)
            {
                Id = id;
                Date = DateTime.Parse(attribures[0]);
                TextTitle = attribures[1];
                PassedChars = Int32.Parse(attribures[2]);
                Errors = Int32.Parse(attribures[3]);
                Time = TimeSpan.Parse(attribures[4]);
                Rhythmicity = float.Parse(attribures[5]);
            }
        }
    }
}
