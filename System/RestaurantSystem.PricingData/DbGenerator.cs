namespace RestaurantSystem.PricingData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Data.SQLite;
    using System.IO;
    using RestaurantSystem.PricingData.Models;
    using RestaurantSystem.PricingData.Abstraction;

    public class DbGenerator
    {
        public void GenerateDb()
        {
            Console.WriteLine("PricingData DbGenerator started");

            var db = CreateAndSeedDatabase();
        }

        private IPricingData CreateAndSeedDatabase()
        {
            var db = new PricingData();
            Console.WriteLine(db.NewPricesRepository.All().ToList().Count());

            db.NewPricesRepository.Add(new NewPrices
            {
                ItemType = "salt",
                Price = 11
            });

            db.NewPricesRepository.Add(new NewPrices
            {
                ItemType = "cucumbers",
                Price = 22
            });

            db.NewPricesRepository.Add(new NewPrices
            {
                ItemType = "oil",
                Price = 33
            });

            db.SaveChanges();
            return db;
        }

        public void DisplaySeededData(IPricingData db)
        {
            Console.WriteLine("Display seeded data.");

            foreach (var price in db.NewPricesRepository.All().ToList())
            {
                Console.WriteLine("\t Price:");
                Console.WriteLine("\t Id: {0}", price.Id);
                Console.WriteLine("\t ItemType: {0}", price.ItemType);
                Console.WriteLine("\t NewPrice: {0}", price.Price);
                Console.WriteLine();
            }
        }

        #region Old
        //private void CreateAndSeedDatabase(DbContext context)
        //{
        //    Console.WriteLine("Create and seed the database.");

        //    if (context.Set<NewPrices>().Count() != 0)
        //    {
        //        return;
        //    }

        //    context.Set<NewPrices>().Add(new NewPrices
        //    {
        //        ItemType = "aasd",
        //        Price = 1
        //    });

        //    context.SaveChanges();

        //    Console.WriteLine("Created and seedes successfuly.");
        //    Console.WriteLine();
        //}

        //private void DisplaySeededData(DbContext context)
        //{
        //    Console.WriteLine("Display seeded data.");

        //    foreach (var price in context.Set<NewPrices>())
        //    {
        //        Console.WriteLine("\t Price:");
        //        Console.WriteLine("\t Id: {0}", price.Id);
        //        Console.WriteLine("\t ItemType: {0}", price.ItemType);
        //        Console.WriteLine("\t NewPrice: {0}", price.Price);
        //        Console.WriteLine();
        //    }
        //}
        #endregion
    }
}