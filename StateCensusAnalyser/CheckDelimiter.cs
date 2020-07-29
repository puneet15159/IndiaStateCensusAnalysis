using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;

delegate bool FileDelimiterCheck(string path);
namespace CSVAnalyser
{
    public class CheckDelimiter
    {
        public static bool CheckDelimiterMethod(string filePath)
        {
            string[] data = File.ReadAllLines(filePath);
            IEnumerable<string> records = data;
            foreach (var element in records)
            {
                if (!element.Contains(":"))
                {
                    return false; ;
                }
            }

            return true;
        }
    }
}