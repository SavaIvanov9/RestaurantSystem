using JsonFilesGenerator;
using RestaurantSystem.FileManager;
using System;
using RestaurantSystem.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestaurantSystem.Models;
using RestaurantSystem.DataImporter.SupplyDocumentImporter;
using RestaurantSystem.DataImporter.SupplyDocumentImporter.Importers;
using RestaurantSystem.MapperJsonModel;
using System.Linq;
using System.Data.Entity;

namespace TestImport
{
    public class Engine
    {
        private IFileManager fileManager;
        private ITestObjectRandomGenerator objGenerator;

        public Engine(IFileManager fileManager, ITestObjectRandomGenerator objGenerator)
        {
            this.fileManager = fileManager;
            this.objGenerator = objGenerator;
        }

        public void Start()
        {
            TestImporters();
        }

        public void TestImporters()
        {
            var db = new RestaurantSystemData();

            Database.SetInitializer(new DropCreateDatabaseAlways<RestaurantSystemDbContext>());


            var si = new SupplierImporter();
            var objGenerator = new TestObjectRandomGenerator();
            var mapper = new JsonModelMapper();

            var suppliers = new List<SupplyDocument>();
            var supplier = objGenerator.GenerateSupplyDocument();

            string supplyDocumentToJson = JsonConvert.SerializeObject(supplier, Formatting.Indented);
            suppliers.Add(mapper.ConvertSupplyDocument(supplier));

            Console.WriteLine(supplyDocumentToJson);

            Console.WriteLine(db.Addresses.All().ToList().Count);
            Console.WriteLine(db.Cities.All().ToList().Count);
            Console.WriteLine(db.Suppliers.All().ToList().Count);
            Console.WriteLine();


            var jsonImporter = new SupplyDocumentDataSeeder();
            jsonImporter.Seed(suppliers, db);

            Console.WriteLine(db.Addresses.All().ToList().Count);
            Console.WriteLine(db.Cities.All().ToList().Count);
            Console.WriteLine(db.Suppliers.All().ToList().Count);
        }


    }
}
