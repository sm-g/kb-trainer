using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace trainer
{
    class Statistic
    {
        /// <summary>
        /// Скорость набора (нажатий в минуту)
        /// </summary>
        public class Velocity
        {
            const int MIN_KEYS      = 2; // минимум нажатий для рассчета скорости
            private int instantSpan = 3; // количество нажатий для рассчета мгновенной скорости
            private Statistic parent;
            
            public int InstantSpan { get { return instantSpan; } set { if (value < 1) value = 1; instantSpan = value; } }           
            
            public Velocity(Statistic _parent)
            {
                parent = _parent;
            }
            public double Average
            {
                get
                {
                    if (parent.timesList.Count < MIN_KEYS)
                        return 0;
                    return 60 * parent.PassedChars / TimeSpan.FromMilliseconds(parent.TotalPrintingTime).TotalSeconds;
                }
            }
            public double Instant
            {
                get
                {
                    if (parent.timesList.Count < MIN_KEYS)
                        return 0;
                    return 60 * InstantSpan / TimeSpan.FromMilliseconds(parent.TotalPrintingTime - parent.timesList[parent.timesList.Count - InstantSpan - 1].DownTime).TotalSeconds;
                }
            }
        }
        
        private Stopwatch currentStopwatch;
        private Stopwatch globalStopwatch;
        private List<KeystrokeInfo> timesList;
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
            get { return timesList.Count == 0; }
        }
        public long TotalPrintingTime
        {
            get { return timesList[timesList.Count - 1].DownTime; }
        }

        public Statistic()
        {
            Speed = new Velocity(this);
            timesList = new List<KeystrokeInfo>();
            currentStopwatch = new Stopwatch();
            globalStopwatch = new Stopwatch();
        }

        public void AddChar(char ch)
        {
            typedCharsCounter++;
        }

        public void AddError(char ch)
        {
            errorsCounter++;
        }

        public void AddDeletion()
        {
            deletedCharsCounter++;
        }

        public void RegisterKeyDown()
        {
            currentStopwatch.Restart();
            if (IsEmpty)
            {
                globalStopwatch.Start();
            }
        }

        public void RegisterKeyUp(char ch)
        {
            timesList.Add(new KeystrokeInfo(globalStopwatch.ElapsedMilliseconds, currentStopwatch.ElapsedMilliseconds, ch));
            currentStopwatch.Stop();
        }
    }
    /// <summary>
    /// Информация об отдельном нажатии
    /// </summary>
    class KeystrokeInfo
    {
        public long DownTime { get; set; }
        public long UpTime { get { return DownTime + Duration; } }
        public long Duration { get; set; }
        public char Char { get; set; }

        public KeystrokeInfo(long globalSpan, long durationSpan, char ch)
        {
            DownTime = globalSpan;
            Duration = durationSpan;
            Char = ch;            
        }
    }
}
