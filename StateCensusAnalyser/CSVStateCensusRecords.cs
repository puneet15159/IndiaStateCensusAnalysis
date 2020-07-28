using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace StateCensusAnalyser
{
    public class CSVStateCensusRecords
    {
        public static int GetRecords(string filePath)
        {
            try
            {
                int count = 0;
                string[] data = File.ReadAllLines(filePath);
                IEnumerable<string> records = data;
                foreach (var element in records)
                {
                    count++;
                }

                return count - 1;

            }
            catch (DirectoryNotFoundException e)
            {

                throw new StateCensusAnalyserException("You have entered a wrong directory path");
            }
        }
    }
}