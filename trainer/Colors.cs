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
        public static Color wrongLetterBackground = Color.Chocolate;
        public static Color passedLetterBackground = Color.Gray;
        public static Color clearLetterBackground = Color.White;
        public static Color wrongLetter = Color.White;
        public static Color passedLetter = Color.Black;
        public static Color clearLetter = Color.Black;

        // надписи на клавишах
        public static Color keyLabel = Color.Black;
        public static Color keyLabelHighlighted = Color.White;

        // фон клавиш
        public static Color common = Color.FromArgb(180, 180, 180);

        // from https://color.adobe.com/ru/Flat-rainbow-color-theme-3012612
        private static Color firstFinger = Color.FromArgb(180, 180, 180);
        private static Color secondLeftFinger = Color.FromArgb(241, 90, 90);
        private static Color secondRightFinger = Color.FromArgb(240, 196, 25);
        private static Color thirdFinger = Color.FromArgb(78, 186, 111);
        private static Color fourthFinger = Color.FromArgb(45, 149, 191);
        private static Color fifthFinger = Color.FromArgb(149, 91, 165);

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
