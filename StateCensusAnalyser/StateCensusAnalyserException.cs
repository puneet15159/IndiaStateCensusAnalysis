using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyser
{
    [Serializable]
    public class StateCensusAnalyserException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            INVALID_MOOD
        }

        public StateCensusAnalyserException(string message)
        : base(message) { }
    }
}
