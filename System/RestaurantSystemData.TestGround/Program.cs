using RestaurantSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JsonFilesGenerator;
using RestaurantSystem.Models;
using RestaurantSystem.Data.Migrations;
using RestaurantSystem.Data.Abstraction;

namespace RestaurantSystem.TestGround
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RestaurantSystemDbContext>());

            IRestaurantSystemData db = new RestaurantSystemData();

            Console.WriteLine(db.SupplyDocuments.All().ToList().Count);

            var i = new TestDataImporter();
            i.Import(db);

            Console.WriteLine(db.SupplyDocuments.All().ToList().Count);
        }
    }
}
