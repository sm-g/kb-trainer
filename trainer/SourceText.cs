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
        }

        public string[] Lines
        {
            get { return textData; }
        }
    }
}
