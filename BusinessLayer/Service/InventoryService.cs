using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace BusinessLayer
{
    public class InventoryService : IInventoryService
    {
        private IInventoryRepository _inventoryRepository;
        private string _filePath;
        private IFileReader _fileReader;

        public InventoryService(IInventoryRepository InventoryRepository, IInventoryDatabaseSettings Settings, IFileReader FileReader)
        {

            _inventoryRepository = InventoryRepository;
            _filePath = Settings.FilePath;
            _fileReader = FileReader;
        }

        public void CapterraDataProvider()
        {
            List<string> fileData = GetDataFromFilePath(_filePath, "capterra.*");
            if (!string.Equals(fileData[0], "No file found in the directory", StringComparison.CurrentCultureIgnoreCase)
                 && !string.Equals(fileData[0], "No Data found in the file", StringComparison.CurrentCultureIgnoreCase))
                _inventoryRepository.Insert(fileData);
        }

        public void SoftwareAdviceDataProvider()
        {
            List<string> fileData = GetDataFromFilePath(_filePath, "softwareadvice.*");
            if (!string.Equals(fileData[0], "No file found in the directory", StringComparison.CurrentCultureIgnoreCase)
                 && !string.Equals(fileData[0], "No Data found in the file", StringComparison.CurrentCultureIgnoreCase))
                _inventoryRepository.Insert(fileData);
        }

        public void NewClientDataProvider()
        {
            GetDataFromAPI();
        }

        public List<string> GetDataFromFilePath(string FilePath, string Provider)
        {
            List<string> list = new List<string>();
            var filePaths = Directory.GetFiles(FilePath, Provider);

            if (filePaths.Count() != 0)
            {

                foreach (var filePath in filePaths)
                {

                    switch (Path.GetExtension(filePath).ToLower())
                    {
                        case ".yaml":
                            list.AddRange(_fileReader.ReadYamlFile(filePath));
                            break;
                        case ".json":
                            list.AddRange(_fileReader.ReadJsonFile(filePath));
                            break;
                        case ".xls":
                            //list.AddRange(_fileReader.ReadExcelFile(filePath));
                            break;
                        case ".csv":
                            //list.AddRange(_fileReader.ReadCsvFile(filePath));
                            break;

                    }
                }
            }
            else
            {
                list.Add("No file found in the directory");
            }
            return list;
        }
       public List<string> GetDataFromAPI()
        {
            List<string> list = new List<string>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60464/api/");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                   
                }
            }

            return new List<string>();
        }
    }

}
