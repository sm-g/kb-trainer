using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace trainer
{
    public partial class Statistic
    {
        private const int MIN_RESULT_CHARS = 5;

        private Stopwatch stopwatch;
        private List<Pressure> pressures;

        public List<Keystroke> Keystrokes { get; private set; }
        public TypingSpeed Speed { get; private set; }
        public int PassedChars { get; private set; }
        public int Errors { get; private set; }
        public TimeSpan TotalPrintingTime { get { return Keystrokes[Keystrokes.Count - 1].DownTime; } }
        public TimeSpan Now { get { return stopwatch.Elapsed; } }
        public bool EnoughToResult { get { return PassedChars > MIN_RESULT_CHARS; } }
        public int Rhythmicity
        {
            get
            {
                int[] keystrokresIntervals = new int[Keystrokes.Count - 1];
                for (int i = 0; i < Keystrokes.Count - 1; i++)
                {
                    keystrokresIntervals[i] = (Keystrokes[i + 1].DownTime - Keystrokes[i].DownTime).Milliseconds;
                }
                double average = keystrokresIntervals.Average();
                double sumOfSquaresOfDifferences = keystrokresIntervals.Select(val => (val - average) * (val - average)).Sum();
                double sd = Math.Sqrt(sumOfSquaresOfDifferences / keystrokresIntervals.Length);
                return (int)((1 - sd / average) * 100);
            }
        }
        public List<Pressure> Pressures
        {
            get
            {
                foreach (var ks in Keystrokes)
                {
                    int i = pressures.FindIndex(pressure => pressure.Char == ks.Char);
                    if (i == -1)
                    {
                        var p = new Pressure();
                        p.Char = ks.Char;
                        pressures.Add(p);
                        i = pressures.Count - 1;
                    }
                    pressures[i].Amount++;
                    pressures[i].Duration += ks.Duration.Ticks;
                }
                return pressures;
            }
            private set
            {
                pressures = value;
            }
        }

        public Statistic()
        {
            Speed = new TypingSpeed(this);
            Keystrokes = new List<Keystroke>();
            stopwatch = new Stopwatch();
            Pressures = new List<Pressure>();
        }

        public void AddChar(char ch)
        {
            PassedChars++;
            Keystrokes[Keystrokes.Count - 1].Char = ch;
        }
        public void AddError(char ch)
        {
            Errors++;
            Keystrokes[Keystrokes.Count - 1].IsError = true;
        }
        public void AddDeletion(char ch)
        {
            PassedChars--;
            Keystrokes[Keystrokes.Count - 1].Char = ch;
        }

        public void RegisterKeyDown(Keys key)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }
            Keystrokes.Add(new Keystroke(stopwatch.Elapsed, key));
        }
        public void RegisterKeyUp(Keys key)
        {
            Keystroke keystroke = Keystrokes.LastOrDefault(item => item.Key == key && !item.IsCompleted);
            if (keystroke != null) // может быть зарегистрирована нажатая в другом окне клавиша (её не будет в списке)
                keystroke.UpTime = stopwatch.Elapsed;
        }

        public void PauseTimer()
        {
            stopwatch.Stop();
        }

        public TimeSpan GetExpectedRemainTime(int textLength)
        {
            if (PassedChars > MIN_RESULT_CHARS)
                return TimeSpan.FromMinutes(textLength / Speed.Average);
            else return TimeSpan.Zero;
        }

        public Exercise GetResult()
        {
            return new Exercise(this);
        }   
    }

    public class Pressure
    {
        [XmlAttribute]
        public char Char;
        [XmlAttribute]
        public int Amount;
        [XmlAttribute]
        public long Duration;
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
}
