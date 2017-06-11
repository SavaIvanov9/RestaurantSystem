namespace RestaurantSystem.PricingData
{
    using RestaurantSystem.PricingData.Models;
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Linq;

    public class PricingDataDbContext : DbContext
    {
        public PricingDataDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configure();
        }

        public PricingDataDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new DbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }

        public virtual IDbSet<NewPrices> NewPrices { get; set; }
    }
}
