namespace RestaurantSystem.ErrorLogData.Abstraction
{
    using RestaurantSystem.ErrorLogData.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IErrorDbContext : IDisposable
    {
        IDbSet<Error> Error { get; set; }

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}

