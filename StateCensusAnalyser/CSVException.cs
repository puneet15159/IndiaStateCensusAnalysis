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
            RECORDS_NUMBER_DONOT_MATCH,
            FILE_NAME_INCORRECT,
            FILE_PATH_INCORRECT,
            DELIMITER_INCORRECT,
            HEADERS_DONOT_MATCH
        }

        public CSVException(string message, ExceptionType type)
        : base(message) {
            this.type = type;
        }
    }
}
