using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace trainer
{
    public partial class KeyButton : UserControl
    {
        private static int borderWidth = 1;
        private static int radius = 5;

        private bool highlighted;
        private Color backgroundColor;
        private Color borderColor;

        public string Label
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
            }
        }
        public Fingers Finger { get; set; }
        public bool LabelVisiable
        {
            get
            {
                return label.Visible;
            }
            set
            {
                label.Visible = value;
            }
        }
        public bool IsColored { get; set; }

        public KeyButton()
        {
            InitializeComponent();
        }

        private static void DrawRoundedRectangle(Graphics gfx, Rectangle bounds, int cornerRadius, Pen pen, Color fillColor)
        {
            int strokeOffset = (int)(Math.Ceiling(pen.Width));
            bounds.Inflate(-strokeOffset, -strokeOffset);

            pen.EndCap = pen.StartCap = LineCap.Round;

            GraphicsPath gfxPath = new GraphicsPath();
            gfxPath.AddArc(bounds.X, bounds.Y, cornerRadius, cornerRadius, 180, 90);
            gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y, cornerRadius, cornerRadius, 270, 90);
            gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            gfxPath.AddArc(bounds.X, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            gfxPath.CloseAllFigures();

            gfx.FillPath(new SolidBrush(fillColor), gfxPath);
            gfx.DrawPath(pen, gfxPath);
        }

        private void KeyButton_Paint(object sender, PaintEventArgs e)
        {
            if (IsColored)
            {
                backgroundColor = Colors.OfFinger(Finger);
                borderColor = Colors.OfBorder(Colors.OfFinger(Finger));
            }
            else
            {
                backgroundColor = borderColor = Colors.common;
            }

            if (highlighted)
            {
                backgroundColor = Colors.Highlight(backgroundColor);
                borderColor = Colors.Highlight(borderColor);
            }
            DrawRoundedRectangle(e.Graphics, new Rectangle(0, 0, Width, Height), radius, new Pen(borderColor, borderWidth), backgroundColor);
        }

        public void TurnOnHighlighting()
        {
            highlighted = true;
            label.ForeColor = Colors.keyLabelHighlighted;
            this.Refresh();
        }
        public void TurnOffHighlighting()
        {
            highlighted = false;
            label.ForeColor = Colors.keyLabel;
            this.Refresh();
        }
    }

    public enum Fingers
    {
        None,
        First,
        SecondLeft,
        SecondRight,
        Third,
        Fourth,
        Fifth
    }
}
