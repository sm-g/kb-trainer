using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace trainer
{
    public partial class Statistic
    {
        const int MIN_KEYSTROKES = 2;
        private List<Pressure> pressures;

        public List<Keystroke> Keystrokes { get; private set; }
        public int PassedChars { get; private set; }
        public int Errors { get; private set; }
        public double Speed
        {
            get
            {
                if (PassedChars < MIN_KEYSTROKES)
                    return 0;
                return Statistic.TypingSpeed.GetAverage(TotalPrintingTime, PassedChars);
            }
        }
        public TimeSpan TotalPrintingTime { get { return Keystrokes[Keystrokes.Count - 1].DownTime; } }
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
            Keystrokes = new List<Keystroke>();
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
