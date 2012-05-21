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
        public Keyboard()
        {
            InitializeComponent();
        }

        public void HighlightKey(char ch)
        {
            if (ch != '\0')
            {
                KeyButton kb;
                for (int i = 0; i < tableLayoutPanel.Controls.Count; i++)
                    for (int j = 0; j < tableLayoutPanel.Controls[i].Controls.Count; j++)
                    {
                        kb = (KeyButton)tableLayoutPanel.Controls[i].Controls[j];
                        if (kb.Char == ch)
                        {
                            kb.Highlight();
                        }
                        else
                        {
                            kb.TurnHighlightOff();
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
