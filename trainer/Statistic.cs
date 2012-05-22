using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace trainer
{
    partial class Statistic
    {
        private const int MIN_RESULT_CHARS = 5;
        private Stopwatch stopwatch;
        private List<Keystroke> keystrokes;
        private int errorsCounter;
        private int deletedCharsCounter;
        private int typedCharsCounter;

        public TypingSpeed Speed { get; set; }
        public int PassedChars
        {
            get { return typedCharsCounter - deletedCharsCounter; }
        }
        public int Errors
        {
            get { return errorsCounter; }
        }
        public bool IsEmpty
        {
            get { return keystrokes.Count == 0; }
        }
        public TimeSpan TotalPrintingTime
        {
            get { return keystrokes[keystrokes.Count - 1].DownTime; }
        }
        public TimeSpan Now
        {
            get { return stopwatch.Elapsed; }
        }
        public bool EnoughToResult
        {
            get { return PassedChars > MIN_RESULT_CHARS; }
        }

        public Statistic()
        {
            Speed = new TypingSpeed(this);
            keystrokes = new List<Keystroke>();
            stopwatch = new Stopwatch();
        }

        public void AddChar(char ch)
        {
            typedCharsCounter++;
            keystrokes[keystrokes.Count - 1].Char = ch;
        }
        public void AddError(char ch)
        {
            errorsCounter++;
            keystrokes[keystrokes.Count - 1].IsError = true;
        }
        public void AddDeletion(char ch)
        {
            deletedCharsCounter++;
            keystrokes[keystrokes.Count - 1].Char = ch;
        }
        public void RegisterKeyDown(Keys key)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }
            keystrokes.Add(new Keystroke(stopwatch.Elapsed, key));
        }
        public void RegisterKeyUp(Keys key)
        {
            Keystroke keystroke = keystrokes.LastOrDefault(item => item.Key == key && !item.IsCompleted);
            if (keystroke != null) // может быть зарегистрирована нажатая в другом окне клавиша (её не будет в списке)
                keystroke.UpTime = stopwatch.Elapsed;
        }
        public void PauseTimer()
        {
            stopwatch.Stop();
        }
        public ResultInfo GetResultInfo()
        {
            return new ResultInfo(Speed.Average, Errors, PassedChars, keystrokes);
        }
    }

    public class Keystroke
    {
        public TimeSpan DownTime { get; set; }
        public TimeSpan UpTime { get; set; }
        public TimeSpan Duration { get { return UpTime - DownTime; } }
        public Keys Key { get; set; }
        public char Char { get; set; }
        public bool IsError { get; set; }
        public bool IsCompleted { get { return UpTime != TimeSpan.Zero; } }

        public Keystroke(TimeSpan downTime, Keys key)
        {
            DownTime = downTime;
            Key = key;
        }
    }

    public struct ResultInfo
    {
        public double Speed;
        public int Errors;
        public List<Keystroke> Keystrokes;
        public int PassedChars;

        public ResultInfo(double speed, int errors, int passedChars, List<Keystroke> keystrokes)
        {
            Speed = speed;
            Errors = errors;
            PassedChars = passedChars;
            Keystrokes = keystrokes;
        }
    }
}
