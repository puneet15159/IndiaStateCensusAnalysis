using LumenWorks.Framework.IO.Csv;
using System;
using System.IO;
using CSVAnalyser;

namespace CSVAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCensusData.csv";
            string otherFilePath = @"C:\Users\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCode.csv";
            int CSVRecords=CSVStateCensusRecords.GetRecords(filePath);

            int stateRecord=StateCensusAnalyserUtility.GetStateCensusRecords(filePath);

            FileHeadersCheck fileHeaders = new FileHeadersCheck(CheckFileHeaders.CheckFileHeadersMethod);
            FileDelimiterCheck fileDelimiter = new FileDelimiterCheck(CheckDelimiter.CheckDelimiterMethod);
            NumberOfRecordsInFile numberOfRecords = new NumberOfRecordsInFile(GetNumberOfRecords.GetNumberOfRecordsMethod);

            Console.WriteLine(fileHeaders(filePath, otherFilePath));
            Console.WriteLine(fileDelimiter(filePath));
            Console.WriteLine(numberOfRecords(filePath));

            Console.WriteLine("census recorded "+CSVRecords);
            Console.WriteLine("census recorded through program "+stateRecord);
        }
    }
}
