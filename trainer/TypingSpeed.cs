using System;

namespace trainer
{
    partial class Statistic
    {
        public class TypingSpeed
        {
            const int MIN_KEYSTROKES = 2;
            const int MIN_MSECONDS = 1;
            const int MAX_INSTANT_POINTS = 200;

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
                int result = 1;
                int sup = 10;
                while (sup < keyskrokesCount)
                {
                    result++;
                    sup *= 3;
                }

                if (keyskrokesCount / result <= MAX_INSTANT_POINTS)
                    return result;
                else
                    return keyskrokesCount / MAX_INSTANT_POINTS;
            }
            public static double GetAverage(TimeSpan time, int count)
            {
                return TypingSpeed.GetInstant(TimeSpan.Zero, time, count);
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
