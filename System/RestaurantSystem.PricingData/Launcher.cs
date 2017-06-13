using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using RestaurantSystem.PricingData.Models;

namespace RestaurantSystem.PricingData
{
    class Lancher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PricingData manager started");

            var generator = new DbGenerator();
            //generator.GenerateDb();
            generator.DisplaySeededData(new PricingData());

            var importer = new PriceImporter();
            importer.ImportPrices();
        }
    }
}