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
                    if (parent.timesList.Count < MIN_KEYS)
                        return 0;
                    return GetAverage(TimeSpan.FromMilliseconds(parent.TotalPrintingTime), parent.PassedChars);
                }
            }
            public double Instant
            {
                get
                {
                    if (parent.timesList.Count < MIN_KEYS)
                        return 0;
                    return GetInstant(TimeSpan.FromMilliseconds(parent.timesList[parent.timesList.Count - InstantSpan - 1].DownTime),
                                      TimeSpan.FromMilliseconds(parent.TotalPrintingTime),
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
