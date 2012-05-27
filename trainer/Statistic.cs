using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace trainer
{
    public partial class Statistic
    {
        const int MIN_MSECONDS = 1;
        const int MAX_INSTANT_POINTS = 200;
        const double MAX_SPEED = 2000.0;
        const int MIN_KEYSTROKES = 2;

        public List<Keystroke> Keystrokes { get; private set; }
        public int PassedChars { get; private set; }
        public int Errors { get; private set; }
        public double Speed
        {
            get
            {
                if (PassedChars < MIN_KEYSTROKES)
                    return 0;
                return GetAverageSpeed(TotalPrintingTime, PassedChars);
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

        public Statistic()
        {
            Keystrokes = new List<Keystroke>();
        }

        public void AddChar(char ch)
        {
            PassedChars++;
            Keystrokes[Keystrokes.Count - 1].Char = ch;
        }
        public void AddError()
        {
            Errors++;
        }
        public void AddDeletion(char ch)
        {
            PassedChars--;
            Keystrokes[Keystrokes.Count - 1].Char = ch;
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
        public static double GetAverageSpeed(TimeSpan time, int count)
        {
            return GetInstantSpeed(TimeSpan.Zero, time, count);
        }
        public static double GetInstantSpeed(TimeSpan first, TimeSpan last, int span)
        {
            if ((last - first).TotalMilliseconds < MIN_MSECONDS)
                return 0;
            double result = 60 * span / (last - first).TotalSeconds;
            if (result > MAX_SPEED)
                return MAX_SPEED;
            else
                return result;
        }

        public void CleanKeystrokes()
        {
            Keystrokes.RemoveAll(keystroke => keystroke.Char == '\0');
            foreach (var k in Keystrokes)
                Console.WriteLine(k.Char);
        }
    }

    public class Keystroke
    {
        public TimeSpan DownTime { get; private set; }
        public char Char { get; set; }

        public Keystroke(TimeSpan downTime)
        {
            DownTime = downTime;
        }
    }
}
