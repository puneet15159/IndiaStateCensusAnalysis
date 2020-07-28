using LumenWorks.Framework.IO.Csv;
using System;
using System.IO;

namespace StateCensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCensusData.csv";
            int CSVRecords=CSVStateCensusRecords.GetRecords(filePath);
            int stateRecord=StateCensusAnalyserUtility.GetStateCensusRecords(filePath);
            Console.WriteLine("census recorded "+CSVRecords);
            Console.WriteLine("census recorded through program "+stateRecord);
        }
    }
}
