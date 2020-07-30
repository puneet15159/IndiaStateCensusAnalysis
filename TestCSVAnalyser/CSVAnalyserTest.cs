
using CSVAnalyser;
using NUnit.Framework;


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
            string filePath = @"C:\punee\StateCensusAnalyser\IndiaStateCensusData.csv";
            
            var exception = Assert.Throws<CSVException>(() => CSVStateCensusRecords.GetRecords(filePath));
            Assert.AreEqual(CSVException.ExceptionType.FILE_PATH_INCORRECT, exception.type);
            
        }

        [Test]
        public void GivenCSVFile_WhenWrongFileName_ShouldThrowCustomException()
        {
            string filePath = @"C:\Users\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCensusData.csx";
            var exception = Assert.Throws<CSVException>(() => CSVStateCensusRecords.GetRecords(filePath));
            Assert.AreEqual(CSVException.ExceptionType.FILE_NAME_INCORRECT, exception.type);

        }

        [Test]
        public void GivenCSVFile_WhenWrongDelimiter_ShouldThrowCustomException()
        {

            string filePath = @"C:\Users\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCensusData.csv";
            var exception = Assert.Throws<CSVException>(() => CSVStateCensusRecords.GetDelimiters(filePath));
            Assert.AreEqual(CSVException.ExceptionType.DELIMITER_INCORRECT,exception.type);


        }

        [Test]
        public void GivenCSVFile_WhenHeadersDoNotMatch_ShouldThrowCustomException()
        {

            string filePath = @"C:\Users\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCensusData.csv";
            string otherFilePath = @"C:\Users\punee\source\repos\StateCensusAnalyser\StateCensusAnalyser\IndiaStateCode.csv";
            var exception = Assert.Throws<CSVException>(() => CSVStateCensusRecords.GetFileHeaders(filePath, otherFilePath));
            Assert.AreEqual(CSVException.ExceptionType.HEADERS_DONOT_MATCH, exception.type);

        }
    }
}