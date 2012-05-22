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

        public Keyboard()
        {
            InitializeComponent();
            InitKeyButtons();
        }

        private void InitKeyButtons()
        {
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

                        kb.Label = MAP[kbCode - 1].ToString();
                    }
                }
        }

        public void HighlightKey(char ch)
        {
            int kbCode = MAP.IndexOf(ch) % letterKeyButtons.Count + 1;

            if (kbCode != -1)
            {
                foreach (var kb in letterKeyButtons)
                {
                    if (kb.Key == kbCode)
                    {
                        kb.Value.TurnOnHighlight();
                    }
                    else
                    {
                        kb.Value.TurnOffHighlight();
                    }
                }
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
