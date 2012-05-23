using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace trainer
{
    public static class Colors
    {
        // буквы в текстовых полях
        public static Color wrongLetterBackground  = Color.Chocolate;
        public static Color passedLetterBackground = Color.Gray;
        public static Color clearLetterBackground = Color.White;
        public static Color wrongLetter = Color.White;
        public static Color passedLetter = Color.Black;
        public static Color clearLetter = Color.Black;

        // надписи на клавишах
        public static Color keyLabel            = Color.Black;
        public static Color keyLabelHighlighted = Color.White;

        // фон клавиш
        public static Color common = Color.FromArgb(60, 200, 60);

        private static Color firstFinger       = Color.FromArgb(60, 200, 60);
        private static Color secondLeftFinger  = Color.FromArgb(60, 200, 60);
        private static Color secondRightFinger = Color.FromArgb(60, 200, 60);
        private static Color thirdFinger       = Color.FromArgb(60, 200, 60);
        private static Color fourthFinger      = Color.FromArgb(60, 200, 60);
        private static Color fifthFinger       = Color.FromArgb(60, 200, 60);
        
        public static Color OfFinger(Fingers finger)
        {
            switch (finger)
            {
                case Fingers.First: return Colors.firstFinger;
                case Fingers.SecondLeft: return Colors.secondLeftFinger;
                case Fingers.SecondRight: return Colors.secondRightFinger;
                case Fingers.Third: return Colors.thirdFinger;
                case Fingers.Fourth: return Colors.fourthFinger;
                case Fingers.Fifth: return Colors.fifthFinger;
                default: return Colors.common;
            }
        }

        public static Color OfBorder(Color baseColor)
        {
            return Color.Gray;
        }

        public static Color Highlight(Color baseColor)
        {
            return Color.FromArgb(128, baseColor);
        }
    }
}
