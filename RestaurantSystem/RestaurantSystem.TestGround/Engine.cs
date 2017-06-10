using RestaurantSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using RestaurantSystem.Data.Migrations;
using RestaurantSystem.Models;
using RestaurantSystem.ErrorLogData;
using RestaurantSystem.ErrorLogData.Models;
using Newtonsoft.Json;
using RestaurantSystem.DataImporter;

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

            TestData();
            //TestErrorDb();
            //this.TestModelGenerator();
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
            string saleToJson = JsonConvert.SerializeObject(someSale, Formatting.Indented);
            string supplyDocumentToJson = JsonConvert.SerializeObject(someSupplyDocument, Formatting.Indented);
            Console.WriteLine(supplyDocumentToJson);
        }
    }
}
