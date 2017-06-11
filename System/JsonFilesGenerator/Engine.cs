using Newtonsoft.Json;
using RestaurantSystem.FileManager;
using RestaurantSystem.Infrastructure.Constants;
using RestaurantSystem.JsonModels.JsonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonFilesGenerator
{
    public class Engine
    {
        private IFileManager fileManager;
        private ITestObjectRandomGenerator objGenerator;

        private void GenerateSupplyDocumentJsonFile()
        {
            var someSupplyDocumentCollection = new List<JsonSupplyDocument>();

            for (int i=0; i<5; i++)
            {
                someSupplyDocumentCollection.Add(objGenerator.GenerateSupplyDocument());
            }

            string supplyDocumentToJson = JsonConvert.SerializeObject(someSupplyDocumentCollection, Formatting.Indented);
            
            this.fileManager.WriteFile(Encoding.ASCII.GetBytes(supplyDocumentToJson), null, GlobalConstants.JsonSupplyDocumentsFileName);
        }

        public Engine(IFileManager fileManager, ITestObjectRandomGenerator objGenerator)
        {
            this.fileManager = fileManager;
            this.objGenerator = objGenerator;
        }

        public void Start()
        {
            GenerateSupplyDocumentJsonFile();
        }
    }
}
