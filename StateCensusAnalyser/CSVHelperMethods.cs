using ChoETL;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using System.Linq;
using Nancy.Json.Simple;
using ServiceStack.Text;

namespace CSVAnalyser
{
    public class RootObjectStateCensus
    {
        public string State { get; set; }
        public string Population { get; set; }
        public string AreaInSqKm { get; set; }
        public string DensityPerSqKm { get; set; }

        
    }

    public class RootObjectForStateCode
    {
        public string SrNo { get; set; }
        public string StateName { get; set; }
        public string TIN { get; set; }
        public string StateCode { get; set; }

        
    }
    public class CSVHelperMethods
    {
        public int GetRecords(string filePath)
        {
            try
            {
                int count = 0;
                string[] data = File.ReadAllLines(filePath);
                IEnumerable<string> records = data;
                List<string> dataList = new List<string>();
                foreach (var element in records)
                {
                    count++;
                    dataList.Add(element);
                }

                return dataList.Count -1;
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

        public string GetJSON(string filePath)
        {
            
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
                   
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

        public string SortJSONDataAccordingToState(string jsonData)
        {
                var jObj = JsonConvert.DeserializeObject<List<RootObjectStateCensus>>(jsonData);        
                var props = jObj.ToList();
             

                foreach (var prop in props.OrderByDescending(p => p.State))
                {
                    jObj.Add(prop);
                    
                }

                return JsonConvert.SerializeObject(jObj);
           
        }

        public string SortJSONDataAccordingToStateCode(string jsonData)
        {
            var jObj = JsonConvert.DeserializeObject<List<RootObjectForStateCode>>(jsonData);
            var props = jObj.ToList();


            foreach (var prop in props.OrderByDescending(p => p.StateCode))
            {
                jObj.Add(prop);

            }

            return JsonConvert.SerializeObject(jObj);

        }

        public string SortJSONDataAccordingToStatePopulation(string jsonData)
        {
            var jObj = JsonConvert.DeserializeObject<List<RootObjectStateCensus>>(jsonData);
            var props = jObj.ToList();


            foreach (var prop in props.OrderByDescending(p => p.Population))
            {
                jObj.Add(prop);

            }

            return JsonConvert.SerializeObject(jObj);

        }

        public string SortJSONDataAccordingToStatePopulationDensity(string jsonData)
        {
            var jObj = JsonConvert.DeserializeObject<List<RootObjectStateCensus>>(jsonData);
            var props = jObj.ToList();


            foreach (var prop in props.OrderByDescending(p => p.DensityPerSqKm))
            {
                jObj.Add(prop);

            }

            return JsonConvert.SerializeObject(jObj);

        }

        public string SortJSONDataAccordingToStateArea(string jsonData)
        {
            var jObj = JsonConvert.DeserializeObject<List<RootObjectStateCensus>>(jsonData);
            var props = jObj.ToList();


            foreach (var prop in props.OrderByDescending(p => p.AreaInSqKm))
            {
                jObj.Add(prop);

            }

            return JsonConvert.SerializeObject(jObj);

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
