using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using Nett;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;

namespace Fedex
{
    internal class Program
    {
        public static async Task Main()
        {
            string projectId = "your-project-id";
            string datasetId = "your_dataset_id";
            string table = "your_table_id";
            var uploadJsonOptions = new UploadJsonOptions(){};
            var timedToken = await FedexApi.GetAccessTokenAsync();
            var fetchData = await TrackNums.GetTrack(timedToken);
            var formatData = await ToLines.Extrapolate(fetchData, projectId,datasetId,table);
            foreach (var i in formatData)
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine("something");
        }
        public static TomlObject Config(string keyV)
        {
            //var workingDirectory =System.Reflection.Assembly.GetExecutingAssembly().Location;
            //var parentDirectory =  Directory.GetParent(workingDirectory)?.Parent?.FullName;
            TomlObject info = null;
            //Console.WriteLine(parentDirectory+"\\config.toml");
            {
                var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var exeDir = Path.GetDirectoryName(exePath);
                var binDir = Directory.GetParent(exeDir ?? throw new InvalidOperationException());
                var parseToml = Toml.ReadFile($"{exeDir}/config.toml");
                var data = parseToml.Rows.AsQueryable().Where(x => x.Key == keyV);
                foreach (var keyValuePair in data)
                {
                    info = keyValuePair.Value;
                }
            }
            return info;
        }

        public static void EachCsv()
        {
            var jsons =
                Directory.GetFiles(Program.Config("rootPath").ToString(), "*.json").ToList();
            foreach (var jsonFile in jsons)
            {
                Console.WriteLine(jsonFile);
                if (jsonFile.Length >= 10)
                {
                    var tableName = jsonFile.Split('\\').Last().Split('.').First();
                    Console.WriteLine(tableName);
                    //LoadFromFile("misShip", "_week{current}", tableName, jsonFile, tableName);
                }
                else
                {
                    throw new Exception("File size under 1KB");
                }
            }
        }
    }
}