namespace RestaurantSystem.PricingData.Abstraction
{
    using RestaurantSystem.PricingData.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IPricingDataDbContext : IDisposable
    {
        IDbSet<NewPrices> NewPrices { get; set; }

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
