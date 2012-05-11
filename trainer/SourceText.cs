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

        public int Length
        {
            get
            {
                int result = 0;
                foreach (string s in textData)
                {
                    result += s.Length;
                }
                return result;
            }
        }
        public string Title
        {
            get
            {
                return textData[0];
            }
        }
        public string FileName
        {
            get;
            private set;
        }

        public SourceText(string filePath)
        {
            textData = File.ReadAllLines(filePath, Encoding.Default);
            FileName = Path.GetFileName(filePath);

            for (int i = 0; i < textData.Length - 1; i++)
            {
                textData[i].Trim();
                textData[i] += ' '; // для разрыва со словом из следующей строки
            }
        }

        public string[] Lines
        {
            get { return textData; }
        }
        public SourceInfo GetInfo()
        {
            return new SourceInfo(Length);
        }
    }

    public struct SourceInfo
    {
        public int Length;

        public SourceInfo(int length)
        {
            Length = length;
        }
    }
}
