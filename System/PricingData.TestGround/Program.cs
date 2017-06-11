using RestaurantSystem.PricingData;
using RestaurantSystem.PricingData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData.TestGround
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PricingData.TestGrond started");

            StartDemoUseFile();
            PressEnterToExit();
        }

        private static void StartDemoUseFile()
        {
            using (var context = new PricingDataDbContext("RestaurantSystemNewPrices"))
            {
                CreateAndSeedDatabase(context);
                DisplaySeededData(context);
            }
        }

        private static void CreateAndSeedDatabase(DbContext context)
        {
            Console.WriteLine("Create and seed the database.");

            if (context.Set<NewPrices>().Count() != 0)
            {
                return;
            }

            context.Set<NewPrices>().Add(new NewPrices
            {
                ItemType = "123",
                Price = 123
            });

            context.SaveChanges();

            Console.WriteLine("Completed.");
            Console.WriteLine();
        }

        private static void DisplaySeededData(DbContext context)
        {
            Console.WriteLine("Display seeded data.");

            foreach (var price in context.Set<NewPrices>())
            {
                Console.WriteLine("\t Price:");
                Console.WriteLine("\t Id: {0}", price.Id);
                Console.WriteLine("\t ItemType: {0}", price.ItemType);
                Console.WriteLine("\t NewPrice: {0}", price.Price);
                Console.WriteLine();
            }
        }

        private static void PressEnterToExit()
        {
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to exit.");
            Console.ReadLine();
        }
    }
}