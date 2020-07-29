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

                throw new CSVException("You have entered a wrong directory path");
            }
            catch (FileNotFoundException)
            {

                throw new CSVException("Name of the file is incorrect");
            }
        }

        public static void GetDelimiters(string filePath)
        {

            string[] data = File.ReadAllLines(filePath);
            IEnumerable<string> records = data;
            foreach (var element in records)
            {
                if (!element.Contains(","))
                {
                    throw new CSVException("Wrong delimiter");
                }
            }

        }

        public static void GetFileHeaders(string filePath, string alternateFilePath)
        {

            string[] data = File.ReadAllLines(filePath);
            string[] alternateData = File.ReadAllLines(alternateFilePath);
            IEnumerable<string> records = data;
            if (data[0] != alternateData[0])
            {
                throw new CSVException("Headers do not match");
            }

        }


    }
}
