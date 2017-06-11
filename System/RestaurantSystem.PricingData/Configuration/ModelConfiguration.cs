namespace RestaurantSystem.PricingData
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureNewPricesEntity(modelBuilder);
        }

        private static void ConfigureNewPricesEntity(DbModelBuilder modelBuilder)
        {
        }
    }
}