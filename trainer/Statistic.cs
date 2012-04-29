using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trainer
{
    class Statistic
    {
        private int errorsCounter;
        private int deletedCharsCounter;
        private int typedCharsCounter;

        public int PassedChars
        {
            get { return typedCharsCounter - deletedCharsCounter; }
        }

        public int Errors
        {
            get { return errorsCounter; }
        }

        public void AddChar(char ch)
        {
            typedCharsCounter++;
        }

        public void AddError(char ch)
        {
            errorsCounter++;
        }

        public void AddDeletion()
        {
            deletedCharsCounter++;
        }
    }

    class KeyInfo
    {

    }
}
