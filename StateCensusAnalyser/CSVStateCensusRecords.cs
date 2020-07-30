using System.Collections.Generic;
using System.IO;

namespace CSVAnalyser
{
    public class CSVStateCensusRecords
    {
        public static int GetRecords(string filePath)
        {
            try
            {
                CSVHelperMethods csvHelper = new CSVHelperMethods();
                int count = csvHelper.GetRecords(filePath);

                return count;

            }
            catch (CSVException e)
            {

                throw new CSVException(e.Message,e.type);
            }
            
        }

        public static void GetDelimiters(string filePath)
        {

            try
            {
                CSVHelperMethods csvHelper = new CSVHelperMethods();
                csvHelper.GetDelimiters(filePath);

            }
            catch (CSVException e)
            {

                throw new CSVException(e.Message, e.type);
            }

            
            
        }

        public static void GetFileHeaders(string filePath, string alternateFilePath)
        {
            try
            {
                
                CSVHelperMethods csvHelper = new CSVHelperMethods();
                csvHelper.GetFileHeaders(filePath,alternateFilePath);

            }
            catch (CSVException e)
            {

                throw new CSVException(e.Message, e.type);
            }



        }

        public string GetJSONFromCSV(string filePath)
        {
            CSVHelperMethods csvHelper = new CSVHelperMethods();
            return csvHelper.GetJSON(filePath);
        }

        public string SortJSONByState(string data)
        {
            CSVHelperMethods csvHelper = new CSVHelperMethods();
            return csvHelper.SortJSONDataAccordingToState(data);
        }

        public string SortJSONByStateCode(string data)
        {
            CSVHelperMethods csvHelper = new CSVHelperMethods();
            return csvHelper.SortJSONDataAccordingToStateCode(data);
        }


    }
}