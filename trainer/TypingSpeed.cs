using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trainer
{
    partial class Statistic
    {
        public class TypingSpeed
        {
            const int MIN_KEYSTROKES = 2;
            const int MIN_MSECONDS = 1;

            private Statistic parent;

            public double Average
            {
                get
                {
                    if (parent.keystrokes.Count < MIN_KEYSTROKES)
                        return 0;
                    return GetAverage(parent.TotalPrintingTime, parent.PassedChars);
                }
            }
            public double Instant
            {
                get
                {
                    if (parent.keystrokes.Count < MIN_KEYSTROKES)
                        return 0;
                    int span = FitInstantSpeedSpan(parent.keystrokes.Count);
                    return GetInstant(parent.keystrokes[parent.keystrokes.Count - span].DownTime,
                                      parent.TotalPrintingTime,
                                      span);
                }
            }

            public TypingSpeed(Statistic _parent)
            {
                parent = _parent;
            }

            public static int FitInstantSpeedSpan(int keyskrokesCount)
            {
                if (keyskrokesCount < 10)
                    return 1;
                if (keyskrokesCount < 50)
                    return 2;
                return 3;
            }
            public static double GetAverage(TimeSpan time, int count)
            {
                if (time.TotalMilliseconds < MIN_MSECONDS)
                    return 0;
                return 60 * count / time.TotalSeconds;
            }
            public static double GetInstant(TimeSpan first, TimeSpan last, int span)
            {
                if ((last - first).TotalMilliseconds < MIN_MSECONDS)
                    return 0;
                return 60 * span / (last - first).TotalSeconds;
            }
        }
    }
}
