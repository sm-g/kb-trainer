using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace trainer
{
    class SourceText
    {
        private string[] textData;

        public SourceText(string filePath)
        {
            textData = File.ReadAllLines(filePath, Encoding.Default);
            for (int i = 0; i < textData.Length - 1; i++)
            {
                textData[i].Trim();
                textData[i] += ' ';
            }
        }

        public string[] Lines
        {
            get { return textData; }
        }
    }
}
