namespace RestaurantSystem.PricingData
{
    using RestaurantSystem.PricingData.Configuration;
    using SQLite.CodeFirst;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DbInitializer : SqliteDropCreateDatabaseWhenModelChanges<PricingDataDbContext>
    {
        public DbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder, typeof(CustomHistory))
        { }

        protected override void Seed(PricingDataDbContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}
