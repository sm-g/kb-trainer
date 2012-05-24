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
        private List<Keystroke> keystrokes;
        public List<Pressure> pressures;
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
        public float Rhythmicity { get; set; }

        public Statistic()
        {
            Speed = new TypingSpeed(this);
            keystrokes = new List<Keystroke>();
            stopwatch = new Stopwatch();
            pressures = new List<Pressure>();
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

        public Result GetResult()
        {
            Result result;
            result.Errors = Errors;
            result.Speed = Speed.Average;
            result.PassedChars = PassedChars;
            result.Keystrokes = keystrokes;
            return result;
        }

        public void CalcPressures()
        {
            foreach (var ks in keystrokes)
            {
                int i = pressures.FindIndex(cd => cd.Char == ks.Char);
                if (i == -1)
                {
                    var p = new Pressure();
                    p.Char = ks.Char;
                    pressures.Add(p);
                    i = pressures.Count-1;
                }
                pressures[i].Amount++;
                pressures[i].Duration += ks.Duration.Ticks;
            }
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

    public struct Result
    {
        public double Speed;
        public int Errors;
        public List<Keystroke> Keystrokes;
        public int PassedChars;
    }

    public class Exercise
    {
        public DateTime Date { get; set; }
        public string TextTitle { get; set; }
        public double Speed { get { return Statistic.TypingSpeed.GetAverage(TotalPrintingTime, PassedChars); } }
        public int PassedChars { get; set; }
        public int Errors { get; set; }
        public TimeSpan TotalPrintingTime { get; set; }
        public float Rhythmicity { get; set; }
        public List<Pressure> Pressures { get; set; }

        public Exercise(string exercise)
        {
            string[] attribures = exercise.Split(Delimeters.Attribute);
            if (attribures.Length == 7)
            {
                Date = DateTime.Parse(attribures[0]);
                TextTitle = attribures[1];
                PassedChars = Int32.Parse(attribures[2]);
                Errors = Int32.Parse(attribures[3]);
                TotalPrintingTime = TimeSpan.Parse(attribures[4]);
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
    }
}
