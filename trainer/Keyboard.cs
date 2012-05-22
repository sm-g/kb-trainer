using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace trainer
{
    public partial class Keyboard : UserControl
    {
        private const string MAP = "ё1234567890-=йцукенгшщзхъ\\фывапролджэячсмитьбю. Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪ/ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ, ~!@#$%^&";
        private Dictionary<int, KeyButton> letterKeyButtons;
        private List<KeyButton> highlightedKeyButtons;

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

                        kb.Label = Char.ToUpper(MAP[kbCode - 1]).ToString();
                    }
                }
        }

        private void SetKeyButtonsToHighlight(char ch)
        {
            int layoutCode = MAP.IndexOf(ch);
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
        public void HighlightKeys(char ch)
        {
            TurnOffHighlighting();
            SetKeyButtonsToHighlight(ch);

            foreach (var kb in highlightedKeyButtons)
            {
                kb.TurnOnHighlighting();
            }
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
