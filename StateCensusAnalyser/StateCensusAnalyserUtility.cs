using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVAnalyser
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
            
            try
            {
                CSVHelperMethods csvHelper = new CSVHelperMethods();
                return csvHelper.GetCSVRecords(filePath);
                
            }
            catch (CSVException e)
            {

                throw new CSVException(e.Message,e.type);
            }
            
        }

       
    }
}
