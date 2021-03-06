﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace trainer
{
    public partial class Keyboard : UserControl
    {
        private const string Map = "ё1234567890-=йцукенгшщзхъ\\фывапролджэячсмитьбю. Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪ/ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ, ~!@#$%^&";
        private Dictionary<int, KeyButton> letterKeyButtons;
        private List<KeyButton> highlightedKeyButtons;
        private bool labeled = true;
        private bool colored = false;

        public bool Labeled
        {
            get { return labeled; }
            set
            {
                if (labeled != value)
                {
                    labeled = value;
                    foreach (var kb in letterKeyButtons)
                    {
                        kb.Value.LabelVisiable = value;
                    }
                }
            }
        }
        public bool FingerZonesColored
        {
            get { return colored; }
            set
            {
                if (colored != value)
                {
                    colored = value;
                    foreach (var kb in letterKeyButtons)
                    {
                        kb.Value.IsColored = value;
                    }
                    Refresh();
                }
            }
        }

        public Keyboard()
        {
            InitializeComponent();
            InitKeyButtons();
        }

        private void InitKeyButtons()
        {
            highlightedKeyButtons = new List<KeyButton>();
            letterKeyButtons = new Dictionary<int, KeyButton>();
            for (int i = 0; i < tableLayoutPanel.Controls.Count; i++)
                for (int j = 0; j < tableLayoutPanel.Controls[i].Controls.Count; j++)
                {
                    KeyButton kb = (KeyButton)tableLayoutPanel.Controls[i].Controls[j];
                    string kbNameCode = System.Text.RegularExpressions.Regex.Replace(kb.Name, @"[^\d]+", "");
                    if (kbNameCode.Length > 0)
                    {
                        int kbCode = Int32.Parse(kbNameCode);
                        letterKeyButtons.Add(kbCode, kb);

                        kb.Label = Char.ToUpper(Map[kbCode - 1]).ToString();
                    }
                }
        }

        private void SetKeyButtonsToHighlight(char ch)
        {
            int layoutCode = Map.IndexOf(ch);
            if (layoutCode > letterKeyButtons.Count - 1)
            {
                highlightedKeyButtons.Add(keyButtonLShift);
                highlightedKeyButtons.Add(keyButtonRShift);
            }

            if (layoutCode != -1)
            {
                int kbCode = layoutCode % letterKeyButtons.Count + 1;
                highlightedKeyButtons.Add(letterKeyButtons[kbCode]);
            }
            else
            {
                if (ch == '\b')
                    highlightedKeyButtons.Add(keyButtonBackspace);
            }
        }
        public void TurnOffHighlighting()
        {
            foreach (var kb in highlightedKeyButtons)
            {
                kb.TurnOffHighlighting();
            }
            highlightedKeyButtons.Clear();
        }
        public void HighlightKeyButtons(char ch)
        {
            TurnOffHighlighting();
            SetKeyButtonsToHighlight(ch);

            foreach (var kb in highlightedKeyButtons)
            {
                kb.TurnOnHighlighting();
            }
        }

        public Image GetFingerColorsSquare(int size)
        {
            Bitmap result = new Bitmap(size, size);

            int half = size / 2;
            using (Graphics g = Graphics.FromImage(result))
            {
                g.FillRectangle(new SolidBrush(Colors.OfFinger(Fingers.Fourth)), 0, 0, half, half);
                g.FillRectangle(new SolidBrush(Colors.OfFinger(Fingers.Fifth)), half, 0, size, half);
                g.FillRectangle(new SolidBrush(Colors.OfFinger(Fingers.SecondLeft)), 0, half, half, size);
                g.FillRectangle(new SolidBrush(Colors.OfFinger(Fingers.Third)), half, half, size, size);
            }

            return result;
        }

        private void Keyboard_Resize(object sender, EventArgs e)
        {
            float keyWidth = tableLayoutPanel1Row.Width * tableLayoutPanel1Row.ColumnStyles[0].Width / 100;
            SetKeyColumnsWidth(tableLayoutPanel3Row, keyWidth);
            SetKeyColumnsWidth(tableLayoutPanel4Row, keyWidth);
        }
        private void SetKeyColumnsWidth(TableLayoutPanel panel, float width)
        {
            for (int i = 1; i < panel.ColumnCount - 1; i++)
                panel.ColumnStyles[i].Width = width;
        }
    }
}
