using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVAnalyser
{
    public class CSVHelperMethods
    {
        public int GetRecords(string filePath)
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
            catch (DirectoryNotFoundException)
            {

                throw new CSVException("Path is incorrect", CSVException.ExceptionType.FILE_PATH_INCORRECT);
            }
            catch (FileNotFoundException)
            {

                throw new CSVException("Path is incorrect", CSVException.ExceptionType.FILE_NAME_INCORRECT);
            }
        }

        internal int GetCSVRecords(string filePath)
        {
            try
            {
                string[] recordCount = File.ReadAllLines(filePath);
                return recordCount.Length - 1;
            }
            catch (DirectoryNotFoundException)
            {

                throw new CSVException("You have entered a wrong directory path", CSVException.ExceptionType.FILE_PATH_INCORRECT);
            }
            catch (FileNotFoundException)
            {

                throw new CSVException("Name of the file is incorrect", CSVException.ExceptionType.FILE_NAME_INCORRECT);
            }
        }

        public void GetDelimiters(string filePath)
        {
            string[] data = File.ReadAllLines(filePath);
            IEnumerable<string> records = data;
            foreach (var element in records)
            {
                if (!element.Contains(":"))
                {
                    throw new CSVException("Wrong delimiter", CSVException.ExceptionType.DELIMITER_INCORRECT);
                }
            }
        }

        public void GetFileHeaders(string filePath, string alternateFilePath)
        {
            string[] data = File.ReadAllLines(filePath);
            string[] alternateData = File.ReadAllLines(alternateFilePath);
            IEnumerable<string> records = data;
            if (data[0] != alternateData[0])
            {
                throw new CSVException("Headers do not match", CSVException.ExceptionType.HEADERS_DONOT_MATCH);
            }
        }
    }
}
