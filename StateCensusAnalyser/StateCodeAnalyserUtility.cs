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

        public static int GetStateCodeRecords(string filePath)
        {
            try
            {
                CSVHelperMethods csvHelper = new CSVHelperMethods();
                return csvHelper.GetCSVRecords(filePath);

            }
            catch (CSVException e)
            {

                throw new CSVException(e.Message, e.type);
            }
        }
    }
}
