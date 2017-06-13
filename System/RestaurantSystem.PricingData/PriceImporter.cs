namespace RestaurantSystem.PricingData
{
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Infrastructure.Constants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class PriceImporter
    {
        private int saveChangesCount = 50;

        public void ImportPrices()
        {
            Console.WriteLine("Starting import of new prices...");
            Console.WriteLine();
            var newPricesData = new PricingData();

            var restaurantData = new RestaurantSystemData();

            var newPrices = newPricesData.NewPricesRepository
                .All()
                .ToList();

            var updatedProducts = 0;

            for (int i = 0; i < newPrices.Count; i++)
            {
                var type = newPrices[i].ItemType;

                var dataToUpdate = restaurantData.Products
                    .All()
                    .Where(x => x.Name == type)
                    .ToList();

                for (int z = 0; z < dataToUpdate.Count; z++)
                {
                    dataToUpdate[z].AveragePrice = newPrices[i].Price;
                    dataToUpdate[z].ModifiedOn = DateTime.Now;

                    restaurantData.Products.Update(dataToUpdate[z]);

                    //restaurantData.SaveChanges();

                    this.SaveChanges(z, restaurantData);
                }

                restaurantData.SaveChanges();
                updatedProducts += dataToUpdate.Count;
            }

            if (updatedProducts > 0)
            {
                Console.WriteLine($"Import of new prices finished successfuly. Products updated: {updatedProducts}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("0 updated products");
                Console.WriteLine();
            }
        }

        protected void SaveChanges(int count, IRestaurantSystemData db)
        {
            if (count % saveChangesCount == 0)
            {
                for (int i = 0; i <= GlobalConstants.SaveChangesRetryCountIfError; i++)
                {
                    try
                    {
                        var c = db.SaveChanges();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }
    }
}