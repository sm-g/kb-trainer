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
        static Color backColor = Color.Honeydew;
        static Color backColorSelect = Color.Red;
        static Color borderColor = Color.Green;
        static int borderWidth = 1;
        static int radius = 5;

        Color bColor = backColor;

        public char ch { get; set; }
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
        public Fingers finger;

        public KeyButton()
        {
            InitializeComponent();
            DrawRoundedRectangle(label.CreateGraphics(), new Rectangle(1, 1, 25, 25), 2, new Pen(Color.Green), Color.Honeydew);
        }

        private void DrawRoundedRectangle(Graphics gfx, Rectangle Bounds, int CornerRadius, Pen DrawPen, Color FillColor)
        {
            int strokeOffset = (int)(Math.Ceiling(DrawPen.Width));
            Bounds.Inflate(-strokeOffset, -strokeOffset);

            DrawPen.EndCap = DrawPen.StartCap = LineCap.Round;

            GraphicsPath gfxPath = new GraphicsPath();
            gfxPath.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gfxPath.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            gfxPath.CloseAllFigures();

            gfx.FillPath(new SolidBrush(FillColor), gfxPath);
            gfx.DrawPath(DrawPen, gfxPath);
        }

        private void KeyButton_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedRectangle(e.Graphics, new Rectangle(0, 0, Width, Height), radius, new Pen(borderColor,borderWidth), bColor);
        }

        public void Highlight()
        {
            bColor = backColorSelect;
            this.Refresh();
        }


        internal void TurnHighlightOff()
        {
            bColor = backColor;
            this.Refresh();
        }
    }

    public enum Fingers
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }
}
