using System;
using System.Collections.Generic;
using System.Text;

namespace CSVAnalyser
{
    [Serializable]
    public class CSVException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            INVALID_MOOD
        }

        public CSVException(string message)
        : base(message) { }
    }
}
