using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVAnalyser
{
    class StateCodeAnalyserUtility
    {
        private string filepath;

        public StateCodeAnalyserUtility(string filepath)
        {
            this.filepath = filepath;
        }

        public static int GetStateCensusRecords(string filePath)
        {
            try
            {
                string[] recordCount = File.ReadAllLines(filePath);
                return recordCount.Length - 1;
            }
            catch (DirectoryNotFoundException)
            {

                throw new CSVException("You have entered a wrong directory path");
            }
            catch (FileNotFoundException)
            {

                throw new CSVException("Name of the file is incorrect");
            }
        }
    }
}
