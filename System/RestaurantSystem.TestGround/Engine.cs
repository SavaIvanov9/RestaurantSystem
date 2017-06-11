using RestaurantSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RestaurantSystem.ErrorLogData;
using Newtonsoft.Json;
using RestaurantSystem.DataImporter;
using RestaurantSystem.JsonModels.JsonModels;
using JsonFilesGenerator;
using RestaurantSystem.Models;
using RestaurantSystem.DataImporter.SupplyDocumentImporter;
using RestaurantSystem.Data.Migrations;
using RestaurantSystem.DataImporter.SupplyDocumentImporter.Importers;
using RestaurantSystem.MapperJsonModel;

namespace RestaurantSystem.TestGround
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("RestaurantSystem.TestGround started.");
            
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<RestaurantSystemDbContext, Configuration>());

            Database.SetInitializer(new DropCreateDatabaseAlways<RestaurantSystemDbContext>());

            //TestData();
            //TestErrorDb();

            //this.TestModelGenerator();
            this.TestImporters();
        }

        public void TestImporters()
        {
            var db = new RestaurantSystemData();

            var si = new SupplierImporter();
            var objGenerator = new TestObjectRandomGenerator();
            var mapper = new JsonModelMapper();

            var suppliers = new List<SupplyDocument>();
            suppliers.Add(mapper.ConvertSupplyDocument(objGenerator.GenerateSupplyDocument()));

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            Console.WriteLine(json);

            var jsonImporter = new SupplyDocumentDataSeeder();
            jsonImporter.Seed(suppliers, db);
        }

        public void TestData()
        {
            var db = new RestaurantSystemData();

            Console.WriteLine(db.Addresses.All().ToList().Count);
            Console.WriteLine(db.Cities.All().ToList().Count);

            var testData = new List<SupplyDocument>()
            {
                new SupplyDocument()
                {
                    ReferenceNumber = 1,
                    DocumentDate = DateTime.Now,
                    Supplier = new Supplier
                    {
                        Name = "Test name 1z",
                        Address = new Address
                        {
                            PostCode = 1234,
                            Street = "street",
                            ContactName = "contact",
                            PhoneNumber = "123455",
                            City = new City
                            {
                                Name = "Sofia"
                            }
                        }
                    }
                }
            };

            var jsonImporter = new SupplyDocumentDataSeeder();
            jsonImporter.Seed(testData, db);

            Console.WriteLine(db.Addresses.All().ToList().Count);
            Console.WriteLine(db.Cities.All().ToList().Count);

        }

        public void TestErrorDb()
        {
            Console.WriteLine("RestaurantSystem.TestGround started.");

            var db = new ErrorDbContext();

            //db.Error.Add(new Error
            //{
            //    Content = "1"
            //});

            //db.SaveChanges();

            Console.WriteLine(db.Error.ToList().Count);

            var error = db.Error.FirstOrDefault();

            Console.WriteLine(error.Name);
            Console.WriteLine(error.Name);
            Console.WriteLine(error.Content);

        }

        public void TestModelGenerator()
        {
            var objGenerator = new TestObjectRandomGenerator();
            var someSale = objGenerator.GenerateSale();
            var someSupplyDocument = objGenerator.GenerateSupplyDocument();
            var someSupplyDocumentCollection = new List<JsonSupplyDocument>();
            someSupplyDocumentCollection.Add(someSupplyDocument);
            someSupplyDocumentCollection.Add(objGenerator.GenerateSupplyDocument());

            string saleToJson = JsonConvert.SerializeObject(someSale, Formatting.Indented);
            string supplyDocumentToJson = JsonConvert.SerializeObject(someSupplyDocumentCollection, Formatting.Indented);
            Console.WriteLine(supplyDocumentToJson);

            someSupplyDocumentCollection = JsonConvert.DeserializeObject<List<JsonSupplyDocument>>(supplyDocumentToJson);
        }
    }
}
