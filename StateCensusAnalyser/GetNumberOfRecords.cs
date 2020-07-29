using System;
using System.Collections.Generic;
using System.IO;

delegate int NumberOfRecordsInFile(string path);
namespace CSVAnalyser
{
    public class GetNumberOfRecords
    {
        public static int GetNumberOfRecordsMethod(string filePath)
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
    }
}