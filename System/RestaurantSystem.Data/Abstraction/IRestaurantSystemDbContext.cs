namespace RestaurantSystem.Data.Abstraction
{
    using RestaurantSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IRestaurantSystemDbContext : IDisposable
    {
        IDbSet<Address> Address { get; set; }

        IDbSet<City> City { get; set; }

        IDbSet<MeasuringUnit> MeasuringUnit { get; set; }

        IDbSet<MenuItemComponent> MenuItemComponent { get; set; }

        IDbSet<MenuItem> MenuItem { get; set; }

        //IDbSet<MenuItemsStore> MenuItemsStore { get; set; }

        IDbSet<MenuItemType> MenuItemType { get; set; }

        IDbSet<Product> Product { get; set; }

        IDbSet<StoredProduct> StoredProduct { get; set; }

        IDbSet<ProductType> ProductType { get; set; }

        IDbSet<RestaurantBranch> RestaurantBranch { get; set; }

        IDbSet<Sale> Sale { get; set; }

        IDbSet<SaleComponent> SaleComponent { get; set; }

        IDbSet<Supplier> Supplier { get; set; }

        IDbSet<SupplyDocument> SupplyDocument { get; set; }

        IDbSet<SupplyDocumentComponent> SupplyDocumentComponent { get; set; }

        IDbSet<Waiter> Waiter { get; set; }

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
