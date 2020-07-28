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
        [Test]
        public void GivenCSVFile_WhenWrongFilePath_ShouldThrowCustomException()
        {
            try
            {
                string filePath = @"C:\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCensusData.csv";
                int CSVRecords = CSVStateCensusRecords.GetRecords(filePath);
                int records = StateCensusAnalyserUtility.GetStateCensusRecords(filePath);
                Assert.AreEqual(CSVRecords, records);
            }
            catch (StateCensusAnalyserException e)
            {

                Assert.AreEqual("You have entered a wrong directory path",e.Message);
            }
        }

        [Test]
        public void GivenCSVFile_WhenWrongFileName_ShouldThrowCustomException()
        {
            try
            {
                string filePath = @"C:\Users\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCensusData.txt";
                int CSVRecords = CSVStateCensusRecords.GetRecords(filePath);
                int records = StateCensusAnalyserUtility.GetStateCensusRecords(filePath);
                Assert.AreEqual(CSVRecords, records);
            }
            catch (StateCensusAnalyserException e)
            {

                Assert.AreEqual("Name of the file is incorrect", e.Message);
            }
        }
    }
}