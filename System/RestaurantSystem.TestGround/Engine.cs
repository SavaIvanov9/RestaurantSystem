﻿using RestaurantSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RestaurantSystem.ErrorLogData;
using Newtonsoft.Json;
using RestaurantSystem.DataImporter;
using RestaurantSystem.JsonModels.JsonModels;
using JsonFilesGenerator;

namespace RestaurantSystem.TestGround
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("RestaurantSystem.TestGround started.");


            //Database.SetInitializer(
            //new MigrateDatabaseToLatestVersion<RestaurantSystemDbContext, Configuration>());

            Database.SetInitializer(new DropCreateDatabaseAlways<RestaurantSystemDbContext>());

            //TestData();
            //TestErrorDb();
            this.TestModelGenerator();
        }

        public void TestData()
        {
            var db = new RestaurantSystemData();

            //db.Waiters.Add(new Waiter
            //{
            //    Name = "1"
            //});

            //db.SaveChanges();
            Console.WriteLine(db.Addresses.All().ToList().Count);
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