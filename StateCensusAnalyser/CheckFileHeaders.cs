using System;
using System.Collections.Generic;
using System.IO;

delegate bool FileHeadersCheck(string path, string otherPath);
namespace CSVAnalyser
{
    public class CheckFileHeaders
    {
        public static bool CheckFileHeadersMethod(string filePath, string otherFilePath)
        {
            string[] data = File.ReadAllLines(filePath);
            string[] alternateData = File.ReadAllLines(otherFilePath);
            IEnumerable<string> records = data;
            if (data[0] != alternateData[0])
            {
                return false;
            }

            return true;
        }
    }
}