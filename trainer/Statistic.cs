using System;
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

        public void AddDeletion(char ch)
        {
            deletedCharsCounter++;
        }

        public void RegisterKeyDown(Keys key)
        {
            if (IsEmpty)
            {
                globalStopwatch.Start();
            }
            timesList.Add(new KeystrokeInfo(globalStopwatch.ElapsedMilliseconds, key));
        }

        public void RegisterKeyUp(Keys key)
        {
            timesList.Last(item => item.Key == key).UpTime = globalStopwatch.ElapsedMilliseconds;
        }
    }
    /// <summary>
    /// Информация об отдельном нажатии
    /// </summary>
    public class KeystrokeInfo
    {
        public long DownTime { get; set; }
        public long UpTime { get; set; }
        public long Duration { get { return UpTime - DownTime; } }
        public Keys Key { get; set; }

        public KeystrokeInfo(long downTime, Keys key)
        {
            DownTime = downTime;
            Key = key;
        }
    }
}
