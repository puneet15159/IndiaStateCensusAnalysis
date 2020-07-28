using NUnit.Framework;
using StateCensusAnalyser;

namespace TestCSVAnalyser
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenCSVFile_WhenNumberOfRecordsMatches_ShouldReturnTrue()
        {
            string filePath = @"C:\Users\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCensusData.csv";
            int CSVRecords = CSVStateCensusRecords.GetRecords(filePath);
            int records = StateCensusAnalyserUtility.GetStateCensusRecords(filePath);
            Assert.AreEqual(CSVRecords, records);
        }
    }
}