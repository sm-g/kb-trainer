﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace trainer
{
    class Statistic
    {
        /// <summary>
        /// Скорость набора (нажатий в минуту)
        /// </summary>
        public class Velocity
        {
            const int MIN_KEYS = 2; // минимум нажатий для рассчета скорости
            const int MIN_MSEC = 1; // минимальный промежуток времени (в мс)
            private int instantSpan = 3;
            private Statistic parent;
            /// <summary>
            /// Количество нажатий для рассчета мгновенной скорости
            /// </summary>
            public int InstantSpan { get { return instantSpan; } set { if (value < 1) value = 1; instantSpan = value; } }
            public double Average
            {
                get
                {
                    if (parent.keystrokes.Count < MIN_KEYS)
                        return 0;
                    return GetAverage(parent.TotalPrintingTime, parent.PassedChars);
                }
            }
            public double Instant
            {
                get
                {
                    if (parent.keystrokes.Count < MIN_KEYS)
                        return 0;
                    return GetInstant(parent.keystrokes[parent.keystrokes.Count - InstantSpan].DownTime,
                                      parent.TotalPrintingTime,
                                      InstantSpan);
                }
            }

            public Velocity(Statistic _parent)
            {
                parent = _parent;
            }
            public static double GetAverage(TimeSpan time, int count)
            {
                if (time.TotalMilliseconds < MIN_MSEC)
                    return 0;
                return 60 * count / time.TotalSeconds;
            }
            public static double GetInstant(TimeSpan first, TimeSpan last, int span)
            {
                if ((last - first).TotalMilliseconds < MIN_MSEC)
                    return 0;
                return 60 * span / (last - first).TotalSeconds;
            }
        }

        private Stopwatch stopwatch;
        private List<Keystroke> keystrokes;
        private int errorsCounter;
        private int deletedCharsCounter;
        private int typedCharsCounter;

        public Velocity Speed { get; set; }
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

        public Statistic()
        {
            Speed = new Velocity(this);
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
            if (keystroke != null) // может быть зарегистрирована нажатая в другом окне клавиша
                keystroke.UpTime = stopwatch.Elapsed;            
        }
        public void Pause()
        {
            stopwatch.Stop();
        }
        public ResultInfo GetResultInfo()
        {
            return new ResultInfo(Speed.Average, Errors, PassedChars, keystrokes);
        }
    }
    /// <summary>
    /// Информация об отдельном нажатии
    /// </summary>
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
    /// <summary>
    /// Данные о результате
    /// </summary>
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
