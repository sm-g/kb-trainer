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
        public static Color errorColor  = Color.Chocolate;
        public static Color passedColor = Color.Gray;
        public static Color clearColor  = Color.White;

        // надписи на клавишах
        public static Color keyLabel            = Color.Black;
        public static Color keyLabelHighlighted = Color.White;

        // фон клавиш
        public static Color highlightColor = Color.Red;
        public static Color borderColor    = Color.Gray;

        public static Color commonColor = Color.FromArgb(60, 200, 60);

        public static Color firstFinger       = Color.FromArgb(60, 200, 60);
        public static Color secondLeftFinger  = Color.FromArgb(60, 200, 60);
        public static Color secondRightFinger = Color.FromArgb(60, 200, 60);
        public static Color thirdFinger       = Color.FromArgb(60, 200, 60);
        public static Color fourthFinger      = Color.FromArgb(60, 200, 60);
        public static Color fifthFinger       = Color.FromArgb(60, 200, 60);
        
        public static Color OfFinger(Fingers finger)
        {
            switch (finger)
            {
                case Fingers.None: return Colors.commonColor;
                case Fingers.First: return Colors.firstFinger;
                case Fingers.SecondLeft: return Colors.secondLeftFinger;
                case Fingers.SecondRight: return Colors.secondRightFinger;
                case Fingers.Third: return Colors.thirdFinger;
                case Fingers.Fourth: return Colors.fourthFinger;
                case Fingers.Fifth: return Colors.fifthFinger;
            }
            return Color.Black;
        }

        public static Color OfBorder(Color baseColor)
        {
            return baseColor;
        }

        public static Color Highlight(Color baseColor)
        {
            return Color.FromArgb(128, baseColor);
        }
    }
}
