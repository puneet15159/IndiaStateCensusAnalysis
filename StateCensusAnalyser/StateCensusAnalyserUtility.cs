using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StateCensusAnalyser
{
    public class StateCensusAnalyserUtility
    {
        private string filepath;

        public StateCensusAnalyserUtility(string filepath)
        {
            this.filepath = filepath;
        }

        public static int GetStateCensusRecords(string filePath)
        {
            string[] recordCount = File.ReadAllLines(filePath);
            return recordCount.Length - 1;
        }
    }
}
