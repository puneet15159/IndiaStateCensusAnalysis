using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CSVAnalyser;

namespace CSVAnalyser
{
    class CSVStateCodeReader
    {
        public static int GetRecords(string filePath)
        {
            try
            {
                CSVHelperMethods csvHelper = new CSVHelperMethods();
                int count = csvHelper.GetRecords(filePath);

                return count - 1;

            }
            catch (CSVException e)
            {

                throw new CSVException(e.Message, e.type);
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
                csvHelper.GetFileHeaders(filePath, alternateFilePath);

            }
            catch (CSVException e)
            {

                throw new CSVException(e.Message, e.type);
            }



        }

    }
}
