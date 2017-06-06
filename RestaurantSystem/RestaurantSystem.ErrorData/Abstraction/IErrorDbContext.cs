namespace RestaurantSystem.ErrorData.Abstraction
{
    using RestaurantSystem.ErrorData.Models;
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

